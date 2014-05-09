using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Proxy de servicios.
    /// </summary>
    /// <typeparam name="TContract">Contrato del servicio.</typeparam>
    class ClientProxy<TContract> : IClientProxy<TContract> where TContract : class
    {
        /// <summary>
        /// Instancia del servicio.
        /// </summary>
        TContract _proxy;
        /// <summary>
        /// Retorna el servicio.
        /// </summary>
        TContract IClientProxy<TContract>.Proxy { get { return _proxy; } }

        /// <summary>
        /// Crea una instancia del proxy de servicios.
        /// </summary>
        /// <param name="contract">Instancia del servicio.</param>
        public ClientProxy(TContract contract)
        {
            _proxy = contract;
        }
    }
}
