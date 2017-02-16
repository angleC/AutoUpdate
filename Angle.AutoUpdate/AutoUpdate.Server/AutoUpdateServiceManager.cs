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
using AutoUpdate.Tools.Log;

namespace AutoUpdateServer
{
    public partial class AutoUpdateServiceManager : Form
    {
        private string rootFolderPath = string.Empty;
        private string strServiceProcessName = string.Empty;
        private string strServiceName = string.Empty;

        public AutoUpdateServiceManager()
        {
            InitializeComponent();

            this.strServiceProcessName = string.IsNullOrEmpty(this.txtServiceProcess.Text.Trim()) ? "ServerHost" : this.txtServiceProcess.Text.Trim();
            this.strServiceName = string.IsNullOrEmpty(this.txtServiceName.Text.Trim()) ? "Remoting Server" : this.txtServiceName.Text.Trim();

            this.InitControlStatus(this.strServiceName, this.lblMsg, this.gbServerManage, this.btnInstallOrUninstallService, this.btnStartOrStopService, this.btnServiceStatus);
        }

        #region 服务管理平台功能
        /// <summary>
        /// 初始化控件状态
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="lblMsg">信息显示</param>
        /// <param name="gb">控件内容组合框</param>
        /// <param name="btn1">安装按钮</param>
        /// <param name="btn2">启动按钮</param>
        /// <param name="btn3">获取状态按钮</param>
        private void InitControlStatus(string serviceName, Label lblMsg, GroupBox gb, Button btn1, Button btn2, Button btn3)
        {
            try
            {
                btn1.Enabled = true;

                if (ServiceAPI.IsExist(serviceName))
                {
                    btn3.Enabled = true;
                    btn2.Enabled = true;
                    btn1.Text = "卸载服务";
                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 4)
                    {
                        btn2.Text = "停止服务";
                    }
                    else
                    {
                        btn2.Text = "启动服务";
                    }
                    this.GetServiceStatus(serviceName, lblMsg);
                    //获取服务版本  
                    string temp = string.IsNullOrEmpty(ServiceAPI.GetServiceVersion(serviceName)) ? string.Empty : "(" + ServiceAPI.GetServiceVersion(serviceName) + ")";
                    gb.Text += temp;
                }
                else
                {
                    btn2.Enabled = false;
                    btn3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error" + ex.Message;
            }
        }
        /// <summary>  
        /// 安装或卸载服务  
        /// </summary>  
        /// <param name="serviceProcessName">服务程序名称</param>  
        /// <param name="serviceName">服务名称</param>  
        /// <param name="btn1">安装、卸载</param>  
        /// <param name="btn2">启动、停止</param>  
        /// <param name="lblMsg">提示信息</param>  
        /// <param name="gb">组合框</param>  
        private void SetServerce(string serviceProcessName, string serviceName, Label lblMsg, GroupBox gb, Button btn1, Button btn2, Button btn3)
        {
            try
            {
                string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string serviceFileName = location.Substring(0, location.LastIndexOf('\\')) + "\\" + serviceProcessName + ".exe";

                if (btn1.Text == "安装服务")
                {
                    ServiceAPI.InstallService(null, serviceFileName);
                    if (ServiceAPI.IsExist(serviceName))
                    {
                        lblMsg.Text = "服务【" + serviceName + "】安装成功！";
                        btn2.Enabled = btn3.Enabled = true;
                        string temp = string.IsNullOrEmpty(ServiceAPI.GetServiceVersion(serviceName)) ? string.Empty : "(" + ServiceAPI.GetServiceVersion(serviceName) + ")";
                        gb.Text += temp;
                        btn1.Text = "卸载服务";
                        btn2.Text = "启动服务";
                    }
                    else
                    {
                        lblMsg.Text = "服务【" + serviceName + "】安装失败，请检查日志！";
                    }
                }
                else
                {
                    ServiceAPI.UnInstallService(serviceFileName);
                    if (!ServiceAPI.IsExist(serviceName))
                    {
                        lblMsg.Text = "服务【" + serviceName + "】卸载成功！";
                        btn2.Enabled = btn3.Enabled = false;
                        btn1.Text = "安装服务";
                    }
                    else
                    {
                        lblMsg.Text = "服务【" + serviceName + "】卸载失败，请检查日志！";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error" + ex.Message; ;
            }
        }
        //获取服务状态  
        private void GetServiceStatus(string serviceName, Label lblMsg)
        {
            try
            {
                if (ServiceAPI.IsExist(serviceName))
                {
                    string statusStr = "";
                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    switch (status)
                    {
                        case 1:
                            statusStr = "服务未运行！";
                            break;
                        case 2:
                            statusStr = "服务正在启动！";
                            break;
                        case 3:
                            statusStr = "服务正在停止！";
                            break;
                        case 4:
                            statusStr = "服务正在运行！";
                            break;
                        case 5:
                            statusStr = "服务即将继续！";
                            break;
                        case 6:
                            statusStr = "服务即将暂停！";
                            break;
                        case 7:
                            statusStr = "服务已暂停！";
                            break;
                        default:
                            statusStr = "未知状态！";
                            break;
                    }
                    lblMsg.Text = statusStr;
                }
                else
                {
                    lblMsg.Text = "服务【" + serviceName + "】未安装！";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "error" + ex.Message; ;
            }
        }
        //启动服务  
        private void OnService(string serviceName, Button btn, Label txt)
        {
            try
            {
                if (btn.Text == "启动服务")
                {
                    ServiceAPI.RunService(serviceName);

                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 2 || status == 4 || status == 5)
                    {
                        txt.Text = "服务【" + serviceName + "】启动成功！";
                        btn.Text = "停止服务";
                    }
                    else
                    {
                        txt.Text = "服务【" + serviceName + "】启动失败！";
                    }
                }
                else
                {
                    ServiceAPI.StopService(serviceName);

                    int status = ServiceAPI.GetServiceStatus(serviceName);
                    if (status == 1 || status == 3 || status == 6 || status == 7)
                    {
                        txt.Text = "服务【" + serviceName + "】停止成功！";
                        btn.Text = "启动服务";
                    }
                    else
                    {
                        txt.Text = "服务【" + serviceName + "】停止失败！";
                    }
                }
            }
            catch (Exception ex)
            {
                txt.Text = "error" + ex.Message; ;
            }
        }
        /// <summary>
        /// 卸载或安装服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstallOrUninstallService_Click(object sender, EventArgs e)
        {
            this.strServiceProcessName = string.IsNullOrEmpty(this.txtServiceProcess.Text.Trim()) ? "ServerHost" : this.txtServiceProcess.Text.Trim();
            this.strServiceName = string.IsNullOrEmpty(this.txtServiceName.Text.Trim()) ? "Remoting Server" : this.txtServiceName.Text.Trim();

            this.btnInstallOrUninstallService.Enabled = false;
            this.SetServerce(this.strServiceProcessName, this.strServiceName, this.lblMsg, this.gbServerManage, this.btnInstallOrUninstallService, this.btnStartOrStopService, this.btnServiceStatus);
            btnInstallOrUninstallService.Enabled = true;
            this.btnInstallOrUninstallService.Focus();
        }

        private void btnStartOrStopService_Click(object sender, EventArgs e)
        {
            this.strServiceProcessName = string.IsNullOrEmpty(this.txtServiceProcess.Text.Trim()) ? "ServerHost" : this.txtServiceProcess.Text.Trim();
            this.strServiceName = string.IsNullOrEmpty(this.txtServiceName.Text.Trim()) ? "Remoting Server" : this.txtServiceName.Text.Trim();

            this.btnStartOrStopService.Enabled = false;
            this.OnService(this.strServiceName, this.btnStartOrStopService, this.lblMsg);
            this.btnStartOrStopService.Enabled = true;
            this.btnStartOrStopService.Focus();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            this.strServiceProcessName = string.IsNullOrEmpty(this.txtServiceProcess.Text.Trim()) ? "ServerHost" : this.txtServiceProcess.Text.Trim();
            this.strServiceName = string.IsNullOrEmpty(this.txtServiceName.Text.Trim()) ? "Remoting Server" : this.txtServiceName.Text.Trim();

            this.btnServiceStatus.Enabled = false;
            this.GetServiceStatus(this.strServiceName, this.lblMsg);
            this.btnServiceStatus.Enabled = true;
            this.btnServiceStatus.Focus();
        }

        private void AutoUpdateServiceManager_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void AutoUpdateServiceManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否缩小化到托盘。", "确认", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;

                this.WindowState = FormWindowState.Minimized;
            }
            else if (dr == System.Windows.Forms.DialogResult.No)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void tsmiMainForm_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
            this.Activate();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
            this.ExitProcess();
        }

        private void ExitProcess()
        {
            System.Environment.Exit(0);
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "ServiceSetup")
                {
                    item.Kill();
                }
            }
        }
        #endregion
    }
}
