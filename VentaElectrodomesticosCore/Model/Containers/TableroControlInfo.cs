using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Containers
{
    public class TableroControlInfo
    {
        public int TotalVentas { get; set; }
        public double? TotalFacturacion { get; set; }
        public int? FacturasEfectivo { get; set; }
        public double? MayorFactura { get; set; }
        public string MayorDeudor { get; set; }
        public string VendedorAnio { get; set; }
        public string ProductoAnio { get; set; }
        public string FaltanteStock { get; set; }
    }
}
