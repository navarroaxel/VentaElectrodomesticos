using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Containers;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Operaciones
{
    public partial class Facturacion : Form
    {
        public Provincia[] Provincias { get; set; }
        public Sucursal[] Sucursales { get; set; }
        public ProductoSucursalStock[] ProductoStocks { get; set; }

        public Facturacion()
        {
            InitializeComponent();
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<ISucursalService>();
                var filtros = client.Proxy.GetFiltros(((Main)MdiParent).Usuario.DniEmpleado);
                Provincias = filtros.Provincias;
                Sucursales = filtros.Sucursales;
                cboProvincia.SetDataSource(Provincias);

                dgvSelectedProductos.DataSource = CreateDataTableFactProds();
            });
        }

        private void btnAcceptClient_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (ucConsultaClientes.Cliente == null)
                    throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Cliente));

                cboProvincia.Enabled = cboSucursal.Enabled = ucConsultaClientes.Enabled = false;
                pnlProductos.Enabled = pnlActionsProducto.Enabled = pnlSelectedProductos.Enabled = pnlTotales.Enabled = true;
            });
        }

        private void btnSearchProductos_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<IProductoService>();
                var producto = new Producto
                {
                    Id = txtCodigo.Text.IntParse(),
                    CategoriaId = ucConsultaCategorias.Categoria != null ? ucConsultaCategorias.Categoria.Id : 0,
                    Nombre = txtNombreMarca.Text.Trim().GetNullIfEmpty(),
                    Activo = true,
                    Filters = new Producto.ExtendedFilters()
                    {
                        PrecioFrom = txtPrecioFrom.Text.IntParse(),
                        PrecioTo = txtPrecioTo.Text.IntParse()
                    }
                };

                ProductoStocks = client.Proxy.ListWithStock(producto, (int)cboSucursal.SelectedValue);
                SetDataSource(ProductoStocks);
            });
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                txtCodigo.Text = txtNombreMarca.Text = txtPrecioFrom.Text = txtPrecioTo.Text = String.Empty;
                ucConsultaCategorias.Clean();
            });
        }

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var productoStock = GetSelectedProducto();
                if (productoStock == null)
                    return;

                if (productoStock.Stock == null || productoStock.Stock.Cantidad == 0)
                    throw new BusinessException(MessageProvider.NoStockAvalability);

                int cantidad = (int)numCantidad.Value;
                if (cantidad > productoStock.Stock.Cantidad)
                    throw new BusinessException(MessageProvider.InsufficientStockAvalability);

                var table = (DataTable)dgvSelectedProductos.DataSource;
                if (table.Rows.Cast<DataRow>().Any(row => (int)row[0] == productoStock.Producto.Id))
                    throw new BusinessException(MessageProvider.ProductoAdded);

                table.Rows.Add(CreateDataRowFactProds(table, productoStock.Producto, cantidad));

                UpdateTotales();
            });
        }

        private void btnRemoveProducto_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (dgvSelectedProductos.SelectedRows.Count == 0)
                    return;

                dgvSelectedProductos.Rows.Remove(dgvSelectedProductos.SelectedRows[0]);
                UpdateTotales();
            });
        }

        private void btnRemoveAllProducto_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                dgvSelectedProductos.DataSource = CreateDataTableFactProds();
                UpdateTotales();
            });
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (ucConsultaClientes.Cliente == null)
                    throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Cliente));

                if (dgvSelectedProductos.Rows.Count == 0)
                    throw new BusinessException(MessageProvider.FacturaWithoutProductos);

                var factura = new Factura
                {
                    Subtotal = GetSubtotal(),
                    Descuento = (double)numDescuento.Value / 100,
                    Total = GetTotal(),
                    Cuotas = radCuotas.Checked ? (int)numCuotas.Value : 1,
                    DniCliente = ucConsultaClientes.Cliente.Dni,
                    DniEmpleado = ((Main)MdiParent).Usuario.DniEmpleado,
                    SucursalId = (int)cboSucursal.SelectedValue
                };

                var productos = (from row in ((DataTable)dgvSelectedProductos.DataSource).Rows.Cast<DataRow>()
                                 select new FacturaProducto
                                 {
                                     ProductoId = (int)row[0],
                                     Cantidad = (int)row[1],
                                     PrecioUnitario = (double)row[4]
                                 }).ToArray();

                var client = Proxy.It<IFacturaService>();
                int nro = client.Proxy.Add(factura, productos);

                MsgBox.ShowMessage(MessageProviderExtensions.RegisteredFacturaNumber(nro));
                Close();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Close();
            });
        }

        private void cboProvincia_SelectedValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (cboProvincia.SelectedValue == null)
                    return;

                int provinciaId = (int)cboProvincia.SelectedValue;
                cboSucursal.SetDataSource(Sucursales.Where(x => x.ProvinciaId == provinciaId).ToArray());
            });
        }

        private void radFormaPago_CheckedChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                lblPagosLabel.Visible = lblPagos.Visible = numCuotas.Visible = radCuotas.Checked;
            });
        }

        private void numCuotas_ValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                UpdateTotales();
            });
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                UpdateTotales();
            });
        }

        /// <summary>
        /// Retorna el producto seleccionado en la grilla de producto.
        /// </summary>
        /// <returns>Producto seleccionado con su stock.</returns>
        private ProductoSucursalStock GetSelectedProducto()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                return null;

            int productoId = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            return ProductoStocks.First(x => x.Producto.Id == productoId);
        }

        /// <summary>
        /// Setea el data source de la grilla de productos.
        /// </summary>
        /// <param name="productos"></param>
        private void SetDataSource(ProductoSucursalStock[] productos)
        {
            var table = CreateDataTable();
            productos.ForEach(producto => table.Rows.Add(CreateDataRow(table, producto)));
            dgvProductos.DataSource = table;
        }

        /// <summary>
        /// Crea el DataTable con la estructura de la grilla de productos.
        /// </summary>
        /// <returns>DataTable con la estructura de la grilla de productos.</returns>
        private DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Código", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Marca");
            table.Columns.Add("Categoría");
            table.Columns.Add("Precio");
            table.Columns.Add("Stock");

            return table;
        }

        /// <summary>
        /// Crea el DataTable con la estructura de la grilla de productos a facturar.
        /// </summary>
        /// <returns>DataTable con la estructura de la grilla de productos a facturar.</returns>
        private DataTable CreateDataTableFactProds()
        {
            var table = new DataTable();
            table.Columns.Add("Código", typeof(int));
            table.Columns.Add("Cantidad", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Marca");
            table.Columns.Add("P. Unitario", typeof(double));
            table.Columns.Add("Importe", typeof(double));

            return table;
        }

        /// <summary>
        /// Crea una row para la grilla de productos.
        /// </summary>
        /// <param name="table">DataTable con la estructura de la grilla.</param>
        /// <param name="productoStock">Informacion del producto con su stock.</param>
        /// <returns>Row a mostrar en la grilla.</returns>
        private DataRow CreateDataRow(DataTable table, ProductoSucursalStock productoStock)
        {
            var producto = productoStock.Producto;

            var row = table.NewRow();
            row[0] = producto.Id;
            row[1] = producto.Nombre;
            row[2] = producto.Marca;
            row[3] = ucConsultaCategorias.GetDescription(producto.CategoriaId);
            row[4] = producto.Precio;
            row[5] = productoStock.Stock != null ? productoStock.Stock.Cantidad : 0;

            return row;
        }

        /// <summary>
        /// Crea una row para la grilla de productos a facturar.
        /// </summary>
        /// <param name="table">DataTable con la estructura de la grilla.</param>
        /// <param name="productoStock">Informacion del producto con su stock.</param>
        /// <returns>Row a mostrar en la grilla.</returns>
        private DataRow CreateDataRowFactProds(DataTable table, Producto producto, int cantidad)
        {
            var row = table.NewRow();
            row[0] = producto.Id;
            row[1] = cantidad;
            row[2] = producto.Nombre;
            row[3] = producto.Marca;
            row[4] = producto.Precio;
            row[5] = producto.Precio * cantidad;

            return row;
        }

        /// <summary>
        /// Actualiza los labels con la informacion de pago de la factura.
        /// </summary>
        private void UpdateTotales()
        {
            lblSubtotal.Text = GetSubtotal().ToString("N");
            lblTotal.Text = GetTotal().ToString("N");

            lblPagos.Text = GetValorCuota().ToString("N");
        }

        /// <summary>
        /// Retorna el subtotal de la factura sin descuento.
        /// </summary>
        /// <returns></returns>
        private double GetSubtotal()
        {
            return dgvSelectedProductos.Rows.Cast<DataGridViewRow>().Sum(row => (double)row.Cells[5].Value);
        }

        /// <summary>
        /// Retorna el total a pagar con el descuento aplicado.
        /// </summary>
        /// <returns></returns>
        private double GetTotal()
        {
            var subtotal = GetSubtotal();
            return subtotal * (100 - (int)numDescuento.Value) / 100;
        }

        /// <summary>
        /// Retorna el valor de la cuota segun la forma de pago elegida.
        /// </summary>
        /// <returns></returns>
        private double GetValorCuota()
        {
            var total = GetTotal();
            return total / (int)numCuotas.Value;
        }
    }
}
