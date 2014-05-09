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
    public partial class CuCliente : CuForm<Cliente, IClienteService>
    {
        public Provincia[] Provincias { get; set; }

        public CuCliente()
        {
            InitializeComponent();
        }

        protected override void ViewLoad()
        {
            cboProvincia.SetDataSource(Provincias);
        }

        protected override void SetEntity(Cliente entity)
        {
            txtNombre.Text = entity.Nombre;
            txtApellido.Text = entity.Apellido;
            txtDni.Text = entity.Dni.ToString();
            txtMail.Text = entity.Mail;
            txtDireccion.Text = entity.Direccion;
            txtTelefono.Text = entity.Telefono;
            cboProvincia.SelectedValue = entity.ProvinciaId;
        }

        protected override Cliente GetEntity()
        {
            return new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.IntParse(),
                Mail = txtMail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                ProvinciaId = (int)cboProvincia.SelectedValue
            };
        }

        protected override void SetUpdateBehavior()
        {
            txtDni.Enabled = false;
        }

        protected override void Clean()
        {
            txtNombre.Text = txtApellido.Text = txtMail.Text = txtTelefono.Text = txtDireccion.Text = String.Empty;
            cboProvincia.SelectedValue = Provincias[0].Id;

            if (Behavior == CuFormBehavior.Create)
            {
                txtDni.Text = String.Empty;
            }
        }
    }
}
