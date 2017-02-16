namespace AutoUpdateServerManagement
{
    partial class UpdateFileResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFailFilesCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSuccessFilesCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUploadUpdateFilesCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUpdateFileResult = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMsg = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateFileResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFailFilesCount
            // 
            this.lblFailFilesCount.AutoSize = true;
            this.lblFailFilesCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFailFilesCount.Location = new System.Drawing.Point(567, 24);
            this.lblFailFilesCount.Name = "lblFailFilesCount";
            this.lblFailFilesCount.Size = new System.Drawing.Size(14, 14);
            this.lblFailFilesCount.TabIndex = 0;
            this.lblFailFilesCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(479, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "失败文件数：";
            // 
            // lblSuccessFilesCount
            // 
            this.lblSuccessFilesCount.AutoSize = true;
            this.lblSuccessFilesCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSuccessFilesCount.Location = new System.Drawing.Point(339, 24);
            this.lblSuccessFilesCount.Name = "lblSuccessFilesCount";
            this.lblSuccessFilesCount.Size = new System.Drawing.Size(14, 14);
            this.lblSuccessFilesCount.TabIndex = 0;
            this.lblSuccessFilesCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(251, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "成功文件数：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblFailFilesCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblSuccessFilesCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblUploadUpdateFilesCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结果信息";
            // 
            // lblUploadUpdateFilesCount
            // 
            this.lblUploadUpdateFilesCount.AutoSize = true;
            this.lblUploadUpdateFilesCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUploadUpdateFilesCount.Location = new System.Drawing.Point(112, 24);
            this.lblUploadUpdateFilesCount.Name = "lblUploadUpdateFilesCount";
            this.lblUploadUpdateFilesCount.Size = new System.Drawing.Size(14, 14);
            this.lblUploadUpdateFilesCount.TabIndex = 0;
            this.lblUploadUpdateFilesCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "上传文件数：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvUpdateFileResult);
            this.panel1.Location = new System.Drawing.Point(13, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 384);
            this.panel1.TabIndex = 2;
            // 
            // dgvUpdateFileResult
            // 
            this.dgvUpdateFileResult.AllowUserToAddRows = false;
            this.dgvUpdateFileResult.AllowUserToDeleteRows = false;
            this.dgvUpdateFileResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateFileResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpdateFileResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateFileResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FilePath,
            this.IsSuccess,
            this.ErrorMsg});
            this.dgvUpdateFileResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpdateFileResult.Location = new System.Drawing.Point(0, 0);
            this.dgvUpdateFileResult.Name = "dgvUpdateFileResult";
            this.dgvUpdateFileResult.ReadOnly = true;
            this.dgvUpdateFileResult.RowHeadersVisible = false;
            this.dgvUpdateFileResult.RowTemplate.Height = 23;
            this.dgvUpdateFileResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateFileResult.Size = new System.Drawing.Size(829, 384);
            this.dgvUpdateFileResult.TabIndex = 3;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.FillWeight = 60F;
            this.FileName.HeaderText = "文件名称";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "相对路径";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            // 
            // IsSuccess
            // 
            this.IsSuccess.DataPropertyName = "IsSuccess";
            this.IsSuccess.FillWeight = 80F;
            this.IsSuccess.HeaderText = "是否成功(True/False)";
            this.IsSuccess.Name = "IsSuccess";
            this.IsSuccess.ReadOnly = true;
            // 
            // ErrorMsg
            // 
            this.ErrorMsg.DataPropertyName = "ErrorMsg";
            this.ErrorMsg.FillWeight = 50F;
            this.ErrorMsg.HeaderText = "消息";
            this.ErrorMsg.Name = "ErrorMsg";
            this.ErrorMsg.ReadOnly = true;
            this.ErrorMsg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ErrorMsg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UpdateFileResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 479);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateFileResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新结果";
            this.Load += new System.EventHandler(this.UpdateFileResult_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateFileResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFailFilesCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSuccessFilesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUploadUpdateFilesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUpdateFileResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSuccess;
        private System.Windows.Forms.DataGridViewLinkColumn ErrorMsg;
    }
}