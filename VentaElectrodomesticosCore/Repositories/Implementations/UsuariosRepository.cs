using System;
using System.Data;
using System.Linq;
using VentaElectrodomesticos.Core.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio de la entidad usuarios.
    /// </summary>
    sealed class UsuariosRepository : BaseRepository, IUsuariosRepository
    {
        Func<object[], Usuario> Mapper
        {
            get
            {
                return values => new Usuario
                {
                    DniEmpleado = (int)values[0],
                    Username = (string)values[1],
                    Password = (string)values[2],
                    Intentos = (int)values[3],
                    Activo = (bool)values[4],
                    Empleado = new Empleado
                    {
                        Dni = (int)values[5],
                        Nombre = (string)values[6],
                        Apellido = (string)values[7],
                        Mail = (string)values[8],
                        Direccion = (string)values[9],
                        TipoEmpleadoId = (int)values[10],
                        ProvinciaId = (int)values[11],
                        SucursalId = (int)values[12],
                        Activo = (bool)values[13],
                    }
                };
            }
        }

        Usuario ICrudRepository<Usuario>.Get(int dni)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetUsuario, Mapper, dni);
        }

        Usuario[] ICrudRepository<Usuario>.List()
        {
            return ExecuteReader(StoredProcedureNames.GetUsuarios, Mapper);
        }

        Usuario[] ICrudRepository<Usuario>.List(Usuario usuario)
        {
            var empleado = usuario.Empleado;
            return ExecuteReader(StoredProcedureNames.GetUsuariosByFiltros, Mapper, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.TipoEmpleadoId, empleado.ProvinciaId, empleado.SucursalId);
        }

        void ICrudRepository<Usuario>.Add(Usuario usuario)
        {
            ExecuteNonQuery(StoredProcedureNames.AddUsuario, usuario.DniEmpleado, usuario.Username, usuario.Password, usuario.Roles.ToCommaSeparatedString());
        }

        void ICrudRepository<Usuario>.Update(Usuario usuario)
        {
            ExecuteNonQuery(StoredProcedureNames.UpdateUsuario, usuario.DniEmpleado, usuario.Password, usuario.Roles.ToCommaSeparatedString());
        }

        void ICrudRepository<Usuario>.SetEnable(int dniEmpleado, bool enable)
        {
            ExecuteNonQuery(StoredProcedureNames.SetEnableUsuario, dniEmpleado, enable);
        }

        /// <summary>
        /// Obtiene un usuario por su username.
        /// </summary>
        /// <param name="username">username del usuario a buscar.</param>
        /// <returns>Intancia de Usuario.</returns>
        Usuario IUsuariosRepository.GetByUsername(string username)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetUsuarioByUsername, Mapper, username);
        }

        /// <summary>
        /// Setea la cantidad de intentos fallidos de inicio de sesion del usuario.
        /// </summary>
        /// <param name="dni">Dni del empleado.</param>
        /// <param name="intentos">Cantidad de intentos fallidos.</param>
        void IUsuariosRepository.SetIntentos(int dni, int intentos)
        {
            ExecuteNonQuery(StoredProcedureNames.SetUsuarioIntentos, dni, intentos);
        }
    }
}
