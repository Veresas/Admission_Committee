using System;
using System.Windows.Forms;
using Manager;
using Microsoft.Extensions.Logging;
using Storege;
using static Microsoft.Extensions.Logging.ILoggerFactory;

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

            var factory = LoggerFactory.Create(builder => builder.AddDebug());
            ILogger logger = factory.CreateLogger("Program");

            var storage = new StudentStorage();
            var manager = new StudentManager(storage);
            Application.Run(new MainForm(manager, logger));
        }
    }
}
