using System;
using VentaElectrodomesticos.Core.Common;
using System.Windows.Forms;
using System.Data.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Common
{
    /// <summary>
    /// Helper para el manejo de excepciones.
    /// </summary>
    public static class Try
    {
        /// <summary>
        /// Metodo que trata de ejecutar el accion.
        /// </summary>
        /// <param name="action">Metodo a ejecutar.</param>
        public static void It(Action action)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                action();
            }
            catch (BusinessException ex)
            {
                MsgBox.ShowError(ex.Message);
            }
            catch (DbException ex)
            {
                MsgBox.ShowError(MessageProvider.DbError);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
