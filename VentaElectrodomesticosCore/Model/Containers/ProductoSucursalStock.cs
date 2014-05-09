using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Model.Containers
{
    public class ProductoSucursalStock
    {
        public Producto Producto { get; set; }
        public ProductoStock Stock { get; set; }
    }
}
