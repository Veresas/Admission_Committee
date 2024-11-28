using System;
using System.Windows.Forms;
using Manager;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;
using Serilog;
using Storege;
using static Microsoft.Extensions.Logging.ILoggerFactory;
using Database;

namespace Admission_Committee
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq("http://localhost:5341", apiKey: "1rgZvYsfVjUgJgILEuWz")
                .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger).CreateLogger("datagrid");

            var storage = new DBase();
            var manager = new StudentManager(storage, logger);
            Application.Run(new MainForm(manager));
        }
    }
}
