using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Portal;
using AutoUpdate.Tools;
using AutoUpdateServiceAccess;

namespace AutoUpdate.Client
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

            UpdateSystem.Update(new Client(), ClientType.Client);
        }
    }
}
