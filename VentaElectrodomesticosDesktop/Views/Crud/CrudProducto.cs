using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Common;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CrudProducto : CrudForm<Producto, CuProducto, IProductoService>
    {
        public Categoria[] Categorias { get; set; }

        public CrudProducto()
        {
            InitializeComponent();
        }

        protected override Func<Producto, int> GetId { get { return producto => producto.Id; } }

        protected override string EntityName { get { return MessageProvider.Producto; } }

        protected override Producto GetFilter()
        {
            if (String.IsNullOrEmpty(txtNombreMarca.Text.Trim())
                && String.IsNullOrEmpty(txtCodigo.Text.Trim())
                && String.IsNullOrEmpty(txtPrecioTo.Text.Trim())
                && String.IsNullOrEmpty(txtPrecioFrom.Text.Trim())
                && ucCategoria.Categoria == null)
            {
                return null;
            }

            return new Producto
            {
                Id = txtCodigo.Text.IntParse(),
                Nombre = txtNombreMarca.Text.Trim(),
                CategoriaId = ucCategoria.Categoria != null ? ucCategoria.Categoria.Id : 0,
                Filters = new Producto.ExtendedFilters
                {
                    PrecioFrom = txtPrecioFrom.Text.IntParse(),
                    PrecioTo = txtPrecioTo.Text.IntParse()
                }
            };
        }

        protected override DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Código", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Marca");
            table.Columns.Add("Descripción");
            table.Columns.Add("Categoría");
            table.Columns.Add("Precio");
            table.Columns.Add("Activo", typeof(bool));

            return table;
        }

        protected override DataRow CreateDataRow(DataTable table, Producto entity)
        {
            var row = table.NewRow();
            row[0] = entity.Id;
            row[1] = entity.Nombre;
            row[2] = entity.Marca;
            row[3] = entity.Descripcion;
            row[4] = ucCategoria.GetDescription(entity.CategoriaId);
            row[5] = entity.Precio;
            row[6] = entity.Activo;

            return row;
        }

        protected override void CleanFilters()
        {
            txtPrecioTo.Text = txtPrecioFrom.Text = txtNombreMarca.Text = txtCodigo.Text = String.Empty;
            ucCategoria.Clean();
        }
    }
}
