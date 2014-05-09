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

namespace VentaElectrodomesticos.Desktop.Views.Controls
{
    public partial class ConsultaClientes : Form
    {
        public Cliente[] Clientes { get; set; }
        public Cliente Cliente { get; set; }
        public Provincia[] Provincias { get; set; }

        public ConsultaClientes()
        {
            InitializeComponent();
        }

        private void ConsultaClientes_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var client = Proxy.It<IProvinciaService>();
                Provincias = client.Proxy.List();
                cboProvincia.SetFilterDataSource(Provincias);
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Try.It(() =>
            {
                var client = Proxy.It<IClienteService>();
                Clientes = client.Proxy.List(new Cliente
                {
                    Nombre = txtNombre.Text.Trim().GetNullIfEmpty(),
                    Apellido = txtApellido.Text.Trim().GetNullIfEmpty(),
                    Dni = txtDni.Text.IntParse(),
                    ProvinciaId = (int)cboProvincia.SelectedValue,
                    Activo = true
                });

                SetDataSource(Clientes);
            });
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                txtNombre.Text = txtApellido.Text = txtDni.Text = String.Empty;
                cboProvincia.SelectedValue = 0;
            });
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (dgvClientes.SelectedRows.Count == 0)
                    return;

                var dni = (int)dgvClientes.SelectedRows[0].Cells[0].Value;
                Cliente = Clientes.First(x => x.Dni == dni);

                DialogResult = DialogResult.OK;
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

        private void SetDataSource(Cliente[] Clientes)
        {
            var table = CreateDataTable();

            Clientes.ForEach(cliente => table.Rows.Add(CreateDataRow(table, cliente)));

            dgvClientes.DataSource = table;
        }

        protected DataTable CreateDataTable()
        {
            var table = new DataTable("Clientes");
            table.Columns.Add("DNI", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Mail");
            table.Columns.Add("Teléfono");
            table.Columns.Add("Dirección");
            table.Columns.Add("Provincia");

            return table;
        }

        protected DataRow CreateDataRow(DataTable table, Cliente cliente)
        {
            var row = table.NewRow();
            row[0] = cliente.Dni;
            row[1] = cliente.Nombre;
            row[2] = cliente.Apellido;
            row[3] = cliente.Mail;
            row[4] = cliente.Telefono;
            row[5] = cliente.Direccion;
            row[6] = Provincias.First(x => x.Id == cliente.ProvinciaId).Descripcion;

            return row;
        }
    }
}
