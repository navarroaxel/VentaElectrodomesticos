using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Services
{
    /// <summary>
    /// Define metodos para el servio para el login de usuarios.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Realiza el login del usuario
        /// </summary>
        /// <param name="username">nombre de usuario.</param>
        /// <param name="password">password del usuario.</param>
        /// <returns>Datos del usuario loggueado.</returns>
        Usuario Login(string username, string password);
    }
}
