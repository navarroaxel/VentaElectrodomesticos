using VentaElectrodomesticos.Core.Services;
using Autofac;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Clase localizadora de servicios.
    /// </summary>
    class ServiceLocator
    {
        /// <summary>
        /// Objeto para sincronizacion de concurrencias.
        /// </summary>
        private static object _sync = new object();
        /// <summary>
        /// Instancia del localizador de servicios.
        /// </summary>
        private static ServiceLocator _instance;
        /// <summary>
        /// Obtiene la instancia del localizador de servicios actual.
        /// </summary>
        public static ServiceLocator Intance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                            _instance = new ServiceLocator(ServicesContainer.RegisterServices());
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Contenedor de servicios.
        /// </summary>
        public IContainer Container { get; set; }

        /// <summary>
        /// Crea una instancia del localizador de servicios.
        /// </summary>
        /// <param name="container">Contenedor de servicios.</param>
        public ServiceLocator(IContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// Retorna una instancia del tipo de servicio buscado.
        /// </summary>
        /// <typeparam name="TService">Tipo de servicio buscado.</typeparam>
        /// <returns>Instancia del tipo de servicio buscado.</returns>
        public TService Resolve<TService>()
        {
            if (Container.IsRegistered<TService>())
                return Container.Resolve<TService>();

            return default(TService);
        }
    }
}
