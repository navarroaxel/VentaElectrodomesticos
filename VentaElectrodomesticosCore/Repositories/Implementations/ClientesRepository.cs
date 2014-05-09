using System.Linq;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using VentaElectrodomesticos.Core.Model.Entities;
using System;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    sealed class ClientesRepository : BaseRepository, IClientesRepository
    {
        Func<object[], Cliente> Mapper
        {
            get
            {
                return values => new Cliente
                {
                    Dni = (int)values[0],
                    Nombre = (string)values[1],
                    Apellido = (string)values[2],
                    Mail = (string)values[3],
                    Telefono = (string)values[4],
                    Direccion = (string)values[5],
                    ProvinciaId = (int)values[6],
                    Activo = (bool)values[7]
                };
            }
        }

        Cliente ICrudRepository<Cliente>.Get(int dni)
        {
            return ExecuteReaderSingle(StoredProcedureNames.GetCliente, Mapper, dni);
        }

        Cliente[] ICrudRepository<Cliente>.List()
        {
            return ExecuteReader(StoredProcedureNames.GetClientes, Mapper);
        }

        Cliente[] ICrudRepository<Cliente>.List(Cliente cliente)
        {
            return ExecuteReader(StoredProcedureNames.GetClientesByFiltros, Mapper, cliente.Dni, cliente.Nombre, cliente.Apellido, cliente.ProvinciaId, cliente.Activo ? (bool?)true : null);
        }

        void ICrudRepository<Cliente>.Add(Cliente cliente)
        {
            ExecuteNonQuery(StoredProcedureNames.AddCliente, cliente.Dni, cliente.Nombre, cliente.Apellido, cliente.Mail, cliente.Telefono, cliente.Direccion, cliente.ProvinciaId);
        }

        void ICrudRepository<Cliente>.Update(Cliente cliente)
        {
            ExecuteNonQuery(StoredProcedureNames.UpdateCliente, cliente.Dni, cliente.Nombre, cliente.Apellido, cliente.Mail, cliente.Telefono, cliente.Direccion, cliente.ProvinciaId);
        }

        void ICrudRepository<Cliente>.SetEnable(int dniCliente, bool enable)
        {
            ExecuteNonQuery(StoredProcedureNames.SetEnableCliente, dniCliente, enable);
        }

        /// <summary>
        /// Retorna los clientes premium de la sucursal y año seleccionados.
        /// </summary>
        /// <param name="sucursalId">Sucursal a analizar.</param>
        /// <param name="anio">Año a analizar.</param>
        /// <returns>Datos de los clientes premium.</returns>
        DataTable IClientesRepository.GetClientesPremium(int sucursalId, int anio)
        {
            return ExecuteDataTable(StoredProcedureNames.GetClientesPremium, sucursalId, anio);
        }
    }
}
