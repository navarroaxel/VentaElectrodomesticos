using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Model.Containers;

namespace VentaElectrodomesticos.Desktop.Views.Consultas
{
    public partial class TableroControl : Form
    {
        public TableroControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<ISucursalService>();
                var result = client.Proxy.GetTableroControl(ucSucursalAnio.Sucursal.Id, ucSucursalAnio.Anio);

                if (result == null)
                {
                    CleanData();
                    lblNoData.Visible = true;
                    return;
                }

                SetData(result);
                lblNoData.Visible = false;
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Close();
            });
        }

        /// <summary>
        /// Setea los datos para mostrarlos.
        /// </summary>
        /// <param name="result">Datos del tablero de control.</param>
        private void SetData(TableroControlInfo result)
        {
            lblTotalVentas.Text = result.TotalVentas.ToString();
            lblTotalFacturacion.Text = result.TotalFacturacion.GetValueOrDefault().ToString("N");

            lblProporcionFormaPago.Text = String.Concat((100 * result.FacturasEfectivo.GetValueOrDefault() / (double)result.TotalVentas).ToString("N"), " - ", (100 * (result.TotalVentas - result.FacturasEfectivo.GetValueOrDefault()) / (double)result.TotalVentas).ToString("N"));
            lblMayorFactura.Text = result.MayorFactura.GetValueOrDefault().ToString("N");
            lblMayorDeudor.Text = result.MayorDeudor;
            lblVendedor.Text = result.VendedorAnio;
            lblProducto.Text = result.ProductoAnio;
            lblFaltanteStock.Text = result.FaltanteStock;
        }

        /// <summary>
        /// Limpia los datos mostrados en pantalla.
        /// </summary>
        private void CleanData()
        {
            lblTotalVentas.Text = lblTotalFacturacion.Text =
            lblProporcionFormaPago.Text = lblMayorFactura.Text =
            lblMayorDeudor.Text = lblVendedor.Text =
            lblProducto.Text = lblFaltanteStock.Text = String.Empty;
        }
    }
}
