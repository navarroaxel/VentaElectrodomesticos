using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de facturas.
    /// </summary>
    public interface IFacturaService
    {
        /// <summary>
        /// Registra una factura en el sistema.
        /// </summary>
        /// <param name="factura">Factura a registrar.</param>
        /// <param name="productos">Productos a comprar con la factura.</param>
        /// <returns>Numero de la factura.</returns>
        int Add(Factura factura, FacturaProducto[] productos);
        /// <summary>
        /// Retorna las facturas impagas.
        /// </summary>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <param name="dniCliente">Dni del Cliente</param>
        /// <returns></returns>
        Factura[] GetFacturasImpagas(int sucursalId, int dniCliente);
        /// <summary>
        /// Registra un pago en el sistema.
        /// </summary>
        /// <param name="facturaNro">Numero de la factura.</param>
        /// <param name="cuotas">Cuotas a pagar.</param>
        /// <param name="dniEmpleado">DNI del empleado.</param>
        void AddPago(int facturaNro, int cuotas, int dniEmpleado);
    }
}
