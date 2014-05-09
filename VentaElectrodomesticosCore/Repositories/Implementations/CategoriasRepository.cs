using VentaElectrodomesticos.Core.Model.Entities;
using System;
using System.Data;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    sealed class CategoriasRepository : BaseRepository, ICategoriasRepository
    {
        /// <summary>
        /// Retorna las categorias del sistema.
        /// </summary>
        /// <returns></returns>
        Categoria[] ICategoriasRepository.List()
        {
            return ExecuteReader(StoredProcedureNames.GetCategorias,
                values => new Categoria
                {
                    Id = (int)values[0],
                    Nombre = (string)values[1],
                    PadreCategoriaId = values[2] != DBNull.Value ? (int?)values[2] : null 
                });
        }

        /// <summary>
        /// Retorna los datos de las mejores categorias del Año y Sucursal.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de las mejores categorias.</returns>
        DataTable ICategoriasRepository.GetMejoresCategorias(int sucursalId, int anio)
        {
            return ExecuteDataTable(StoredProcedureNames.GetMejoresCategorias, sucursalId, anio);
        }
    }
}
