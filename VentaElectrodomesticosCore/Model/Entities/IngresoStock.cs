using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class IngresoStock
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int SucursalId { get; set; }
        public int ProductoId { get; set; }
        public int DniEmpleado { get; set; }
        public int Cantidad { get; set; }

        internal void Validate()
        {
            var requiredFields = new List<string>(9);

            if (SucursalId <= 0)
                requiredFields.Add(MessageProvider.Sucursal);
            if (ProductoId <= 0)
                requiredFields.Add(MessageProvider.Producto);
            if (DniEmpleado<=0)
                requiredFields.Add(MessageProvider.Empleado);
            if (Cantidad <= 0)
                requiredFields.Add(MessageProvider.Cantidad);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }
    }
}
