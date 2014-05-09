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

namespace VentaElectrodomesticos.Desktop.Views.Consultas
{
    public partial class MejoresCategorias : Form
    {
        public MejoresCategorias()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<ICategoriaService>();
                dgvCategorias.DataSource = client.Proxy.GetMejoresCategorias(ucSucursalAnio.Sucursal.Id, ucSucursalAnio.Anio);
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
