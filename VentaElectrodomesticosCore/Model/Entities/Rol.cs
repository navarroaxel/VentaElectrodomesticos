using System;
using System.Collections.Generic;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Rol : ICrudEntity<Rol>, ILogicalRemovableEntity, IKeyValueEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int[] Funcionalidades { get; set; }
        string IKeyValueEntity.Descripcion { get { return Nombre; } }

        void Validate()
        {
            var requiredFields = new List<string>(9);

            if (String.IsNullOrEmpty(Nombre))
                requiredFields.Add(MessageProvider.Nombre);
            if (Funcionalidades == null || Funcionalidades.Length == 0)
                requiredFields.Add(MessageProvider.Funcionalidades);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }

        void ICrudEntity<Rol>.Save()
        {
            Validate();
            Repository.LocateIt<IRolesRepository>().Add(this);
        }

        void ICrudEntity<Rol>.Update(Rol entity)
        {
            if (!Activo)
                throw new BusinessException(MessageProvider.ErrorUpdateRolDisabled);

            Nombre = entity.Nombre;
            Funcionalidades = entity.Funcionalidades;

            Validate();
            Repository.LocateIt<IRolesRepository>().Update(entity);
        }

        void ICrudEntity<Rol>.Enable()
        {
            if (!Activo)
                Repository.LocateIt<IRolesRepository>().SetEnable(Id, true);
        }

        void ICrudEntity<Rol>.Disable()
        {
            if (Activo)
                Repository.LocateIt<IRolesRepository>().SetEnable(Id, false);
        }
    }
}
