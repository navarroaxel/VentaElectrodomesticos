using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views
{
    public partial class Main : Form
    {
        public Usuario Usuario { get; private set; }
        private Dictionary<int, ToolStripMenuItem> Funcionalidades;

        public Main()
        {
            InitializeComponent();
            Funcionalidades = new Dictionary<int, ToolStripMenuItem>()
            {
                { 1, mniCrudEmpleado },
                { 2, mniCrudRol },
                { 3, mniCrudUsuario },
                { 4, mniCrudCliente },
                { 5, mniCrudProducto },
                { 6, mniAsignacionStock },
                { 7, mniFacturacion },
                { 8, mniEfectuarPago },
                { 9, mniTableControl },
                { 10, mniClientesPremium },
                { 11, mniMejoresCategorias }
            };
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                DoLogin();
            });
        }

        private void mniCrudEmpleado_Click(object sender, EventArgs e)
        {
            ActivateForm<Crud.CrudEmpleado>();
        }

        private void mniCrudRol_Click(object sender, EventArgs e)
        {
            ActivateForm<Crud.CrudRol>();
        }

        private void mniCrudUsuario_Click(object sender, EventArgs e)
        {
            ActivateForm<Crud.CrudUsuario>();
        }

        private void mniCrudCliente_Click(object sender, EventArgs e)
        {
            ActivateForm<Crud.CrudCliente>();
        }

        private void mniCrudProducto_Click(object sender, EventArgs e)
        {
            ActivateForm<Crud.CrudProducto>();
        }

        private void mniAsignacionStock_Click(object sender, EventArgs e)
        {
            ActivateForm<Operaciones.AsignacionStock>();
        }

        private void mniFacturacion_Click(object sender, EventArgs e)
        {
            ActivateForm<Operaciones.Facturacion>();
        }

        private void mniEfectuarPago_Click(object sender, EventArgs e)
        {
            ActivateForm<Operaciones.EfectuarPago>();
        }

        private void mniTableControl_Click(object sender, EventArgs e)
        {
            ActivateForm<Consultas.TableroControl>();
        }

        private void mniClientesPremium_Click(object sender, EventArgs e)
        {
            ActivateForm<Consultas.ClientesPremium>();
        }

        private void mniMejoresCategorias_Click(object sender, EventArgs e)
        {
            ActivateForm<Consultas.MejoresCategorias>();
        }

        private void mnuLogOut_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                CloseForms();
                DisableFuncionalidades();
                DoLogin();
            });
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            ActivateForm<Help.About>();
        }

        /// <summary>
        /// Activa los items de  menu segun los permisos del usuario.
        /// </summary>
        /// <param name="funcionalidades">Coleccion de permisos.</param>
        private void SetFuncionalidades(int[] funcionalidades)
        {
            funcionalidades.ForEach(x => Funcionalidades[x].Visible = Funcionalidades[x].Enabled = true);
            EnableMenusFuncionales();
        }

        /// <summary>
        /// Activa los menus correspondientes a los permisos del usuario.
        /// </summary>
        private void EnableMenusFuncionales()
        {
            mnuMain.Items.Cast<ToolStripMenuItem>()
                .ForEach(x => x.Enabled = x.Visible = x.DropDownItems.Cast<ToolStripItem>().Any(i => i.Enabled));
        }

        /// <summary>
        /// Desactiva todos los items de menu por el cierre de sesion.
        /// </summary>
        private void DisableFuncionalidades()
        {
            Funcionalidades.Values.ForEach(x => x.Enabled = x.Visible = false);
            EnableMenusFuncionales();
        }

        /// <summary>
        /// Busca el form entre los abiertos para activarlo. Si no lo crea.
        /// </summary>
        /// <typeparam name="TForm">Clase del formulario a mostrar.</typeparam>
        private void ActivateForm<TForm>() where TForm : Form, new()
        {
            var formType = typeof(TForm);

            var form = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x.GetType() == formType);
            if (form == null)
            {
                form = new TForm { MdiParent = this };
                form.Show();
            }

            form.Activate();
        }

        /// <summary>
        /// Cierra todos los formularios abiertos.
        /// </summary>
        private void CloseForms()
        {
            var mdiType = GetType();
            Application.OpenForms.Cast<Form>()
                .Where(x => x.GetType() != mdiType).ToArray()
                .ForEach(x => x.Close());
        }

        /// <summary>
        /// Muestra la pantalla de login.
        /// </summary>
        private void DoLogin()
        {
            var login = new Login.Login();
            var dialog = login.ShowDialog(this);
            if (dialog == DialogResult.OK)
            {
                Usuario = login.Usuario;
                var client = Proxy.It<IRolService>();
                var funcionalidades = client.Proxy.GetPermisos(Usuario.DniEmpleado);
                SetFuncionalidades(funcionalidades);
            }
        }
    }
}
