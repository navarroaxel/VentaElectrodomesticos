using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    [System.Diagnostics.DebuggerDisplay("{Id}:{Nombre} - {PadreCategoriaId}")]
    public class Categoria : IKeyValueEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? PadreCategoriaId { get; set; }

        public Categoria[] Children { get; set; }

        string IKeyValueEntity.Descripcion { get { return Nombre; } }
    }
}
