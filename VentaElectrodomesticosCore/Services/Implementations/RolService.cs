using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Repsenta un servicio de gestion de roles de usuarios.
    /// </summary>
    sealed class RolService : CrudService<Rol, IRolesRepository>, IRolService
    {
        /// <summary>
        /// Retorna las funcionalidades del sistema.
        /// </summary>
        /// <returns>Coleccion de funcionalidades.</returns>
        Funcionalidad[] IRolService.ListFuncionalidades()
        {
            return Repository.LocateIt<IFuncionalidadesRepository>().List();
        }

        /// <summary>
        /// Retorna los roles del usuario.
        /// </summary>
        /// <param name="dniUsuario">DNI del usuario.</param>
        /// <returns>Coleccion de roles.</returns>
        Rol[] IRolService.GetByUsuario(int dniUsuario)
        {
            return Repository.LocateIt<IRolesRepository>().GetByUsuario(dniUsuario);
        }

        /// <summary>
        /// Obtiene los permisos de un usuario.
        /// </summary>
        /// <param name="dniUsuario">Dni del usuario a consultar.</param>
        /// <returns>Permisos concedidos al usuario.</returns>
        int[] IRolService.GetPermisos(int dniUsuario)
        {
            var usuario = Repository.LocateIt<IUsuariosRepository>().Get(dniUsuario);
            return usuario.GetPermisos();
        }
    }
}
