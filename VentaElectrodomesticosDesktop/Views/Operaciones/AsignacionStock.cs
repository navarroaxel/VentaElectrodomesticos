using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Model;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Views.Operaciones
{
    public partial class AsignacionStock : Form
    {
        public Sucursal[] Sucursales { get; set; }
        public Empleado[] Empleados { get; set; }
        public Producto[] Productos { get; set; }

        public Empleado SelectedEmpleado { get; set; }
        public Producto SelectedProducto { get; set; }

        public ProductoStock[] ProductoStocks { get; set; }

        public AsignacionStock()
        {
            InitializeComponent();
        }

        private void AsignacionStock_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<ISucursalService>();
                Sucursales = client.Proxy.ListByEmpleado(((Main)MdiParent).Usuario.DniEmpleado);
                cboSucursal.SetDataSource(Sucursales);
            });
        }

        private void btnSearchAnalista_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<IEmpleadoService>();
                Empleados = client.Proxy.List(new Empleado
                {
                    TipoEmpleadoId = (int)TipoEmpleadoEnum.Analista,
                    Activo = true
                });

                SetDataSourceAnalistas(Empleados);
            });
        }

        private void btnSearchProducto_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<IProductoService>();
                Productos = client.Proxy.List(new Producto
                {
                    Id = txtCodigo.Text.IntParse(),
                    Nombre = txtNombreMarca.Text.Trim().GetNullIfEmpty(),
                    CategoriaId = ucConsultaCategorias.Categoria != null ? ucConsultaCategorias.Categoria.Id : 0
                });

                SetDataSourceProductos(Productos);
            });
        }

        private void btnAcceptAnalistaProducto_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                SelectedProducto = GetSelectedProducto();
                SelectedEmpleado = GetSelectedEmpleado();

                lblProducto.Text = String.Concat(SelectedProducto.Nombre, "-", SelectedProducto.Marca);
                lblAnalista.Text = String.Concat(SelectedEmpleado.Nombre, " ", SelectedEmpleado.Apellido);

                var client = Proxy.It<IProductoService>();
                ProductoStocks = client.Proxy.GetStockSucursales(SelectedProducto.Id);

                ShowStock();

                pnlAsignacion.Enabled = true;
            });
        }

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                ShowStock();
            });
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (SelectedProducto == null)
                    throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Producto));

                if (SelectedEmpleado == null)
                    throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Empleado));

                if (String.IsNullOrEmpty(txtStock.Text))
                    throw new BusinessException(MessageProvider.InvalidCantidad);

                var client = Proxy.It<IProductoService>();
                client.Proxy.AddStock(new IngresoStock
                {
                    DniEmpleado = SelectedEmpleado.Dni,
                    ProductoId = SelectedProducto.Id,
                    Cantidad = txtStock.Text.IntParse(),
                    SucursalId = (int)cboSucursal.SelectedValue
                });

                pnlAsignacion.Enabled = false;
                SelectedProducto = null;
                SelectedEmpleado = null;
                txtNombre.Text = txtApellido.Text = txtDni.Text =
                txtCodigo.Text = txtNombreMarca.Text =
                lblProducto.Text = lblAnalista.Text = lblStock.Text =
                txtStock.Text = String.Empty;
                dgvProductos.DataSource = dgvAnalistas.DataSource = null;

                ucConsultaCategorias.Clean();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Close();
            });
        }

        private void SetDataSourceAnalistas(Empleado[] empleados)
        {
            var table = CreateDataTableAnalistas();
            empleados.ForEach(empleado => table.Rows.Add(CreateDataRow(table, empleado)));
            dgvAnalistas.DataSource = table;
        }

        private void SetDataSourceProductos(Producto[] productos)
        {
            var table = CreateDataTableProductos();
            productos.ForEach(producto => table.Rows.Add(CreateDataRow(table, producto)));
            dgvProductos.DataSource = table;
        }

        /// <summary>
        /// Creo la estructura del DataTable a mostrar.
        /// </summary>
        /// <returns>DataTable con la estructura de la tabla de analistas a mostrar.</returns>
        private DataTable CreateDataTableAnalistas()
        {
            var table = new DataTable();
            table.Columns.Add("DNI", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");

            return table;
        }

        /// <summary>
        /// Creo la estructura del DataTable a mostrar.
        /// </summary>
        /// <returns>DataTable con la estructura de la tabla de productos a mostrar.</returns>
        private DataTable CreateDataTableProductos()
        {
            var table = new DataTable();
            table.Columns.Add("Código", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Marca");
            table.Columns.Add("Categoría");

            return table;
        }

        /// <summary>
        /// Crea una row para ser mostrada en la grilla de analistas
        /// </summary>
        /// <param name="table">DataTable con la estructura del DataRow.</param>
        /// <param name="empleado">Empleado a mostrar.</param>
        /// <returns>DataRow con los datos a mostrar.</returns>
        private DataRow CreateDataRow(DataTable table, Empleado empleado)
        {
            var row = table.NewRow();
            row[0] = empleado.Dni;
            row[1] = empleado.Nombre;
            row[2] = empleado.Apellido;

            return row;
        }

        /// <summary>
        /// Crea una row para ser mostrada en la grilla de analistas
        /// </summary>
        /// <param name="table">DataTable con la estructura del DataRow.</param>
        /// <param name="producto">Producto a mostrar.</param>
        /// <returns>DataRow con los datos a mostrar.</returns>
        private DataRow CreateDataRow(DataTable table, Producto producto)
        {
            var row = table.NewRow();
            row[0] = producto.Id;
            row[1] = producto.Nombre;
            row[2] = producto.Marca;
            row[3] = ucConsultaCategorias.GetDescription(producto.CategoriaId);

            return row;
        }

        /// <summary>
        /// Retorna el empleado seleccionado.
        /// </summary>
        /// <returns>Empleado seleccionado.</returns>
        private Empleado GetSelectedEmpleado()
        {
            if (dgvAnalistas.SelectedRows.Count == 0)
                throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Empleado));

            int empleadoId = (int)dgvAnalistas.SelectedRows[0].Cells[0].Value;
            return Empleados.First(x => x.Dni == empleadoId);
        }

        /// <summary>
        /// Retorna el producto seleccionado.
        /// </summary>
        /// <returns>Producto seleccionado.</returns>
        private Producto GetSelectedProducto()
        {
            if (dgvProductos.SelectedRows.Count == 0)
                throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Producto));

            int productoId = (int)dgvProductos.SelectedRows[0].Cells[0].Value;
            return Productos.First(x => x.Id == productoId);
        }

        /// <summary>
        /// Muestra el stock del producto.
        /// </summary>
        private void ShowStock()
        {
            if (ProductoStocks == null)
            {
                lblStock.Text = String.Empty;
                return;
            }

            int sucursalId = (int)cboSucursal.SelectedValue;
            var stock = ProductoStocks.FirstOrDefault(x => x.SucursalId == sucursalId);
            lblStock.Text = stock != null ? stock.Cantidad.ToString() : "0";
        }
    }
}
