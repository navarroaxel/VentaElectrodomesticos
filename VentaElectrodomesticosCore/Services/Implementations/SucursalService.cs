using System.Data;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Containers;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa operaciones del servicio de la entidad sucursal.
    /// </summary>
    class SucursalService : ISucursalService
    {
        /// <summary>
        /// Retorna la coleccion de sucursales del sistema.
        /// </summary>
        /// <returns>Coleccion de Sucursales.</returns>
        Sucursal[] ISucursalService.List()
        {
            return Repository.LocateIt<ISucursalesRepository>().List();
        }
        /// <summary>
        /// Retorna la lista de sucursales en las que puede operar el usuario.
        /// </summary>
        /// <param name="p">Dni del usuario loggeado.</param>
        /// <returns>Coleccion de sucursales.</returns>
        Sucursal[] ISucursalService.ListByEmpleado(int dniEmpleado)
        {
            var empleado = Repository.LocateIt<IEmpleadosRepository>().Get(dniEmpleado);
            return empleado.GetSucursalesPronvinciasParaOperar().Sucursales;
        }

        /// <summary>
        /// Retorna los filtros necesarios para buscar una sucursal.
        /// </summary>
        /// <param name="dniEmpleado">Dni del usuario loggueado.</param>
        /// <returns>Filtros para buscar sucursales.</returns>
        SucursalFiltros ISucursalService.GetFiltros(int dniEmpleado)
        {
            var empleado = Repository.LocateIt<IEmpleadosRepository>().Get(dniEmpleado);
            return empleado.GetSucursalesPronvinciasParaOperar();
        }

        /// <summary>
        /// Retorna el tablero de control de la sucursal y el año seleccionado.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Informacion de los datos del tablero de control.</returns>
        TableroControlInfo ISucursalService.GetTableroControl(int sucursalId, int anio)
        {
            return Repository.LocateIt<ISucursalesRepository>().GetTableControl(sucursalId, anio);
        }
    }
}
