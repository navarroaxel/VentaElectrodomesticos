using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VentaElectrodomesticos.Core.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa un repositorio para la entidad Empleado.
    /// </summary>
    sealed class EmpleadosRepository : BaseRepository, IEmpleadosRepository
    {
        Func<object[], Empleado> Mapper
        {
            get
            {
                return values => new Empleado
                {
                    Dni = (int)values[0],
                    Nombre = (string)values[1],
                    Apellido = (string)values[2],
                    Mail = (string)values[3],
                    Direccion = (string)values[4],
                    Telefono = (string)values[5],
                    TipoEmpleadoId = (int)values[6],
                    ProvinciaId = (int)values[7],
                    SucursalId = (int)values[8],
                    Activo = (bool)values[9],
                };
            }
        }

        Empleado ICrudRepository<Empleado>.Get(int dni)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetEmpleado, Mapper, dni);
        }

        Empleado[] ICrudRepository<Empleado>.List()
        {
            return ExecuteReader(StoredProcedureNames.GetEmpleados, Mapper);
        }

        Empleado[] ICrudRepository<Empleado>.List(Empleado empleado)
        {
            return ExecuteReader(StoredProcedureNames.GetEmpleadosByFiltros, Mapper, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.TipoEmpleadoId, empleado.ProvinciaId, empleado.SucursalId, empleado.Activo ? (bool?)true : null);
        }

        void ICrudRepository<Empleado>.Add(Empleado empleado)
        {
            ExecuteNonQuery(StoredProcedureNames.AddEmpleado, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.Mail, empleado.Direccion, empleado.Telefono, empleado.TipoEmpleadoId, empleado.ProvinciaId, empleado.SucursalId);
        }

        void ICrudRepository<Empleado>.Update(Empleado empleado)
        {
            ExecuteNonQuery(StoredProcedureNames.UpdateEmpleado, empleado.Dni, empleado.Nombre, empleado.Apellido, empleado.Mail, empleado.Direccion, empleado.Telefono);
        }

        void ICrudRepository<Empleado>.SetEnable(int dniEmpleado, bool enable)
        {
            ExecuteNonQuery(StoredProcedureNames.SetEnableEmpleado, dniEmpleado, enable);
        }

        /// <summary>
        /// Retorna todos los empleados que no tienen un usuario cargado en el sistema.
        /// </summary>
        /// <returns>Coleccion de empleados sin usuarios</returns>
        Empleado[] IEmpleadosRepository.ListEmpleadosWithoutUsuarios()
        {
            return ExecuteReader(StoredProcedureNames.GetEmpleadosWithoutUsuarios, Mapper);
        }

        /// <summary>
        /// Retorna los filtros necesarios para realizar la busqueda de empleados.
        /// </summary>
        /// <returns>Objeto contenedor de los filtros.</returns>
        EmpleadoFiltros IEmpleadosRepository.GetFiltros()
        {
            var db = GetDatabase();
            using (var cmd = db.GetStoredProcCommand(StoredProcedureNames.GetEmpleadoFiltros))
            {
                using (var reader = db.ExecuteReader(cmd))
                {
                    var empleadoFiltros = new EmpleadoFiltros();
                    empleadoFiltros.Provincias = reader.Read(values => new Provincia
                    {
                        Id = (int)values[0],
                        Descripcion = (string)values[1]
                    }).ToArray();

                    if (reader.NextResult())
                    {
                        empleadoFiltros.TipoEmpleados = reader.Read(values => new TipoEmpleado
                        {
                            Id = (int)values[0],
                            Descripcion = (string)values[1]
                        }).ToArray();

                        if (reader.NextResult())
                        {
                            empleadoFiltros.Sucursales = reader.Read(values => new Sucursal
                            {
                                Id = (int)values[0],
                                TipoSucursalId = (int)values[1],
                                Direccion = (string)values[2],
                                ProvinciaId = (int)values[3],
                                Telefono = (string)values[4]
                            }).ToArray();
                        }
                    }
                    return empleadoFiltros;
                }
            }
        }
    }
}
