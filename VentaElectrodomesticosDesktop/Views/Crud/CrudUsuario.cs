using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Common;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CrudUsuario : CrudForm<Usuario, CuUsuario, IUsuarioService>
    {
        private Provincia[] Provincias { get; set; }
        private Sucursal[] Sucursales { get; set; }
        private TipoEmpleado[] TipoEmpleados { get; set; }

        public CrudUsuario()
        {
            InitializeComponent();
        }

        protected override Usuario GetFilter()
        {
            if (String.IsNullOrEmpty(txtNombre.Text.Trim())
                    && String.IsNullOrEmpty(txtApellido.Text.Trim())
                    && String.IsNullOrEmpty(txtDni.Text.Trim())
                    && (int)cboTipoEmpleado.SelectedValue <= 0
                    && (int)cboProvincia.SelectedValue <= 0
                    && (int)cboSucursal.SelectedValue <= 0)
            {
                return null;
            }

            return new Usuario
            {
                Empleado = new Empleado
                {
                    Nombre = txtNombre.Text.Trim().GetNullIfEmpty(),
                    Apellido = txtApellido.Text.Trim().GetNullIfEmpty(),
                    Dni = txtDni.Text.Trim().IntParse(),
                    TipoEmpleadoId = (int)cboTipoEmpleado.SelectedValue,
                    ProvinciaId = (int)cboProvincia.SelectedValue,
                    SucursalId = (int)cboSucursal.SelectedValue
                }
            };
        }

        protected override DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("DNI", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Tipo Empleado");
            table.Columns.Add("Provincia");
            table.Columns.Add("Sucursal");
            table.Columns.Add("Username");
            table.Columns.Add("Activo", typeof(Boolean));

            return table;
        }

        protected override DataRow CreateDataRow(DataTable table, Usuario entity)
        {
            var row = table.NewRow();
            row[0] = entity.DniEmpleado;
            row[1] = entity.Empleado.Nombre;
            row[2] = entity.Empleado.Apellido;
            row[3] = TipoEmpleados.First(x => x.Id == entity.Empleado.TipoEmpleadoId).Descripcion;
            row[4] = Provincias.First(x => x.Id == entity.Empleado.ProvinciaId).Descripcion;
            row[5] = Sucursales.First(x => x.Id == entity.Empleado.SucursalId).Direccion;
            row[6] = entity.Username;
            row[7] = entity.Activo;
            
            return row;
        }

        protected override Func<Usuario, int> GetId { get { return usuario => usuario.DniEmpleado; } }

        protected override string EntityName { get { return MessageProvider.Usuario; } }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IEmpleadoService>();
            var filtros = client.Proxy.GetFiltros();

            cboProvincia.SetFilterDataSource(Provincias = filtros.Provincias);
            cboSucursal.SetFilterDataSource(Sucursales = filtros.Sucursales);
            cboTipoEmpleado.SetFilterDataSource(TipoEmpleados = filtros.TipoEmpleados);
        }

        protected override void CleanFilters()
        {
            txtDni.Text = txtApellido.Text = txtNombre.Text = String.Empty;
            cboTipoEmpleado.SelectedValue = cboSucursal.SelectedValue = cboProvincia.SelectedValue = 0;
        }
    }
}
