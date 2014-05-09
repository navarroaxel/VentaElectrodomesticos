using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Helper para el manejo de transacciones.
    /// </summary>
    internal static class Transact
    {
        /// <summary>
        /// Metodo que trata de realizar la accion y comitear la transaccion si no hubo errores.
        /// </summary>
        /// <param name="action">Metodo a ejecutar</param>
        public static void It(Action action)
        {
            using (var scope = new TransactionScope())
            {
                action();
                scope.Complete();
            }
        }
    }
}
