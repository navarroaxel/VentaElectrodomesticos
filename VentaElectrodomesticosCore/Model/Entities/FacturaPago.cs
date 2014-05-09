using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class FacturaPago
    {
        public int Id { get; set; }
        public int FacturaNro { get; set; }
        public int DniCliente { get; set; }
        public int DniEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public int Cuotas { get; set; }
        public double Monto { get; set; }
    }
}
