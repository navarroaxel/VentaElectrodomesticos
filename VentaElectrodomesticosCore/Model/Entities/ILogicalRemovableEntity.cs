using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public interface ILogicalRemovableEntity
    {
        bool Activo { get; set; }
    }
}
