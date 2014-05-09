using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace VentaElectrodomesticos.Core.Repositories.Implementations
{
    /// <summary>
    /// Representa comportamiento base para los repositorios.
    /// </summary>
    class BaseRepository
    {
        /// <summary>
        /// Nombre de la base de datos de la aplicacion.
        /// </summary>
        protected const string DATABASE = "GD1C2011";

        /// <summary>
        /// Retorna la base de datos de la aplicacion.
        /// </summary>
        /// <returns>Instancia de la clase contenedora de la base de datos.</returns>
        protected Database GetDatabase()
        {
            return DatabaseFactory.CreateDatabase(DATABASE);
        }

        /// <summary>
        /// Ejecuta un query sin retornar resultados.
        /// </summary>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="parameterValues">Parametros del stored procedure.</param>
        /// <returns>Cantidad de filas afectadas.</returns>
        protected int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            var db = GetDatabase();
            return db.ExecuteNonQuery(storedProcedureName, parameterValues);
        }

        /// <summary>
        /// Ejecuta un stored procedure retornando los resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que mapea con el resultado del sp.</typeparam>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="mapper">Retorna una instancia a partir de una fila del result set.</param>
        /// <returns>Colleccion con los datos del resultado.</returns>
        protected T[] ExecuteReader<T>(string storedProcedureName, Func<object[], T> mapper)
        {
            return ExecuteReader<T>(storedProcedureName, mapper, new object[0]);
        }

        /// <summary>
        /// Ejecuta un stored procedure retornando los resultados.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que mapea con el resultado del sp.</typeparam>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="mapper">Retorna una instancia a partir de una fila del result set.</param>
        /// <param name="parameterValues">Parametros del stored procedure.</param>
        /// <returns>Colleccion con los datos del resultado.</returns>
        protected T[] ExecuteReader<T>(string storedProcedureName, Func<object[], T> mapper, params object[] parameterValues)
        {
            var db = GetDatabase();
            using (var reader = db.ExecuteReader(storedProcedureName, parameterValues))
            {
                return reader.Read(mapper).ToArray();
            }
        }

        /// <summary>
        /// Ejecuta un stored procedure que retorna un solo registro.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que mapea con el resultado del sp.</typeparam>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="mapper">Retorna una instancia a partir de una fila del result set.</param>
        /// <returns>Resultado del stored procedure.</returns>
        protected T ExecuteReaderSingle<T>(string storedProcedureName, Func<object[], T> mapper)
        {
            return ExecuteReaderSingle<T>(storedProcedureName, mapper, new object[0]);
        }

        /// <summary>
        /// Ejecuta un stored procedure que retorna un solo registro.
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que mapea con el resultado del sp.</typeparam>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="mapper">Retorna una instancia a partir de una fila del result set.</param>
        /// <param name="parameterValues">Parametros del stored procedure.</param>
        /// <returns>Resultado del stored procedure.</returns>
        protected T ExecuteReaderSingle<T>(string storedProcedureName, Func<object[], T> mapper, params object[] parameterValues)
        {
            var db = GetDatabase();
            using (var reader = db.ExecuteReader(storedProcedureName, parameterValues))
            {
                return reader.Read(mapper).FirstOrDefault();
            }
        }

        /// <summary>
        /// Ejecuta un stored procedure retornando un DataTable
        /// </summary>
        /// <param name="storedProcedureName">Nombre del stored procedure a ejecutar.</param>
        /// <param name="parameterValues">Parametros del stored procedure.</param>
        /// <returns>DataTable contenedor del resultado.</returns>
        protected DataTable ExecuteDataTable(string storedProcedureName, params object[] parameterValues)
        {
            var db = GetDatabase();
            using (var reader = db.ExecuteReader(storedProcedureName, parameterValues))
            {
                var table = new DataTable();
                table.Load(reader);
                return table;
            }
        }
    }
}
