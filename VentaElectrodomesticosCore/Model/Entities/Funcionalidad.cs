using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Funcionalidad : IKeyValueEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
