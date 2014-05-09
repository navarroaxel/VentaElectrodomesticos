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
    public partial class CrudEmpleado : CrudForm<Empleado, CuEmpleado, IEmpleadoService>
    {
        private Provincia[] Provincias { get; set; }
        private Sucursal[] Sucursales { get; set; }
        private TipoEmpleado[] TipoEmpleados { get; set; }

        public CrudEmpleado()
        {
            InitializeComponent();
        }

        protected override Empleado GetFilter()
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

            return new Empleado
            {
                Nombre = txtNombre.Text.Trim().GetNullIfEmpty(),
                Apellido = txtApellido.Text.Trim().GetNullIfEmpty(),
                Dni = txtDni.Text.Trim().IntParse(),
                TipoEmpleadoId = (int)cboTipoEmpleado.SelectedValue,
                ProvinciaId = (int)cboProvincia.SelectedValue,
                SucursalId = (int)cboSucursal.SelectedValue
            };
        }

        protected override DataTable CreateDataTable()
        {
            var table = new DataTable("Empleados");
            table.Columns.Add("DNI", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Mail");
            table.Columns.Add("Dirección");
            table.Columns.Add("Teléfono");
            table.Columns.Add("Tipo Empleado");
            table.Columns.Add("Provincia");
            table.Columns.Add("Sucursal");
            table.Columns.Add("Activo", typeof(Boolean));

            return table;
        }

        protected override DataRow CreateDataRow(DataTable table, Empleado entity)
        {
            var row = table.NewRow();
            row[0] = entity.Dni;
            row[1] = entity.Nombre;
            row[2] = entity.Apellido;
            row[3] = entity.Mail;
            row[4] = entity.Direccion;
            row[5] = entity.Telefono;
            row[6] = TipoEmpleados.First(x => x.Id == entity.TipoEmpleadoId).Descripcion;
            row[7] = Provincias.First(x => x.Id == entity.ProvinciaId).Descripcion;
            row[8] = Sucursales.First(x => x.Id == entity.SucursalId).Direccion;
            row[9] = entity.Activo;

            return row;
        }

        protected override Func<Empleado, int> GetId { get { return empleado => empleado.Dni; } }

        protected override string EntityName { get { return MessageProvider.Empleado; } }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IEmpleadoService>();
            var filtros = client.Proxy.GetFiltros();

            cboProvincia.SetFilterDataSource(Provincias = filtros.Provincias);
            cboTipoEmpleado.SetFilterDataSource(Sucursales = filtros.Sucursales);
            cboSucursal.SetFilterDataSource(TipoEmpleados = filtros.TipoEmpleados);
        }

        protected override void CleanFilters()
        {
            txtDni.Text = txtApellido.Text = txtNombre.Text = String.Empty;
            cboProvincia.SelectedValue = cboSucursal.SelectedValue = cboTipoEmpleado.SelectedValue = 0;
        }
        protected override void InitCuForm(CuEmpleado cuForm)
        {
            cuForm.Provincias = Provincias;
            cuForm.Sucursales = Sucursales;
            cuForm.TipoEmpleados = TipoEmpleados;
        }
    }
}