using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AutoUpdateServiceHost
{
    public partial class AutoUpdateService : ServiceBase
    {
        public AutoUpdateService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServerManager.ServerManagerInstance.StartService();

            //ServerManager.StartService();
        }
        
        protected override void OnStop()
        {
            ServerManager.ServerManagerInstance.CloseService();
            //ServerManager.CloseService();
        }
    }
}
