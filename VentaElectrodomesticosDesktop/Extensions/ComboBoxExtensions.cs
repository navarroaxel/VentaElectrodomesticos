using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Desktop
{
    /// <summary>
    /// Method extensions para los ComboBox
    /// </summary>
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// Representa un valor vacio para llenar los combos que seran usados como filtros.
        /// </summary>
        class Empty : IKeyValueEntity
        {
            int IKeyValueEntity.Id { get { return 0; } }
            string IKeyValueEntity.Descripcion { get { return "Todos"; } }
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la coleccion a cargar.</typeparam>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        /// <param name="getKey">Funcion que retorna el valor id del item.</param>
        /// <param name="getValue">Funcion que retorna la descripcion del item.</param>
        public static void SetDataSource<T>(this ComboBox cbo, IEnumerable<T> collection, Func<T, int> getKey, Func<T, string> getValue)
        {
            cbo.SetDataSource(from item in collection
                              select new KeyValuePair<int, string>(getKey(item), getValue(item)));
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        public static void SetDataSource(this ComboBox cbo, IEnumerable<KeyValuePair<int, string>> collection)
        {
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = collection.ToArray();
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        public static void SetDataSource(this ComboBox cbo, IEnumerable<IKeyValueEntity> collection)
        {
            cbo.ValueMember = "Id";
            cbo.DisplayMember = "Descripcion";
            cbo.DataSource = collection.ToArray();
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la coleccion a cargar.</typeparam>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        /// <param name="getKey">Funcion que retorna el valor id del item.</param>
        /// <param name="getValue">Funcion que retorna la descripcion del item.</param>
        public static void SetFilterDataSource<T>(this ComboBox cbo, IEnumerable<T> collection, Func<T, int> getKey, Func<T, string> getValue)
        {
            cbo.SetFilterDataSource(from item in collection
                                    select new KeyValuePair<int, string>(getKey(item), getValue(item)));
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        public static void SetFilterDataSource(this ComboBox cbo, IEnumerable<KeyValuePair<int, string>> collection)
        {
            cbo.SetDataSource(new[] { new KeyValuePair<int, string>(0, "Todos") }.Concat(collection));
        }

        /// <summary>
        /// Setea el DataSource del combo box.
        /// </summary>
        /// <param name="cbo">Control ComboBox.</param>
        /// <param name="collection">Coleccion de items a cargar.</param>
        public static void SetFilterDataSource(this ComboBox cbo, IEnumerable<IKeyValueEntity> collection)
        {
            cbo.SetDataSource(new[] { new Empty() }.Concat(collection));
        }
    }
}
