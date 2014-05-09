using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio para la entidad Factura.
    /// </summary>
    sealed class FacturasRepository : BaseRepository, IFacturasRepository
    {
        Func<object[], Factura> Mapper
        {
            get
            {
                return values => new Factura
                {
                    Nro = (int)values[0],
                    Fecha = (DateTime)values[1],
                    DniCliente = (int)values[2],
                    DniEmpleado = (int)values[3],
                    SucursalId = (int)values[4],
                    FormaPagoId = (int)values[5],
                    Cuotas = (int)values[6],
                    Subtotal = (double)values[7],
                    Descuento = (double)values[8],
                    Total = (double)values[9],
                    CuotasRestantes = (int)values[10]
                };
            }
        }

        /// <summary>
        /// Retorna una factura por su numero.
        /// </summary>
        /// <param name="facturaNro">Numero de la factura.</param>
        /// <returns>Instancia de la factura buscada.</returns>
        Factura IFacturasRepository.Get(int nro)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetFactura, Mapper, nro);
        }

        /// <summary>
        /// Registra una factura en el sistema.
        /// </summary>
        /// <param name="factura">Informacion de la factura.</param>
        /// <returns>Numero de la factura.</returns>
        int IFacturasRepository.Add(Factura factura)
        {
            return ExecuteReaderSingle(StoredProcedureNames.AddFactura,
                values => Convert.ToInt32(values[0]),
                factura.Fecha,
                factura.DniCliente,
                factura.DniEmpleado,
                factura.SucursalId,
                factura.FormaPagoId,
                factura.Cuotas,
                factura.Subtotal,
                factura.Descuento,
                factura.Total);
        }
        
        /// <summary>
        /// Registra un producto para una factura.
        /// </summary>
        /// <param name="producto">Informacion del producto.</param>
        void IFacturasRepository.AddProducto(FacturaProducto producto)
        {
            ExecuteNonQuery(StoredProcedureNames.AddFacturaProducto,
                producto.FacturaId,
                producto.ProductoId,
                producto.Cantidad,
                producto.PrecioUnitario);
        }

        /// <summary>
        /// Retorna todas las facturas impagas.
        /// </summary>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <param name="dniCliente">DNI del cliente.</param>
        /// <returns>Coleccion de facturas impagas.</returns>
        Factura[] IFacturasRepository.GetFacturasImpagas(int sucursalId, int dniCliente)
        {
            return ExecuteReader(StoredProcedureNames.GetFacturasImpagas,
                Mapper,
                sucursalId,
                dniCliente);
        }

        /// <summary>
        /// Registra un pago para una factura.
        /// </summary>
        /// <param name="facturaPago">Informacion del pago.</param>
        void IFacturasRepository.AddPago(FacturaPago pago)
        {
            ExecuteNonQuery(StoredProcedureNames.AddFacturaPago,
                pago.FacturaNro,
                pago.DniCliente,
                pago.DniEmpleado,
                pago.Fecha,
                pago.Cuotas,
                pago.Monto);
        }
    }
}
