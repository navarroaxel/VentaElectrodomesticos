using System;
using System.Collections.Generic;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories
{
    /// <summary>
    /// Define metodos para el repositorio de la entidad usuarios.
    /// </summary>
    internal interface IUsuariosRepository : ICrudRepository<Usuario>
    {
        /// <summary>
        /// Obtiene un usuario por su username.
        /// </summary>
        /// <param name="username">username del usuario a buscar.</param>
        /// <returns>Intancia de Usuario.</returns>
        Usuario GetByUsername(string username);
        /// <summary>
        /// Setea la cantidad de intentos fallidos de inicio de sesion del usuario.
        /// </summary>
        /// <param name="dni">Dni del empleado.</param>
        /// <param name="intentos">Cantidad de intentos fallidos.</param>
        void SetIntentos(int dniEmpleado, int intentos);
    }
}
