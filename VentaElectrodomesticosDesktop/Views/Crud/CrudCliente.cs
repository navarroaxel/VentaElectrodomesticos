using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Resources;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CrudCliente : CrudForm<Cliente, CuCliente, IClienteService>
    {
        private Provincia[] Provincias { get; set; }

        public CrudCliente()
        {
            InitializeComponent();
        }

        protected override Func<Cliente, int> GetId { get { return cliente => cliente.Dni; } }

        protected override string EntityName { get { return MessageProvider.Cliente; } }

        protected override Cliente GetFilter()
        {
            if (String.IsNullOrEmpty(txtNombre.Text.Trim())
                && String.IsNullOrEmpty(txtApellido.Text.Trim())
                && String.IsNullOrEmpty(txtDni.Text.Trim())
                && (int)cboProvincia.SelectedValue <= 0)
            {
                return null;
            }

            return new Cliente
            {
                Nombre = txtNombre.Text.Trim().GetNullIfEmpty(),
                Apellido = txtApellido.Text.Trim().GetNullIfEmpty(),
                Dni = txtDni.Text.Trim().IntParse(),
                ProvinciaId = (int)cboProvincia.SelectedValue
            };
        }

        protected override DataTable CreateDataTable()
        {
            var table = new DataTable("Clientes");
            table.Columns.Add("DNI", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Mail");
            table.Columns.Add("Teléfono");
            table.Columns.Add("Dirección");
            table.Columns.Add("Provincia");
            table.Columns.Add("Activo", typeof(bool));

            return table;
        }

        protected override DataRow CreateDataRow(DataTable table, Cliente entity)
        {
            var row = table.NewRow();
            row[0] = entity.Dni;
            row[1] = entity.Nombre;
            row[2] = entity.Apellido;
            row[3] = entity.Mail;
            row[4] = entity.Telefono;
            row[5] = entity.Direccion;
            row[6] = Provincias.First(x => x.Id == entity.ProvinciaId).Descripcion;
            row[7] = entity.Activo;

            return row;
        }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IProvinciaService>();
            Provincias = client.Proxy.List();
            cboProvincia.SetFilterDataSource(Provincias);
        }

        protected override void CleanFilters()
        {
            txtNombre.Text = txtApellido.Text = txtDni.Text = String.Empty;
            cboProvincia.SelectedValue = 0;
        }

        protected override void InitCuForm(CuCliente cuForm)
        {
            cuForm.Provincias = Provincias;
        }
    }
}
