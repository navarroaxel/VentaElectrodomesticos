using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    internal interface ICrudEntity<TEntity>
    {
        int Id { get; }

        void Save();
        void Update(TEntity entity);

        void Enable();
        void Disable();
    }
}
