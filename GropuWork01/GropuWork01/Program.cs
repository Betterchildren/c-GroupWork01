﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GropuWork01
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
            frmLogin fl = new frmLogin();
            fl.ShowDialog();
            Application.Run(new frmMain());
        }
        public static string name = "";
    }
}