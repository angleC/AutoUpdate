using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools.Log;
using AutoUpdate.Tools.Extensions;
using AutoUpdateServiceAccess;

namespace AutoUpdateServerManagement
{
    public partial class AutoUpdateServiceManager : Form
    {
        private string rootFolderPath = string.Empty;
        private string strServiceProcessName = string.Empty;
        private string strServiceName = string.Empty;
        private UpdateConfig serverConfig = null;
        private IUpdateSystem updateSystem = null;
        
        public AutoUpdateServiceManager()
        {
            InitializeComponent();

            this.updateSystem = ServiceManager.ServiceManagerInstance.GetRemotingService<IUpdateSystem>("updateSystem");
            this.serverConfig = this.updateSystem.GetVersionConfig();
        }

        private void AutoUpdateServiceManager_Load(object sender, EventArgs e)
        {
            this.dgvUpdateFileInfo.AutoGenerateColumns = false;

            this.LoadClientType();
        }

        private void LoadClientType()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(ClientType.Client.ToString(), "客户端");
            dic.Add(ClientType.Server.ToString(), "服务端");

            this.cmbClientType.DataBind(dic);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择更新文件夹路径";
            fbd.ShowNewFolderButton = false;
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string folderPath = fbd.SelectedPath;
            this.txtUpdateFilePath.Text = this.rootFolderPath = folderPath;
            if (string.IsNullOrEmpty(folderPath))
                return;

            List<UploadFileInfo> list = this.GetAllFiles(folderPath);
            this.dgvUpdateFileInfo.DataSource = list;
        }

        private void btnSysUpdate_Click(object sender, EventArgs e)
        {
            UpdateConfig config = new UpdateConfig();
            List<AutoUpdate.Core.Data.FileInfo> fileList = new List<AutoUpdate.Core.Data.FileInfo>();
            List<UploadFileInfo> list = this.dgvUpdateFileInfo.DataSource as List<UploadFileInfo>;
            string versionStr = this.txtVersion.Text.Trim();
            string desStr = this.txtDes.Text.Trim();
            string folderPath = this.txtUpdateFilePath.Text.Trim();

            bool isForceUpdate = this.chkForceUpdate.Checked;
            bool isServerBak = this.chkServerBak.Checked;
            bool isRollBack = this.chkRollBack.Checked;

            if (list == null)
            {
                MessageBox.Show("更新文件获取失败，请重新确认！");
                return;
            }

            if (string.IsNullOrEmpty(versionStr))
            {
                MessageBox.Show("请输入系统更新版本编号！");
                return;
            }

            config.ConfigInfo = new ConfigInfo
            {
                ForceUpdate = isForceUpdate,
                ServerBak = isServerBak,
                RollBack = isRollBack,
                CurrentVersion = versionStr,
                PreviousVersion = (this.serverConfig.ConfigInfo == null || this.serverConfig.ConfigInfo.CurrentVersion == null) ? versionStr : this.serverConfig.ConfigInfo.CurrentVersion,
                Description = desStr
            };

            foreach (var l in list)
            {
                fileList.Add(new AutoUpdate.Core.Data.FileInfo
                {
                    Name = l.FileName,
                    FileSize = l.FileSize,
                    RelativePath = l.RelativePath
                });
            }
            config.FileInfo = fileList;

            UpdateFileToServer ufs = new UpdateFileToServer(config, list);
            ufs.ShowDialog();
        }

        private List<UploadFileInfo> GetAllFiles(string folderPath)
        {
            List<UploadFileInfo> updateFileList = new List<UploadFileInfo>();
            long fileSize = 0;
            long fileCount = 0;
            string fileSizeStr = string.Empty;
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    MessageBox.Show("指定文件夹目录无法找到，请确定是否移除！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                updateFileList.Clear();
                this.GetFileInfo(folderPath, ref updateFileList, ref fileSize, ref fileCount);

                if (fileSize > 1024 && fileSize <= (1024 * 1024))
                {
                    fileSizeStr = (fileSize / 1024).ToString("0.0") + "K";
                }
                else if (fileSize > (1024 * 1024) && fileSize <= (1024 * 1024 * 1024))
                {
                    fileSizeStr = (fileSize / (1024 * 1024)).ToString("0.0") + "M";
                }
                else if (fileSize > ((long)1024 * 1024 * 1024))
                {
                    fileSizeStr = (fileSize / (1024 * 1024 * 1024)).ToString("0.0") + "G";
                }
                else
                {
                    fileSizeStr = fileSize + "B";
                }

                this.lblSize.Text = "大小：" + fileSizeStr;
                this.lblFileCount.Text = "总数：" + fileCount.ToString();

                return updateFileList;
            }
            catch (Exception ex)
            {
                Log4NetHelper.ErrorLog("AutoUpdateServerManagement.AutoUpdateServiceManager.GetAllFiles", ex);
                throw ex;
            }
        }
        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="updateFileList"></param>
        /// <param name="fileSize"></param>
        /// <param name="fileCount"></param>
        private void GetFileInfo(string folderPath, ref List<UploadFileInfo> updateFileList, ref long fileSize, ref long fileCount)
        {
            UploadFileInfo updateFileInfo;
            string filePath = string.Empty;
            try
            {
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                System.IO.FileInfo[] fileInfoList = dir.GetFiles();
                DirectoryInfo[] dirInfo = dir.GetDirectories();

                if (fileInfoList.Length > 0)
                {
                    foreach (System.IO.FileInfo fi in fileInfoList)
                    {
                        updateFileInfo = new UploadFileInfo();
                        filePath = fi.FullName;

                        updateFileInfo.FileName = fi.Name;
                        updateFileInfo.FileSize = fi.Length;
                        updateFileInfo.RelativePath = filePath.Substring(this.rootFolderPath.Length, filePath.Length - this.rootFolderPath.Length - fi.Name.Length);
                        updateFileInfo.PhysicalPath = filePath;

                        updateFileList.Add(updateFileInfo);

                        fileSize += fi.Length;
                        fileCount++;
                    }
                }
                if (dirInfo.Length > 0)
                {
                    foreach (DirectoryInfo di in dirInfo)
                    {
                        this.GetFileInfo(di.FullName, ref updateFileList, ref fileSize, ref fileCount);
                    }
                }

            }
            catch (Exception ex)
            {
                Log4NetHelper.ErrorLog("AutoUpdateServerManagement.AutoUpdateServiceManager.GetFileInfo", ex);
                throw ex;
            }
        }
    }
}
