using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Core.Model.Entities
{
    public class Usuario : ICrudEntity<Usuario>, ILogicalRemovableEntity
    {
        public int DniEmpleado { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Intentos { get; set; }
        public Empleado Empleado { get; set; }
        public int[] Roles { get; set; }
        public bool Activo { get; set; }

        int ICrudEntity<Usuario>.Id { get { return DniEmpleado; } }

        internal void Login(string password)
        {
            if (!Activo)
            {
                throw new BusinessException(MessageProvider.UsuarioConBaja);
            }

            if (!Empleado.Activo)
            {
                throw new BusinessException(MessageProvider.EmpleadoConBaja);
            }

            if (Intentos >= 3)
            {
                throw new BusinessException(MessageProvider.UsuarioInhabilitadoInicioSesion);
            }

            if (String.Compare(password, Password, StringComparison.OrdinalIgnoreCase) != 0)
            {
                Repository.LocateIt<IUsuariosRepository>().SetIntentos(DniEmpleado, ++Intentos);

                if (Intentos == 3)
                {
                    throw new BusinessException(MessageProvider.MuchosIntentosBlock);
                }

                throw new BusinessException(MessageProvider.PasswordInvalido);
            }

            if (Intentos > 0)
            {
                Repository.LocateIt<IUsuariosRepository>().SetIntentos(DniEmpleado, Intentos = 0);
            }
        }

        void Validate()
        {
            var requiredFields = new List<string>();

            if (DniEmpleado <= 0)
                requiredFields.Add(MessageProvider.Empleado);
            if (String.IsNullOrEmpty(Username))
                requiredFields.Add(MessageProvider.Username);
            if (String.IsNullOrEmpty(Password))
                requiredFields.Add(MessageProvider.Password);
            if (Roles == null || Roles.Length == 0)
                requiredFields.Add(MessageProvider.Roles);

            if (requiredFields.Count > 0)
                throw new BusinessException(MessageProviderExtensions.RequiredFields(String.Join("\n", requiredFields.ToArray())));

            var usuario = Repository.LocateIt<IUsuariosRepository>().GetByUsername(Username);
            if (Username != null && usuario.DniEmpleado != DniEmpleado)
                throw new BusinessException(MessageProvider.UsernameInUse);
        }

        void ICrudEntity<Usuario>.Save()
        {
            Validate();
            Repository.LocateIt<IUsuariosRepository>().Add(this);
        }

        void ICrudEntity<Usuario>.Update(Usuario entity)
        {
            if (!Activo)
                throw new BusinessException(MessageProvider.ErrorUpdateUsuarioDisabled);

            Password = entity.Password;
            Roles = entity.Roles;

            Repository.LocateIt<IUsuariosRepository>().Update(entity);
        }

        void ICrudEntity<Usuario>.Enable()
        {
            if (!Activo)
                Repository.LocateIt<IUsuariosRepository>().SetEnable(DniEmpleado, true);
        }

        void ICrudEntity<Usuario>.Disable()
        {
            if (Activo)
                Repository.LocateIt<IUsuariosRepository>().SetEnable(DniEmpleado, false);
        }

        /// <summary>
        /// Retorna los permisos del usuario.
        /// </summary>
        /// <returns></returns>
        internal int[] GetPermisos()
        {
            var funcionalidades = Repository.LocateIt<IRolesRepository>().GetPermisosByUsuario(DniEmpleado);

            if (funcionalidades.IsNullOrEmpty())
                throw new BusinessException(MessageProvider.UsuarioSinPermisos);

            //Los analistas no pueden facturar ni registrar pagos.
            if (Empleado.TipoEmpleadoId == (int)TipoEmpleadoEnum.Analista)
                funcionalidades = funcionalidades.Where(x => x != 7 && x != 8).ToArray();

            if (funcionalidades.IsNullOrEmpty())
                throw new BusinessException(MessageProvider.UsuarioSinPermisos);

            return funcionalidades;
        }
    }
}
