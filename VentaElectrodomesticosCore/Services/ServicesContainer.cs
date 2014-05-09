using Autofac;
using VentaElectrodomesticos.Core.Services.Implementations;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Registra los servicios.
    /// </summary>
    internal static class ServicesContainer
    {
        /// <summary>
        /// Retorna un Container con todos los servicios registrados.
        /// </summary>
        /// <returns>Contenedor de servicios.</returns>
        public static IContainer RegisterServices()
        {
            var container = new ContainerBuilder();

            container.Register(x => new EmpleadoService()).As<IEmpleadoService>();
            container.Register(x => new ClienteService()).As<IClienteService>();
            container.Register(x => new UsuarioService()).As<IUsuarioService>();
            container.Register(x => new ProductoService()).As<IProductoService>();
            container.Register(x => new RolService()).As<IRolService>();
            container.Register(x => new LoginService()).As<ILoginService>();
            container.Register(x => new ProvinciaService()).As<IProvinciaService>();
            container.Register(x => new SucursalService()).As<ISucursalService>();
            container.Register(x => new CategoriaService()).As<ICategoriaService>();
            container.Register(x => new FacturaService()).As<IFacturaService>();

            return container.Build();
        }
    }
}
