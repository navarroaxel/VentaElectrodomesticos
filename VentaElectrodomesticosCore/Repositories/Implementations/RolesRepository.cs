using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio de la entidad Rol.
    /// </summary>
    sealed class RolesRepository : BaseRepository, IRolesRepository
    {
        /// <summary>
        /// Representa un mapper entre el la estructura del result set y la entidad rol.
        /// </summary>
        class RolMapper : Rol
        {
            public int Funcionalidad { get; set; }
        }

        Func<object[], RolMapper> Mapper
        {
            get
            {
                return values => new RolMapper
                {
                    Id = (int)values[0],
                    Nombre = (string)values[1],
                    Funcionalidad = (int)values[2],
                    Activo = (bool)values[3]
                };
            }
        }

        Rol ICrudRepository<Rol>.Get(int id)
        {
            var rolMapper = ExecuteReader(StoredProcedureNames.GetRol, Mapper, id);
            return GroupRoles(rolMapper).First();
        }

        Rol[] ICrudRepository<Rol>.List()
        {
            var rolMapper = ExecuteReader(StoredProcedureNames.GetRoles, Mapper);
            return GroupRoles(rolMapper);
        }

        Rol[] ICrudRepository<Rol>.List(Rol rol)
        {
            var rolMapper = ExecuteReader(StoredProcedureNames.GetRolesByFiltros, Mapper, rol.Id, rol.Nombre);
            return GroupRoles(rolMapper);
        }

        void ICrudRepository<Rol>.Add(Rol rol)
        {
            ExecuteNonQuery(StoredProcedureNames.AddRol, rol.Nombre, rol.Funcionalidades.ToCommaSeparatedString());
        }

        void ICrudRepository<Rol>.Update(Rol rol)
        {
            ExecuteNonQuery(StoredProcedureNames.UpdateRol, rol.Id, rol.Nombre, rol.Funcionalidades.ToCommaSeparatedString());
        }

        void ICrudRepository<Rol>.SetEnable(int id, bool enable)
        {
            ExecuteNonQuery(StoredProcedureNames.SetEnableRol, id, enable);
        }

        /// <summary>
        /// Mapea un coleccion de rol funcionalidad con una entidad Rol.
        /// </summary>
        /// <param name="rolFuncionalidades">Coleccion de rol funcionalidad.</param>
        /// <returns>Coleccion de roles.</returns>
        private Rol[] GroupRoles(RolMapper[] rolFuncionalidades)
        {
            return (from rolFuncionalidad in rolFuncionalidades
                    group rolFuncionalidad by rolFuncionalidad.Id into groupping
                    select new Rol
                    {
                        Id = groupping.First().Id,
                        Nombre = groupping.First().Nombre,
                        Activo = groupping.First().Activo,
                        Funcionalidades = (from item in groupping
                                           select item.Funcionalidad).ToArray()
                    }).ToArray();
        }

        /// <summary>
        /// Retorna los roles del usuario.
        /// </summary>
        /// <param name="dniUsuario">Usuario loggeado en el sistema.</param>
        /// <returns>Coleccion de roles.</returns>
        Rol[] IRolesRepository.GetByUsuario(int dniUsuario)
        {
            return ExecuteReader(StoredProcedureNames.GetRolesByUsuario,
                values => new Rol
                {
                    Id = (int)values[0],
                    Nombre = (string)values[1],
                    Activo = (bool)values[2]
                },
                dniUsuario);
        }

        /// <summary>
        /// Retorna los permisos del usuario.
        /// </summary>
        /// <param name="dniUsuario">Usuario loggueado en el sistema.</param>
        /// <returns>Coleccion de permisos.</returns>
        int[] IRolesRepository.GetPermisosByUsuario(int dniUsuario)
        {
            return ExecuteReader(StoredProcedureNames.GetPermisosByUsuario, values => (int)values[0], dniUsuario);
        }
    }
}
