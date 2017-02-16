using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace AutoUpdateServiceHost
{
    [RunInstaller(true)]
    public partial class AutoUpdateServiceInstaller : System.Configuration.Install.Installer
    {
        public AutoUpdateServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
