using System.Data;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa un servicio para la gestion de clientes.
    /// </summary>
    sealed class ClienteService : CrudService<Cliente, IClientesRepository>, IClienteService
    {
        /// <summary>
        /// Retorna los clientes premium de la sucursal y año seleccionados.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de los clientes premium.</returns>
        DataTable IClienteService.GetClientesPremium(int sucursalId, int anio)
        {
            return Repository.LocateIt<IClientesRepository>().GetClientesPremium(sucursalId, anio);
        }
    }
}
