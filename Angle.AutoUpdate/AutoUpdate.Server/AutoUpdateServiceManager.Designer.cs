namespace AutoUpdateServer
{
    partial class AutoUpdateServiceManager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoUpdateServiceManager));
            this.gbServerManage = new System.Windows.Forms.GroupBox();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.txtServiceProcess = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnServiceStatus = new System.Windows.Forms.Button();
            this.btnStartOrStopService = new System.Windows.Forms.Button();
            this.btnInstallOrUninstallService = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.gbServerManage.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbServerManage
            // 
            this.gbServerManage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbServerManage.Controls.Add(this.txtServiceName);
            this.gbServerManage.Controls.Add(this.txtServiceProcess);
            this.gbServerManage.Controls.Add(this.lblMsg);
            this.gbServerManage.Controls.Add(this.label3);
            this.gbServerManage.Controls.Add(this.label2);
            this.gbServerManage.Controls.Add(this.label1);
            this.gbServerManage.Controls.Add(this.btnServiceStatus);
            this.gbServerManage.Controls.Add(this.btnStartOrStopService);
            this.gbServerManage.Controls.Add(this.btnInstallOrUninstallService);
            this.gbServerManage.Location = new System.Drawing.Point(8, 12);
            this.gbServerManage.Name = "gbServerManage";
            this.gbServerManage.Size = new System.Drawing.Size(385, 212);
            this.gbServerManage.TabIndex = 0;
            this.gbServerManage.TabStop = false;
            this.gbServerManage.Text = "服务管理";
            // 
            // txtServiceName
            // 
            this.txtServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceName.Location = new System.Drawing.Point(91, 65);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(269, 21);
            this.txtServiceName.TabIndex = 15;
            this.txtServiceName.Text = "Auto Update Service";
            // 
            // txtServiceProcess
            // 
            this.txtServiceProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceProcess.Location = new System.Drawing.Point(91, 26);
            this.txtServiceProcess.Name = "txtServiceProcess";
            this.txtServiceProcess.Size = new System.Drawing.Size(269, 21);
            this.txtServiceProcess.TabIndex = 16;
            this.txtServiceProcess.Text = "AutoUpdateServiceHost";
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.SystemColors.Control;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(89, 156);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(271, 41);
            this.lblMsg.TabIndex = 11;
            this.lblMsg.Text = "就绪";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "服务名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "服务状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "服务程序：";
            // 
            // btnServiceStatus
            // 
            this.btnServiceStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnServiceStatus.Location = new System.Drawing.Point(274, 108);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new System.Drawing.Size(85, 26);
            this.btnServiceStatus.TabIndex = 10;
            this.btnServiceStatus.Text = "服务状态";
            this.btnServiceStatus.UseVisualStyleBackColor = true;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);
            // 
            // btnStartOrStopService
            // 
            this.btnStartOrStopService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartOrStopService.Location = new System.Drawing.Point(148, 108);
            this.btnStartOrStopService.Name = "btnStartOrStopService";
            this.btnStartOrStopService.Size = new System.Drawing.Size(85, 26);
            this.btnStartOrStopService.TabIndex = 9;
            this.btnStartOrStopService.Text = "启动服务";
            this.btnStartOrStopService.UseVisualStyleBackColor = true;
            this.btnStartOrStopService.Click += new System.EventHandler(this.btnStartOrStopService_Click);
            // 
            // btnInstallOrUninstallService
            // 
            this.btnInstallOrUninstallService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstallOrUninstallService.Location = new System.Drawing.Point(22, 108);
            this.btnInstallOrUninstallService.Name = "btnInstallOrUninstallService";
            this.btnInstallOrUninstallService.Size = new System.Drawing.Size(85, 26);
            this.btnInstallOrUninstallService.TabIndex = 8;
            this.btnInstallOrUninstallService.Text = "安装服务";
            this.btnInstallOrUninstallService.UseVisualStyleBackColor = true;
            this.btnInstallOrUninstallService.Click += new System.EventHandler(this.btnInstallOrUninstallService_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainForm,
            this.toolStripSeparator1,
            this.tsmiExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(113, 54);
            // 
            // tsmiMainForm
            // 
            this.tsmiMainForm.Name = "tsmiMainForm";
            this.tsmiMainForm.Size = new System.Drawing.Size(112, 22);
            this.tsmiMainForm.Text = "主界面";
            this.tsmiMainForm.Click += new System.EventHandler(this.tsmiMainForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(112, 22);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "远程服务管理平台";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // AutoUpdateServiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 236);
            this.Controls.Add(this.gbServerManage);
            this.MaximizeBox = false;
            this.Name = "AutoUpdateServiceManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新服务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoUpdateServiceManager_FormClosing);
            this.Resize += new System.EventHandler(this.AutoUpdateServiceManager_Resize);
            this.gbServerManage.ResumeLayout(false);
            this.gbServerManage.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbServerManage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.TextBox txtServiceProcess;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnServiceStatus;
        private System.Windows.Forms.Button btnStartOrStopService;
        private System.Windows.Forms.Button btnInstallOrUninstallService;
    }
}

