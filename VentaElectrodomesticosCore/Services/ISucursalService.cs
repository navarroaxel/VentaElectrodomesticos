using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model.Containers;
using System.Data;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servio de la entidad Sucursal.
    /// </summary>
    public interface ISucursalService
    {
        /// <summary>
        /// Retorna la coleccion de sucursales del sistema.
        /// </summary>
        /// <returns>Coleccion de Sucursales.</returns>
        Sucursal[] List();
        /// <summary>
        /// Retorna los filtros necesarios para buscar una sucursal.
        /// </summary>
        /// <param name="dniEmpleado">Dni del usuario loggueado.</param>
        /// <returns>Filtros para buscar sucursales.</returns>
        SucursalFiltros GetFiltros(int dniEmpleado);
        /// <summary>
        /// Retorna el table de control de la sucursal y el año seleccionado.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Informacion de los datos del tablero de control.</returns>
        TableroControlInfo GetTableroControl(int sucursalId, int anio);
        /// <summary>
        /// Retorna la lista de sucursales en las que puede operar el usuario.
        /// </summary>
        /// <param name="p">Dni del usuario loggeado.</param>
        /// <returns>Coleccion de sucursales.</returns>
        Sucursal[] ListByEmpleado(int dniEmpleado);
    }
}
