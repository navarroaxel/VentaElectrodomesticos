using VentaElectrodomesticos.Core.Repositories;
using Autofac;

namespace VentaElectrodomesticos.Core.Common
{
    /// <summary>
    /// Clase localizadora de repositorios.
    /// </summary>
    class RepositoryLocator
    {
        /// <summary>
        /// Objeto para sincronizacion de concurrencias.
        /// </summary>
        private static object _sync = new object();
        /// <summary>
        /// Instancia del localizador de repositorios.
        /// </summary>
        private static RepositoryLocator _instance;
        /// <summary>
        /// Obtiene la instancia del localizador de repositorios actual.
        /// </summary>
        public static RepositoryLocator Intance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                            _instance = new RepositoryLocator(RepositoriesContainer.RegisterServices());
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// Contenedor de repositorios.
        /// </summary>
        public IContainer Container { get; set; }

        /// <summary>
        /// Crea una instancia del localizador de repositorios.
        /// </summary>
        /// <param name="container">Contenedor de repositorios.</param>
        public RepositoryLocator(IContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// Retorna una instancia del tipo de repositorio buscado.
        /// </summary>
        /// <typeparam name="TService">Tipo de repositorio buscado.</typeparam>
        /// <returns>Instancia del tipo de repositorio buscado.</returns>
        public TService Resolve<TService>()
        {
            if (Container.IsRegistered<TService>())
                return Container.Resolve<TService>();

            return default(TService);
        }
    }
}
