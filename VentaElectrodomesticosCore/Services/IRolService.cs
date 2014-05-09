using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servicio de gestion de roles de usuarios.
    /// </summary>
    public interface IRolService : ICrudService<Rol>
    {
        /// <summary>
        /// Retorna las funcionalidades del sistema.
        /// </summary>
        /// <returns>Coleccion de funcionalidades.</returns>
        Funcionalidad[] ListFuncionalidades();
        /// <summary>
        /// Retorna los roles del usuario.
        /// </summary>
        /// <param name="dniUsuario">DNI del usuario.</param>
        /// <returns>Coleccion de roles.</returns>
        Rol[] GetByUsuario(int dniUsuario);

        /// <summary>
        /// Obtiene los permisos de un usuario.
        /// </summary>
        /// <param name="dniUsuario">Dni del usuario a consultar.</param>
        /// <returns>Permisos concedidos al usuario.</returns>
        int[] GetPermisos(int dniUsuario);
    }
}
