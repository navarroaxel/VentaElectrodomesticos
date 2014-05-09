using System.Data;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de categorias de productos.
    /// </summary>
    internal interface ICategoriasRepository
    {
        /// <summary>
        /// Retorna las categorias del sistema.
        /// </summary>
        /// <returns></returns>
        Categoria[] List();
        /// <summary>
        /// Retorna los datos de las mejores categorias del Año y Sucursal.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de las mejores categorias.</returns>
        DataTable GetMejoresCategorias(int sucursalId, int anio);
    }
}
