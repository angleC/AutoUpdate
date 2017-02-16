using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdateServerManagement
{
    public partial class UpdateFileResult : Form
    {
        private List<UpdateFileToServer.UpdateFileResult> ufrList;

        public UpdateFileResult(List<UpdateFileToServer.UpdateFileResult> ufrList)
        {
            InitializeComponent();

            this.ufrList = ufrList;
        }

        private void UpdateFileResult_Load(object sender, EventArgs e)
        {
            this.lblUploadUpdateFilesCount.Text = this.ufrList.Count.ToString();
            this.lblSuccessFilesCount.Text = this.ufrList.Where(x => x.IsSuccess == true).Count().ToString();
            int failFilesCount = this.ufrList.Where(x => x.IsSuccess == false).Count();
            if (failFilesCount > 0)
            {
                this.lblFailFilesCount.ForeColor = Color.Red;
            }
            this.lblFailFilesCount.Text = failFilesCount.ToString();

            this.dgvUpdateFileResult.DataSource = this.ufrList;
        }
    }
}
