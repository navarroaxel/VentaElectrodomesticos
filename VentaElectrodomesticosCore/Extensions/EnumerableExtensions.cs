using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Linq
{
    /// <summary>
    /// Method Extension para colecciones.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Itera sobre la coleccion realizando una accion para cada item.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la coleccion.</typeparam>
        /// <param name="collection">Coleccion a iterar.</param>
        /// <param name="action">Accion a ejecutar por cada elemento.</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
                return;

            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Retorna true si la coleccion es null o no tiene elementos.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la coleccion.</typeparam>
        /// <param name="collection">Coleccion a verificar.</param>
        /// <returns>True si esta null o esta vacia la coleccion.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }

        /// <summary>
        /// Retorna una string con elementos separados por coma.
        /// </summary>
        /// <param name="collection">Coleccion de enteros.</param>
        /// <returns>String con los enteros separados por comas.</returns>
        public static string ToCommaSeparatedString(this ICollection<int> collection)
        {
            if (collection.IsNullOrEmpty())
                return String.Empty;

            var strBuilder = new System.Text.StringBuilder();

            collection.ForEach(x => strBuilder.AppendFormat("{0},", x));

            return strBuilder.Remove(strBuilder.Length - 1, 1).ToString();
        }
    }
}
