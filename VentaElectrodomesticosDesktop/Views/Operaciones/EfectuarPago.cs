using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Views.Operaciones
{
    public partial class EfectuarPago : Form
    {
        public Provincia[] Provincias { get; set; }
        public Sucursal[] Sucursales { get; set; }
        public Factura[] Facturas { get; set; }

        public EfectuarPago()
        {
            InitializeComponent();
        }

        private void EfectuarPago_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<ISucursalService>();
                var filtros = client.Proxy.GetFiltros(((Main)MdiParent).Usuario.DniEmpleado);
                Sucursales = filtros.Sucursales;

                cboProvincia.SetDataSource(Provincias = filtros.Provincias);
            });
        }

        private void btnAcceptClient_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                DoSearch();
            });
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var factura = GetSelectedFactura();
                if (factura == null)
                    throw new BusinessException(MessageProvider.FacturaRequired);

                var client = Proxy.It<IFacturaService>();
                client.Proxy.AddPago(GetSelectedFactura().Nro, (int)numCuotas.Value,
                    ((Main)MdiParent).Usuario.DniEmpleado);

                MsgBox.ShowMessage(MessageProvider.AltaPagoExitoso);

                DoSearch();
                UpdateTotal();
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

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                UpdateTotal();
            });
        }

        private void numCuotas_ValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                UpdateTotal();
            });
        }

        /// <summary>
        /// Realiza la busqueda de Facturas impagas para el clientes elegido.
        /// </summary>
        private void DoSearch()
        {
            if (ucConsultaClientes.Cliente == null)
                throw new BusinessException(MessageProviderExtensions.EntityRequired(MessageProvider.Cliente));

            cboSucursal.Enabled = cboProvincia.Enabled = ucConsultaClientes.Enabled = false;
            var client = Proxy.It<IFacturaService>();
            Facturas = client.Proxy.GetFacturasImpagas((int)cboSucursal.SelectedValue, ucConsultaClientes.Cliente.Dni);

            SetDataSource(Facturas);
        }

        /// <summary>
        /// Setea el DataSource de la grilla.
        /// </summary>
        /// <param name="Facturas">Coleccion de facturas a mostrar.</param>
        private void SetDataSource(Factura[] Facturas)
        {
            var table = CreateDataTable();
            Facturas.ForEach(factura => table.Rows.Add(CreateDataRow(table, factura)));

            dgvFacturas.DataSource = table;
        }

        /// <summary>
        /// Creao la estructura del DataTable a mostrar.
        /// </summary>
        /// <returns>DataTable con la estructura de la tabla a mostrar.</returns>
        private DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Nro Factura", typeof(int));
            table.Columns.Add("Fecha");
            table.Columns.Add("Monto");
            table.Columns.Add("Cant. Cuotas");
            table.Columns.Add("Cuotas Restantes");
            table.Columns.Add("Valor Cuota");

            return table;
        }

        /// <summary>
        /// Crea una row para ser mostrada en la grilla de facturas
        /// </summary>
        /// <param name="table">DataTable con la estructura del DataRow.</param>
        /// <param name="factura">Factura a mostrar.</param>
        /// <returns>DataRow con los datos a mostrar.</returns>
        private DataRow CreateDataRow(DataTable table, Factura factura)
        {
            var row = table.NewRow();
            row[0] = factura.Nro;
            row[1] = factura.Fecha.ToShortDateString();
            row[2] = factura.Total.ToString("N");
            row[3] = factura.Cuotas;
            row[4] = factura.CuotasRestantes;
            row[5] = Math.Round(factura.Total / factura.Cuotas, 2);

            return row;
        }

        /// <summary>
        /// Returna la factura seleccionada.
        /// </summary>
        /// <returns>Instancia de la factura seleccionada.</returns>
        private Factura GetSelectedFactura()
        {
            if (dgvFacturas.SelectedRows.Count == 0)
                return null;

            int nro = (int)dgvFacturas.SelectedRows[0].Cells[0].Value;
            return Facturas.First(factura => factura.Nro == nro);
        }

        /// <summary>
        /// Actualiza los valor a pagar por el usuario.
        /// </summary>
        private void UpdateTotal()
        {
            var factura = GetSelectedFactura();
            if (factura == null)
            {
                lblTotal.Text = String.Empty;
                return;
            }

            numCuotas.Maximum = factura.CuotasRestantes;
            lblTotal.Text = GetTotalPago(factura).ToString("N");
        }
        
        /// <summary>
        /// Retorna el valor total a pagar.
        /// </summary>
        /// <param name="factura">factura que el cliente desea pagar.</param>
        /// <returns>Valor a pagar.</returns>
        private double GetTotalPago(Factura factura)
        {
            return factura.Total / factura.Cuotas * (double)numCuotas.Value;
        }
    }
}
