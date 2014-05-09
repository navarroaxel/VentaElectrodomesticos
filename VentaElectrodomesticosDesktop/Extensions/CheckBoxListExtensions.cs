using System.Collections.Generic;
using System.Linq;
using VentaElectrodomesticos.Core.Model.Entities;

namespace System.Windows.Forms
{
    /// <summary>
    /// Method extensions para los controles CheckBoxList.
    /// </summary>
    public static class CheckBoxListExtensions
    {
        /// <summary>
        /// Carga los items en el control.
        /// </summary>
        /// <param name="clb">Control CheckBoxList.</param>
        /// <param name="collection">Coleccion de datos a mostrar.</param>
        public static void SetItems(this CheckedListBox clb, IEnumerable<IKeyValueEntity> collection)
        {
            clb.Items.Clear();
            clb.ValueMember = "Id";
            clb.DisplayMember = "Descripcion";

            clb.Items.AddRange(collection.Select(x => String.Concat(x.Id, "-", x.Descripcion)).ToArray());
        }

        /// <summary>
        /// Setea los items seleccionados.
        /// </summary>
        /// <param name="clb">Control CheckBoxList.</param>
        /// <param name="ids">Id de los items seleccionados.</param>
        public static void SetSelectedIds(this CheckedListBox clb, int[] ids)
        {
            for (int i = clb.Items.Count - 1; i >= 0; i--)
                clb.SetItemChecked(i, ids.Contains(clb.Items[i].ToString().Split('-')[0].IntParse()));
        }

        /// <summary>
        /// Retorna la coleccion de ids seleccionados.
        /// </summary>
        /// <param name="clb">Control CheckBoxList.</param>
        /// <returns>Coleccion de ids seleccionados.</returns>
        public static int[] GetSelectedIds(this CheckedListBox clb)
        {
            var ids = new List<int>();
            for (int i = 0; i < clb.CheckedItems.Count; i++)
            {
                ids.Add(clb.CheckedItems[i].ToString().Split('-')[0].IntParse());
            }
            return ids.ToArray();
        }
    }
}
