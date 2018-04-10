﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;

namespace Vueling.Presentation.WinSite
{
    static class Inicio
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
         static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            log4net.Config.XmlConfigurator.Configure();


            Application.Run(new Menu());
            Log.CloseAndFlush();

        }


    }
}
