using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.Portal;

namespace AutoUpdateServerManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UpdateSystem.Update(new AutoUpdateServiceManager(), ClientType.Server);
        }
    }
}
