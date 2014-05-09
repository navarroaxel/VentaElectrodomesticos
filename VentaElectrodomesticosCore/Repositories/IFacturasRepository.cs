using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para un repositorio de la entidad Factura.
    /// </summary>
    internal interface IFacturasRepository
    {
        /// <summary>
        /// Retorna todas las facturas impagas.
        /// </summary>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <param name="dniCliente">DNI del cliente.</param>
        /// <returns>Coleccion de facturas impagas.</returns>
        Factura[] GetFacturasImpagas(int sucursalId, int dniCliente);
        /// <summary>
        /// Retorna una factura por su numero.
        /// </summary>
        /// <param name="facturaNro">Numero de la factura.</param>
        /// <returns>Instancia de la factura buscada.</returns>
        Factura Get(int facturaNro);
        /// <summary>
        /// Registra un pago para una factura.
        /// </summary>
        /// <param name="facturaPago">Informacion del pago.</param>
        void AddPago(FacturaPago facturaPago);
        /// <summary>
        /// Registra una factura en el sistema.
        /// </summary>
        /// <param name="factura">Informacion de la factura.</param>
        /// <returns>Numero de la factura.</returns>
        int Add(Factura factura);
        /// <summary>
        /// Registra un producto para una factura.
        /// </summary>
        /// <param name="producto">Informacion del producto.</param>
        void AddProducto(FacturaProducto producto);
    }
}
