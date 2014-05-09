using System.Data;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad Cliente.
    /// </summary>
    internal interface IClientesRepository : ICrudRepository<Cliente>
    {
        /// <summary>
        /// Retorna los clientes premium de la sucursal y año seleccionados.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de los clientes premium.</returns>
        DataTable GetClientesPremium(int sucursalId, int anio);
    }
}
