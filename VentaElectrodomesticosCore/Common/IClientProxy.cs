using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Define metodo para un proxy de servicios.
    /// </summary>
    /// <typeparam name="TContract">Contrato del servicio.</typeparam>
    public interface IClientProxy<TContract> where TContract : class
    {
        /// <summary>
        /// Proxy al servicio.
        /// </summary>
        TContract Proxy { get; }  
    }
}
