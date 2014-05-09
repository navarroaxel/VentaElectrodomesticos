using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Sucursal : IKeyValueEntity
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public int TipoSucursalId { get; set; }
        public int ProvinciaId { get; set; }
        public string Telefono { get; set; }

        string IKeyValueEntity.Descripcion { get { return Direccion; } }
    }
}
