using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Repositories;

namespace VentaElectrodomesticos.Core.Services.Implementations
{
    /// <summary>
    /// Representa un servico para la gestion de Usuarios.
    /// </summary>
    sealed class UsuarioService : CrudService<Usuario, IUsuariosRepository>, IUsuarioService
    {
    }
}
