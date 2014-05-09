using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa un servio para la entidad Facturas.
    /// </summary>
    sealed class FacturaService : IFacturaService
    {
        /// <summary>
        /// Registra una factura en el sistema.
        /// </summary>
        /// <param name="factura">Factura a registrar.</param>
        /// <param name="productos">Productos a comprar con la factura.</param>
        /// <returns>Numero de la factura.</returns>
        int IFacturaService.Add(Factura factura, FacturaProducto[] productos)
        {
            factura.Save(productos);
            return factura.Nro;
        }

        /// <summary>
        /// Retorna las facturas impagas.
        /// </summary>
        /// <param name="sucursalId">Id de la sucursal.</param>
        /// <param name="dniCliente">Dni del Cliente</param>
        /// <returns></returns>
        Factura[] IFacturaService.GetFacturasImpagas(int sucursalId, int dniCliente)
        {
            return Repository.LocateIt<IFacturasRepository>().GetFacturasImpagas(sucursalId, dniCliente);
        }

        /// <summary>
        /// Registra un pago en el sistema.
        /// </summary>
        /// <param name="facturaNro">Numero de la factura.</param>
        /// <param name="cuotas">Cuotas a pagar.</param>
        /// <param name="dniEmpleado">DNI del empleado.</param>
        void IFacturaService.AddPago(int facturaNro, int cuotas, int dniEmpleado)
        {
            var factura = Repository.LocateIt<IFacturasRepository>().Get(facturaNro);
            if (factura == null)
                throw new BusinessException(MessageProvider.FacturaNotExist);

            factura.AddPago(cuotas, dniEmpleado);
        }
    }
}
