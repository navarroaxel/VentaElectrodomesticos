using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad Rol.
    /// </summary>
    internal interface IRolesRepository : ICrudRepository<Rol>
    {
        /// <summary>
        /// Retorna los roles del usuario.
        /// </summary>
        /// <param name="dniUsuario">Usuario loggeado en el sistema.</param>
        /// <returns>Coleccion de roles.</returns>
        Rol[] GetByUsuario(int dniUsuario);
        /// <summary>
        /// Retorna los permisos del usuario.
        /// </summary>
        /// <param name="dniUsuario">Usuario loggueado en el sistema.</param>
        /// <returns>Coleccion de permisos.</returns>
        int[] GetPermisosByUsuario(int dniUsuario);
    }
}
