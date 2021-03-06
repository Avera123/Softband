﻿using Softband.Generics;
using Softband.Mae;
using Softband.Maestros;
using Softband.Reports;
using Softband.Reports.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Software de administración de negocios.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new Login());
        }
    }
}
