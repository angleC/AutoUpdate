using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Update
{
    public partial class UpdateDescription : Form
    {
        private string updateDescription = string.Empty;
        
        public UpdateDescription(string updateDescription)
        {
            // TODO: Complete member initialization
            InitializeComponent();

            this.updateDescription = updateDescription;
        }

        private void UpdateDescription_Load(object sender, EventArgs e)
        {
            this.txtMessage.Text = this.updateDescription;
        }
    }
}
