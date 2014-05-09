using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Desktop.Views.Controls
{
    public partial class UcSucursalAnio : UserControl
    {
        private Sucursal[] Sucursales { get; set; }
        public Sucursal Sucursal { get; set; }
        public int Anio { get; set; }

        public UcSucursalAnio()
        {
            InitializeComponent();
        }

        private void UcSucursalAnio_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (DesignMode)
                    return;

                var client = Proxy.It<ISucursalService>();
                Sucursales = client.Proxy.List();
                cboSucursal.SetDataSource(Sucursales);

                cboAnio.SetDataSource(Enumerable.Range(1995, 106), x => x, x => x.ToString());
            });
        }

        private void cboSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (cboSucursal.SelectedValue == null)
                    return;

                int sucursalId = (int)cboSucursal.SelectedValue;
                Sucursal = Sucursales.First(sucursal => sucursal.Id == sucursalId);
            });
        }

        private void cboAnio_SelectedValueChanged(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (cboAnio.SelectedValue == null)
                    return;

                Anio = (int)cboAnio.SelectedValue;
            });
        }
    }
}
