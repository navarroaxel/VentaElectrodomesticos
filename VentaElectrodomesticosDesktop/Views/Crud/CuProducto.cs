using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CuProducto : CuForm<Producto, IProductoService>
    {
        public ProductoMarca[] Marcas { get; set; }

        public CuProducto()
        {
            InitializeComponent();
        }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IProductoService>();
            Marcas = client.Proxy.ListMarcas();
            cboMarca.SetDataSource(Marcas);
        }

        protected override void SetEntity(Producto entity)
        {
            lblCodigo.Text = entity.Id.ToString();
            txtNombre.Text = entity.Nombre;
            cboMarca.SelectedValue = entity.MarcaId;
            txtDescripcion.Text = entity.Descripcion;
            txtPrecio.Text = entity.Precio.ToString();
            ucCategoria.SetCategoria(entity.CategoriaId);
        }

        protected override Producto GetEntity()
        {
            var precio = txtPrecio.Text.NullableDoubleParse();
            if (!precio.HasValue)
            {
                throw new BusinessException(MessageProvider.PrecioInvalido);
            }

            return new Producto
            {
                Id = lblCodigo.Text.IntParse(),
                Nombre = txtNombre.Text.Trim(),
                MarcaId = (int)cboMarca.SelectedValue,
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = precio.Value,
                CategoriaId = ucCategoria.Categoria != null ? ucCategoria.Categoria.Id : 0
            };
        }

        protected override void SetUpdateBehavior()
        {
            ucCategoria.Enabled = false;
        }

        protected override void Clean()
        {
            txtNombre.Text = cboMarca.Text = txtDescripcion.Text = txtPrecio.Text = String.Empty;
            if (Behavior == CuFormBehavior.Create)
                ucCategoria.Clean();
        }
    }
}
