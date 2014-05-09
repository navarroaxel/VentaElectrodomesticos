using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Factura
    {
        public int Nro { get; set; }
        public DateTime Fecha { get; set; }
        public int DniCliente { get; set; }
        public int DniEmpleado { get; set; }
        public int SucursalId { get; set; }
        public int FormaPagoId { get; set; }
        public int Cuotas { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }
        public int CuotasRestantes { get; set; }

        internal void Save(FacturaProducto[] productos)
        {
            Fecha = DateTime.Now;
            if (Cuotas > 1)
            {
                FormaPagoId = (int)FormaPagoEnum.Cuotas;
            }
            else
            {
                FormaPagoId = (int)FormaPagoEnum.Efectivo;
            }

            Validate();

            Transact.It(() =>
            {
                var repo = Repository.LocateIt<IFacturasRepository>();
                Nro = repo.Add(this);

                productos.ForEach(producto =>
                {
                    producto.FacturaId = Nro;
                    repo.AddProducto(producto);
                });

                if (FormaPagoId == (int)FormaPagoEnum.Efectivo)
                    repo.AddPago(new FacturaPago
                    {
                        FacturaNro = Nro,
                        DniCliente = DniCliente,
                        DniEmpleado = DniEmpleado,
                        Fecha = Fecha,
                        Cuotas = Cuotas,
                        Monto = Total
                    });
            });
        }

        private void Validate()
        {
            var requiredFields = new List<string>();

            if (DniCliente <= 0)
                requiredFields.Add(MessageProvider.Cliente);
            if (DniEmpleado <= 0)
                requiredFields.Add(MessageProvider.Empleado);
            if (SucursalId <= 0)
                requiredFields.Add(MessageProvider.Sucursal);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }

        internal void AddPago(int cuotas, int dniEmpleado)
        {
            if (CuotasRestantes == 0)
                throw new BusinessException(MessageProvider.FacturaPaid);

            if (cuotas > CuotasRestantes)
                throw new BusinessException(MessageProvider.InvalidCuotas);

            Repository.LocateIt<IFacturasRepository>().AddPago(new FacturaPago
            {
                FacturaNro = Nro,
                DniCliente = DniCliente,
                DniEmpleado = dniEmpleado,
                Fecha = DateTime.Now,
                Cuotas = cuotas,
                Monto = Total / Cuotas * cuotas
            });
        }
    }
}
