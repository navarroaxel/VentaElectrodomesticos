using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Model.Containers
{
    public class EmpleadoFiltros
    {
        public Provincia[] Provincias { get; set; }
        public TipoEmpleado[] TipoEmpleados { get; set; }
        public Sucursal[] Sucursales { get; set; }
    }
}
