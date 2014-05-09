using System;
using System.Data;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de gestion de clientes.
    /// </summary>
    public interface IClienteService : ICrudService<Cliente>
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
