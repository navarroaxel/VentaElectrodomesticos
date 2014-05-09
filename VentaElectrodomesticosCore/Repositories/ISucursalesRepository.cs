using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model.Containers;
using System.Data;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de sucursales.
    /// </summary>
    interface ISucursalesRepository
    {
        /// <summary>
        /// Retorna las sucursales registradas en el sistema.
        /// </summary>
        /// <returns>Coleccion de sucursales.</returns>
        Sucursal[] List();
        /// <summary>
        /// Retorna los filtros necesarios para buscar sucursales.
        /// </summary>
        /// <returns>Filtros de sucursales.</returns>
        SucursalFiltros GetFiltros();
        /// <summary>
        /// Retorna el tablero de control de la sucursal y el año seleccionado.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Informacion de los datos del tablero de control.</returns>
        TableroControlInfo GetTableControl(int sucursalId, int anio);
    }
}
