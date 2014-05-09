using System;
using System.Windows.Forms;
using System.Threading;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new Views.Main());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MsgBox.ShowError(MessageProvider.CatastrophicError);
            Application.Exit();
        }
    }
}
