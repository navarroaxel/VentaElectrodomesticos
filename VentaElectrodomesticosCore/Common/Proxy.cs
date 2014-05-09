using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Se encarga de localizar servicios.
    /// </summary>
    public static class Proxy
    {
        /// <summary>
        /// Localiza y retorna el servicio buscado.
        /// </summary>
        /// <typeparam name="TRepository">Servicio a buscar.</typeparam>
        /// <returns>Instancia del tipo de servicio buscado.</returns>
        public static IClientProxy<TService> It<TService>() where TService : class
        {
            return new ClientProxy<TService>(ServiceLocator.Intance.Resolve<TService>());
        }
    }
}
