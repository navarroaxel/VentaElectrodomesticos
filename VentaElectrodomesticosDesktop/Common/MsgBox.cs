using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.Desktop.Common
{
    /// <summary>
    /// Helper para message box pre armados.
    /// </summary>
    public static class MsgBox
    {
        /// <summary>
        /// Muestra una mensaje de informacion.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un mensaje de advertencia.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        /// <returns>Retorna un booleano indicando si el usuario acepto.</returns>
        public static bool ShowWarning(string message)
        {
            return MessageBox.Show(message, string.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        public static void ShowError(string message)
        {
            MessageBox.Show(message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un mensaje de pregunta
        /// </summary>
        /// <param name="message">Mensaje a mostrar.</param>
        /// <returns>Retorna un booleano indicando si el usuario acepto.</returns>
        public static bool ShowQuestion(string message)
        {
            return MessageBox.Show(message, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
