using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CuEmpleado : CuForm<Empleado, IEmpleadoService>
    {
        public Provincia[] Provincias { get; set; }
        public Sucursal[] Sucursales { get; set; }
        public TipoEmpleado[] TipoEmpleados { get; set; }

        public CuEmpleado()
        {
            InitializeComponent();
        }

        protected override void SetEntity(Empleado entity)
        {
            txtNombre.Text = entity.Nombre;
            txtApellido.Text = entity.Apellido;
            txtDni.Text = entity.Dni.ToString();
            txtMail.Text = entity.Mail;
            txtDireccion.Text = entity.Direccion;
            txtTelefono.Text = entity.Telefono;
            cboProvincia.SelectedValue = entity.ProvinciaId;
            cboSucursal.SelectedValue = entity.SucursalId;
            cboTipoEmpleado.SelectedValue = entity.TipoEmpleadoId;
        }

        protected override Empleado GetEntity()
        {
            return new Empleado
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.IntParse(),
                Mail = txtMail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                ProvinciaId = (int)cboProvincia.SelectedValue,
                SucursalId = (int)cboSucursal.SelectedValue,
                TipoEmpleadoId = (int)cboTipoEmpleado.SelectedValue
            };
        }

        protected override void ViewLoad()
        {
            cboProvincia.SetDataSource(Provincias);
            cboSucursal.SetDataSource(Sucursales);
            cboTipoEmpleado.SetDataSource(TipoEmpleados);
        }

        protected override void SetUpdateBehavior()
        {
            cboTipoEmpleado.Enabled = cboSucursal.Enabled = cboProvincia.Enabled = txtDni.Enabled = false;
        }

        protected override void Clean()
        {
            txtNombre.Text = txtApellido.Text = txtTelefono.Text = txtDireccion.Text = txtMail.Text = String.Empty;
            if (Behavior == CuFormBehavior.Create)
            {
                txtDni.Text = String.Empty;
                cboProvincia.SelectedValue = Provincias[0].Id;
                cboSucursal.SelectedValue = Sucursales[0].Id;
                cboTipoEmpleado.SelectedValue = TipoEmpleados[0].Id;
            }
        }
    }
}
