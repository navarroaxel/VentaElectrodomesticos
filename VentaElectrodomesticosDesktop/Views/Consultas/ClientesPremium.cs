using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Common;

namespace VentaElectrodomesticos.Desktop.Views.Consultas
{
    public partial class ClientesPremium : Form
    {
        public ClientesPremium()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<IClienteService>();
                dgvClientes.DataSource = client.Proxy.GetClientesPremium(ucSucursalAnio.Sucursal.Id, ucSucursalAnio.Anio);
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Close();
            });
        }
    }
}
