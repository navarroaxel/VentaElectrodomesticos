using System.Collections.Generic;
using System.Data;

namespace System.Data
{
    /// <summary>
    /// Method extensions para los DataReader.
    /// </summary>
    public static class DataReaderExtensions
    {
        /// <summary>
        /// Realiza Lazy Read de los registros del DataReader.
        /// </summary>
        /// <typeparam name="T">Entidad con la estructura del result set.</typeparam>
        /// <param name="reader">DataReader de la consulta.</param>
        /// <param name="mapper">Funcion que retorna un instancia de la clase mapper.</param>
        /// <returns>Iterator del DataReader.</returns>
        public static IEnumerable<T> Read<T>(this IDataReader reader, Func<object[], T> mapper)
        {
            var values = new object[reader.FieldCount];
            while (reader.Read())
            {
                reader.GetValues(values);
                yield return mapper(values);
            }
        }
    }
}
