using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Se encarga de localizar repositorios.
    /// </summary>
    internal static class Repository
    {
        /// <summary>
        /// Localiza y retorna el repositorio buscado.
        /// </summary>
        /// <typeparam name="TRepository">Repositorio a buscar.</typeparam>
        /// <returns>Instancia del tipo de repositorio buscado.</returns>
        public static TRepository LocateIt<TRepository>()
        {
            return RepositoryLocator.Intance.Resolve<TRepository>();
        }
    }
}
