using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Cliente : ICrudEntity<Cliente>, ILogicalRemovableEntity
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int ProvinciaId { get; set; }
        public bool Activo { get; set; }

        int ICrudEntity<Cliente>.Id { get { return Dni; } }

        void Validate()
        {
            var requiredFields = new List<string>(7);

            if (Dni <= 0)
                requiredFields.Add(MessageProvider.Dni);
            if (String.IsNullOrEmpty(Nombre))
                requiredFields.Add(MessageProvider.Nombre);
            if (String.IsNullOrEmpty(Apellido))
                requiredFields.Add(MessageProvider.Apellido);
            if (String.IsNullOrEmpty(Mail))
                requiredFields.Add(MessageProvider.Mail);
            if (String.IsNullOrEmpty(Direccion))
                requiredFields.Add(MessageProvider.Direccion);
            if (String.IsNullOrEmpty(Telefono))
                requiredFields.Add(MessageProvider.Telefono);
            if (ProvinciaId <= 0)
                requiredFields.Add(MessageProvider.Provincia);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));
        }

        void ICrudEntity<Cliente>.Save()
        {
            var repo = Repository.LocateIt<IClientesRepository>();
            var cliente = repo.Get(Dni);
            if (cliente != null)
                throw new BusinessException(MessageProvider.ExistCliente);

            var empleado = Repository.LocateIt<IEmpleadosRepository>().Get(Dni);
            if (empleado != null)
                throw new BusinessException(MessageProvider.ClienteIsEmpleado);

            Validate();
            repo.Add(this);
        }

        void ICrudEntity<Cliente>.Update(Cliente entity)
        {
            if (!Activo)
                throw new BusinessException(MessageProvider.ErrorUpdateClienteDisabled);

            Nombre = entity.Nombre;
            Apellido = entity.Apellido;
            Mail = entity.Mail;
            Direccion = entity.Direccion;
            Telefono = entity.Telefono;
            ProvinciaId = entity.ProvinciaId;

            Validate();
            Repository.LocateIt<IClientesRepository>().Update(entity);
        }

        void ICrudEntity<Cliente>.Enable()
        {
            if (!Activo)
                Repository.LocateIt<IClientesRepository>().SetEnable(Dni, true);
        }

        void ICrudEntity<Cliente>.Disable()
        {
            if (Activo)
                Repository.LocateIt<IClientesRepository>().SetEnable(Dni, false);
        }
    }
}
