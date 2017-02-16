namespace AutoUpdateServerManagement
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
            this.gbUpdateContent = new System.Windows.Forms.GroupBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.btnSysUpdate = new System.Windows.Forms.Button();
            this.chkRollBack = new System.Windows.Forms.CheckBox();
            this.chkServerBak = new System.Windows.Forms.CheckBox();
            this.chkForceUpdate = new System.Windows.Forms.CheckBox();
            this.txtDes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvUpdateFileInfo = new System.Windows.Forms.DataGridView();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtUpdateFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbClientType = new System.Windows.Forms.ComboBox();
            this.gbUpdateContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateFileInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUpdateContent
            // 
            this.gbUpdateContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdateContent.Controls.Add(this.panel1);
            this.gbUpdateContent.Controls.Add(this.lblSize);
            this.gbUpdateContent.Controls.Add(this.lblFileCount);
            this.gbUpdateContent.Controls.Add(this.btnSysUpdate);
            this.gbUpdateContent.Controls.Add(this.chkRollBack);
            this.gbUpdateContent.Controls.Add(this.chkServerBak);
            this.gbUpdateContent.Controls.Add(this.chkForceUpdate);
            this.gbUpdateContent.Controls.Add(this.txtDes);
            this.gbUpdateContent.Controls.Add(this.label8);
            this.gbUpdateContent.Controls.Add(this.label7);
            this.gbUpdateContent.Controls.Add(this.dgvUpdateFileInfo);
            this.gbUpdateContent.Controls.Add(this.label6);
            this.gbUpdateContent.Controls.Add(this.txtVersion);
            this.gbUpdateContent.Controls.Add(this.txtUpdateFilePath);
            this.gbUpdateContent.Controls.Add(this.label1);
            this.gbUpdateContent.Controls.Add(this.btnBrowse);
            this.gbUpdateContent.Controls.Add(this.label4);
            this.gbUpdateContent.Controls.Add(this.label5);
            this.gbUpdateContent.Location = new System.Drawing.Point(12, 12);
            this.gbUpdateContent.Name = "gbUpdateContent";
            this.gbUpdateContent.Size = new System.Drawing.Size(867, 491);
            this.gbUpdateContent.TabIndex = 1;
            this.gbUpdateContent.TabStop = false;
            this.gbUpdateContent.Text = "版本更新";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblSize.Location = new System.Drawing.Point(15, 122);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(53, 12);
            this.lblSize.TabIndex = 27;
            this.lblSize.Text = "文件大小";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblFileCount.Location = new System.Drawing.Point(15, 95);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(41, 12);
            this.lblFileCount.TabIndex = 28;
            this.lblFileCount.Text = "文件数";
            // 
            // btnSysUpdate
            // 
            this.btnSysUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSysUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSysUpdate.Location = new System.Drawing.Point(394, 445);
            this.btnSysUpdate.Name = "btnSysUpdate";
            this.btnSysUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnSysUpdate.TabIndex = 26;
            this.btnSysUpdate.Text = "更新";
            this.btnSysUpdate.UseVisualStyleBackColor = true;
            this.btnSysUpdate.Click += new System.EventHandler(this.btnSysUpdate_Click);
            // 
            // chkRollBack
            // 
            this.chkRollBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRollBack.AutoSize = true;
            this.chkRollBack.Checked = true;
            this.chkRollBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRollBack.Location = new System.Drawing.Point(356, 400);
            this.chkRollBack.Name = "chkRollBack";
            this.chkRollBack.Size = new System.Drawing.Size(144, 16);
            this.chkRollBack.TabIndex = 23;
            this.chkRollBack.Text = "允许还原到上一个版本";
            this.chkRollBack.UseVisualStyleBackColor = true;
            // 
            // chkServerBak
            // 
            this.chkServerBak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkServerBak.AutoSize = true;
            this.chkServerBak.Checked = true;
            this.chkServerBak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkServerBak.Location = new System.Drawing.Point(212, 400);
            this.chkServerBak.Name = "chkServerBak";
            this.chkServerBak.Size = new System.Drawing.Size(108, 16);
            this.chkServerBak.TabIndex = 24;
            this.chkServerBak.Text = "服务器版本备份";
            this.chkServerBak.UseVisualStyleBackColor = true;
            // 
            // chkForceUpdate
            // 
            this.chkForceUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkForceUpdate.AutoSize = true;
            this.chkForceUpdate.Location = new System.Drawing.Point(98, 400);
            this.chkForceUpdate.Name = "chkForceUpdate";
            this.chkForceUpdate.Size = new System.Drawing.Size(72, 16);
            this.chkForceUpdate.TabIndex = 25;
            this.chkForceUpdate.Text = "强制更新";
            this.chkForceUpdate.UseVisualStyleBackColor = true;
            // 
            // txtDes
            // 
            this.txtDes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDes.Location = new System.Drawing.Point(98, 273);
            this.txtDes.Multiline = true;
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(750, 97);
            this.txtDes.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(13, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "配置信息：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(13, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "描述说明：";
            // 
            // dgvUpdateFileInfo
            // 
            this.dgvUpdateFileInfo.AllowUserToAddRows = false;
            this.dgvUpdateFileInfo.AllowUserToDeleteRows = false;
            this.dgvUpdateFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpdateFileInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateFileInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpdateFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateFileInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileName,
            this.relativePath,
            this.fileSize});
            this.dgvUpdateFileInfo.Location = new System.Drawing.Point(98, 58);
            this.dgvUpdateFileInfo.Name = "dgvUpdateFileInfo";
            this.dgvUpdateFileInfo.ReadOnly = true;
            this.dgvUpdateFileInfo.RowHeadersVisible = false;
            this.dgvUpdateFileInfo.RowHeadersWidth = 30;
            this.dgvUpdateFileInfo.RowTemplate.Height = 23;
            this.dgvUpdateFileInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUpdateFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateFileInfo.Size = new System.Drawing.Size(750, 199);
            this.dgvUpdateFileInfo.TabIndex = 20;
            // 
            // fileName
            // 
            this.fileName.DataPropertyName = "FileName";
            this.fileName.FillWeight = 30F;
            this.fileName.HeaderText = "文件名称";
            this.fileName.Name = "fileName";
            this.fileName.ReadOnly = true;
            // 
            // relativePath
            // 
            this.relativePath.DataPropertyName = "RelativePath";
            this.relativePath.HeaderText = "相对路径";
            this.relativePath.Name = "relativePath";
            this.relativePath.ReadOnly = true;
            // 
            // fileSize
            // 
            this.fileSize.DataPropertyName = "FileSize";
            this.fileSize.FillWeight = 20F;
            this.fileSize.HeaderText = "大小";
            this.fileSize.Name = "fileSize";
            this.fileSize.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "文件列表：";
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Location = new System.Drawing.Point(538, 23);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(121, 21);
            this.txtVersion.TabIndex = 18;
            // 
            // txtUpdateFilePath
            // 
            this.txtUpdateFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateFilePath.Location = new System.Drawing.Point(98, 23);
            this.txtUpdateFilePath.Name = "txtUpdateFilePath";
            this.txtUpdateFilePath.Size = new System.Drawing.Size(291, 21);
            this.txtUpdateFilePath.TabIndex = 17;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Location = new System.Drawing.Point(388, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(58, 21);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(454, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "版本编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "文件路径：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(668, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "客户端类型：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbClientType);
            this.panel1.Location = new System.Drawing.Point(767, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(81, 22);
            this.panel1.TabIndex = 29;
            // 
            // cmbClientType
            // 
            this.cmbClientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbClientType.FormattingEnabled = true;
            this.cmbClientType.Location = new System.Drawing.Point(-1, 0);
            this.cmbClientType.Name = "cmbClientType";
            this.cmbClientType.Size = new System.Drawing.Size(80, 20);
            this.cmbClientType.TabIndex = 30;
            // 
            // AutoUpdateServiceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 515);
            this.Controls.Add(this.gbUpdateContent);
            this.Name = "AutoUpdateServiceManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统更新";
            this.Load += new System.EventHandler(this.AutoUpdateServiceManager_Load);
            this.gbUpdateContent.ResumeLayout(false);
            this.gbUpdateContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateFileInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUpdateContent;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUpdateFilePath;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvUpdateFileInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkRollBack;
        private System.Windows.Forms.CheckBox chkServerBak;
        private System.Windows.Forms.CheckBox chkForceUpdate;
        private System.Windows.Forms.Button btnSysUpdate;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbClientType;
    }
}

