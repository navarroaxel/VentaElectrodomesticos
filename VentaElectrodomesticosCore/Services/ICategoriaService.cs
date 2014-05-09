using VentaElectrodomesticos.Core.Model.Entities;
using System.Data;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de la entidad Categoria.
    /// </summary>
    public interface ICategoriaService
    {
        /// <summary>
        /// Retorna las categorias del sistema.
        /// </summary>
        /// <returns>Coleccion de categorias.</returns>
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
