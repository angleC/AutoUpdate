using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools.Log;
using AutoUpdateServiceAccess;

namespace AutoUpdateServerManagement
{
    public partial class UpdateFileToServer : Form
    {
        private UpdateConfig config = null;
        private List<UploadFileInfo> filesList = null;
        private List<UpdateFileResult> ufrList = new List<UpdateFileResult>();
        private IUpdateSystem updateSystem = null;
        private string serverVersionPath = string.Empty;//服务器上存放版本文件的路径

        delegate void SetUpdateFilePathCallback(string path);

        public UpdateFileToServer(UpdateConfig config, List<UploadFileInfo> files)
        {
            InitializeComponent();

            this.config = config;
            this.filesList = files;

            this.updateSystem = ServiceManager.ServiceManagerInstance.GetRemotingService<IUpdateSystem>("updateSystem");
        }

        private void UpdateFileToServer_Load(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileStream fileStream = null;
            UpdateFileResult ufr = null;

            try
            {
                BackgroundWorker bw = (BackgroundWorker)sender;

                this.serverVersionPath = updateSystem.GenerateVersionConfig(this.config);
                if (string.IsNullOrEmpty(this.serverVersionPath))
                {
                    MessageBox.Show("无法从服务上获取更新文件存储路径。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                int fileCount = Convert.ToInt32(this.filesList.Count);
                int uploadFileCout = 0;//上传文件计数器
                UploadFileResult fur = null;
                bw.ReportProgress(fileCount * 100 / fileCount);

                foreach (UploadFileInfo file in this.filesList)
                {
                    ufr = new UpdateFileResult();
                    this.SetUpdateFileText(file.PhysicalPath);

                    fileStream = new FileStream(file.PhysicalPath, FileMode.Open, FileAccess.Read);

                    fur = this.updateSystem.UploadUpdateSystemFile(new UploadFileInfo
                    {
                        FileName = file.FileName,
                        FileSize = file.FileSize,
                        RelativePath = file.RelativePath,
                        PhysicalPath = this.serverVersionPath + file.RelativePath,
                        FileStream = (Stream)fileStream
                    });

                    uploadFileCout++;
                    bw.ReportProgress(uploadFileCout * 100 / fileCount);

                    ufr.FileName = fur.FileName;
                    ufr.FilePath = fur.RelativePath;
                    ufr.IsSuccess = fur.OperateResult == ResultType.Success ? true : false;
                    ufr.ErrorMsg = fur.ResultMessage;

                    this.ufrList.Add(ufr);
                }
            }
            catch (Exception ex)
            {
                Log4NetHelper.ErrorLog(ex);
                MessageBox.Show("由于：" + ex.ToString() + "\r\n导致上传更新文件失败，请重试！");
                return;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgrUploadProgress.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(500);

            AutoUpdateServerManagement.UpdateFileResult ufrDialog = new AutoUpdateServerManagement.UpdateFileResult(this.ufrList);
            ufrDialog.ShowDialog();

            this.Close();
        }

        private void SetUpdateFileText(string path)
        {
            if (this.lblPath.IsDisposed) return;

            if (this.lblPath.InvokeRequired)
            {
                SetUpdateFilePathCallback s = new SetUpdateFilePathCallback(SetUpdateFileText);
                this.Invoke(s, new object[] { path });
            }
            else
            {
                this.lblPath.Text = path;
            }
        }

        #region 文件上传结果
        /// <summary>
        /// 
        /// </summary>
        public class UpdateFileResult
        {
            public string FileName { get; set; }//文件名称
            public string FilePath { get; set; }//文件路径
            public bool IsSuccess { get; set; }//是否成功
            public string ErrorMsg { get; set; }//错误信息
        }
        #endregion
    }
}
