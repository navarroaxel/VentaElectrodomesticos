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
    /// Representa un servio para el login de usuarios.
    /// </summary>
    sealed class LoginService : ILoginService
    {
        /// <summary>
        /// Realiza el login del usuario
        /// </summary>
        /// <param name="username">nombre de usuario.</param>
        /// <param name="password">password del usuario.</param>
        /// <returns>Datos del usuario loggueado.</returns>
        Usuario ILoginService.Login(string username, string password)
        {
            var usuario = Repository.LocateIt<IUsuariosRepository>().GetByUsername(username);
            if (usuario == null)
            {
                throw new BusinessException(MessageProvider.UsernameInvalido);
            }

            usuario.Login(password);
            return usuario;
        }
    }
}
