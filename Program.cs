using System;
using System.Windows.Forms;
using Framework.Manager;
using Storege.Memory;

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
            var storage = new StudentStorage();
            var manager = new StudentManager(storage);
            Application.Run(new MainForm(manager));
        }
    }
}
