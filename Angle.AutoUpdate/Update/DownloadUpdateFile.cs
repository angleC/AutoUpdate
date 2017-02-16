using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools;
using AutoUpdateServiceAccess;

namespace Update
{
    public partial class DownloadUpdateFile : Form
    {
        private List<ClientUpdateFile> clientUpdateFileList = new List<ClientUpdateFile>();
        private ClientUpdateConfig clientConfig = null;
        private UpdateConfig serverConfig = null;
        private IUpdateSystem updateSystem = null;
        private string tempPath = Application.StartupPath + @"\temp";//临时路径
        private string updateConfigPath = System.AppDomain.CurrentDomain.BaseDirectory + "UpdateLog.xml";

        delegate void SetUpdateFilePathCallback(string path);

        public DownloadUpdateFile()
        {
            InitializeComponent();

            this.updateSystem = ServiceManager.ServiceManagerInstance.GetRemotingService<IUpdateSystem>("updateSystem");
            this.serverConfig = this.updateSystem.GetVersionConfig();
            this.clientConfig = new ClientUpdateConfig();

            this.clientConfig.ClientUpdateInfo = new ClientUpdateInfo
            {
                PreviousVersion = this.clientConfig.ClientUpdateInfo == null ? this.serverConfig.ConfigInfo.CurrentVersion : this.clientConfig.ClientUpdateInfo.CurrentVersion,
                CurrentVersion = this.serverConfig.ConfigInfo.CurrentVersion,
                UpdateDate = DateTime.Now
            };
        }

        private void DownloadUpdateFile_Load(object sender, EventArgs e)
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
            ClientUpdateFile cuf = null;
            DownloadFileResult dfr = null;
            try
            {
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                else
                {
                    Directory.Delete(tempPath, true);
                    Directory.CreateDirectory(tempPath);
                }
                #region 文件下载

                BackgroundWorker bw = (BackgroundWorker)sender;

                int fileCount = this.serverConfig.FileInfo.Count;
                int downFileCout = 0;//文件计数器
                bw.ReportProgress(fileCount * 100 / fileCount);

                foreach (AutoUpdate.Core.Data.FileInfo file in this.serverConfig.FileInfo)
                {
                    dfr = new DownloadFileResult();
                    cuf = new ClientUpdateFile();
                    this.SetDownFileText(file.RelativePath);
                    dfr = this.updateSystem.DownloadUpdateSystemFile(new DownloadFileInfo
                    {
                        FileName = file.Name,
                        FileSize = file.FileSize,
                        RelativePath = file.RelativePath
                    });

                    cuf.Name = dfr.FileName;
                    cuf.FileSize = dfr.FileSize;
                    cuf.RelativePath = dfr.RelativePath;
                    cuf.IsUpdate = this.SaveDownloadFile(dfr);

                    this.clientUpdateFileList.Add(cuf);

                    downFileCout++;
                    bw.ReportProgress(downFileCout * 100 / fileCount);
                }

                this.clientConfig.FileInfo = this.clientUpdateFileList;
                #endregion
            }
            catch (Exception ex)
            {
                AutoUpdate.Tools.Log.Log4NetHelper.ErrorLog(ex);

                return;
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pgrDownloadProgress.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(500);

            if (this.clientUpdateFileList.Where(l => l.IsUpdate = true).ToList().Count == this.serverConfig.FileInfo.Count)
            {
                this.CopyFileToClient();

                if (!string.IsNullOrEmpty(this.serverConfig.ConfigInfo.Description))
                {
                    UpdateDescription ud = new UpdateDescription(this.serverConfig.ConfigInfo.Description);
                    ud.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("系统更新失败，请进行手动更新。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (this.clientConfig != null)
            {
                SerializeHelper.XmlSerializeToFile(this.clientConfig, this.updateConfigPath);
            }

            //启动安装程序
            Process.Start(Application.StartupPath + "/AutoUpdate.Client.exe");

            this.Close();
        }

        private bool SaveDownloadFile(DownloadFileResult dfr)
        {
            string folderPath = Path.GetDirectoryName(tempPath + dfr.RelativePath);
            string filePath = folderPath + dfr.FileName;
            byte[] buffer = new byte[dfr.FileSize];
            FileStream fd = null;

            try
            {
                //下载到临时路径
                if (dfr.OperateResult == ResultType.Success)
                {
                    if (!string.IsNullOrEmpty(dfr.FileName))
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        fd = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                        int count = 0;
                        while ((count = dfr.FileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fd.Write(buffer, 0, count);
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fd != null)
                {
                    fd.Flush();
                    fd.Close();
                }
            }

            return false;
        }

        /// <summary>
        /// 复制临时路径下文件到程序目录
        /// </summary>
        private void CopyFileToClient()
        {
            //安装前关闭正在运行的程序
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                //如果程序启动了，则杀死
                if (process.ProcessName == "AutoUpdate.Client.vshost" || process.ProcessName == "AutoUpdate.Client")
                {
                    process.Kill();
                    break;
                }
            }

            CopyDir(this.tempPath, Application.StartupPath);

            Directory.Delete(tempPath, true);
        }

        /// <summary>
        /// 复制一个路径下文件到另一个路径下
        /// </summary>
        private void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    aimPath += System.IO.Path.DirectorySeparatorChar;
                }

                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                foreach (string file in fileList)
                {
                    if (System.IO.Directory.Exists(file))
                    {
                        CopyDir(file, aimPath + System.IO.Path.GetFileName(file));
                    }
                    else
                    {
                        System.IO.File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void SetDownFileText(string path)
        {
            if (this.lblPath.IsDisposed) return;

            if (this.lblPath.InvokeRequired)
            {
                SetUpdateFilePathCallback s = new SetUpdateFilePathCallback(SetDownFileText);
                this.Invoke(s, new object[] { path });
            }
            else
            {
                this.lblPath.Text = path;
            }
        }
    }
}
