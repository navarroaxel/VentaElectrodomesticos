using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Controls
{
    public partial class UcConsultaClientes : UserControl
    {
        public Cliente Cliente { get; set; }

        public UcConsultaClientes()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var consultaClientes = new ConsultaClientes();
                if (consultaClientes.ShowDialog() == DialogResult.OK)
                {
                    Cliente = consultaClientes.Cliente;
                    txtCliente.Text = String.Concat(Cliente.Nombre, " ", Cliente.Apellido);
                }
            });
        }

        public void Clean()
        {
            Cliente = null;
            txtCliente.Text = String.Empty;
        }
    }
}
