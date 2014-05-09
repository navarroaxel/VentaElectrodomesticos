using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Model.Containers
{
    public class SucursalFiltros
    {
        public Provincia[] Provincias { get; set; }
        public Sucursal[] Sucursales { get; set; }
    }
}
