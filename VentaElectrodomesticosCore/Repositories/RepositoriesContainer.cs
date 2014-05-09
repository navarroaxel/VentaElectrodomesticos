using Autofac;
using VentaElectrodomesticos.Core.Repositories.Implementations;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Registra los repositorios.
    /// </summary>
    internal static class RepositoriesContainer
    {
        /// <summary>
        /// Retorna un Container con todos los repositorios registrados.
        /// </summary>
        /// <returns>Contenedor de repositorios.</returns>
        public static IContainer RegisterServices()
        {
            var container = new ContainerBuilder();

            container.Register(x => new EmpleadosRepository()).As<IEmpleadosRepository>();
            container.Register(x => new UsuariosRepository()).As<IUsuariosRepository>();
            container.Register(x => new ClientesRepository()).As<IClientesRepository>();
            container.Register(x => new RolesRepository()).As<IRolesRepository>();
            container.Register(x => new ProductosRepository()).As<IProductosRepository>();
            container.Register(x => new ProvinciasRepository()).As<IProvinciasRepository>();
            container.Register(x => new SucursalesRepository()).As<ISucursalesRepository>();
            container.Register(x => new FuncionalidadesRepository()).As<IFuncionalidadesRepository>();
            container.Register(x => new CategoriasRepository()).As<ICategoriasRepository>();
            container.Register(x => new FacturasRepository()).As<IFacturasRepository>();

            return container.Build();
        }
    }
}
