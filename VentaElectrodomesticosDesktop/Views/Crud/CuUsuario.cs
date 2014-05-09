using System;
using System.Linq;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CuUsuario : CuForm<Usuario, IUsuarioService>
    {
        public Rol[] Roles { get; set; }
        public Empleado[] Empleados { get; set; }

        public CuUsuario()
        {
            InitializeComponent();
        }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IRolService>();
            Roles = client.Proxy.List();
            clbRoles.SetItems(Roles.Where(rol => rol.Activo).ToArray());
        }

        protected override void SetEntity(Usuario entity)
        {
            lblEmpleado.Text = String.Concat(entity.Empleado.Nombre, " ", entity.Empleado.Apellido);
            txtUsername.Text = entity.Username;
            txtPasswordConfirmation.Text = txtPassword.Text = entity.Password;

            if (entity.Roles == null)
            {
                //TODO AN: Revisar esto cuando se avance con el sistema.
                var client = Proxy.It<IRolService>();
                entity.Roles = client.Proxy.GetByUsuario(entity.DniEmpleado).Select(x => x.Id).ToArray();
            }

            clbRoles.SetSelectedIds(entity.Roles);
        }

        protected override Usuario GetEntity()
        {
            if (String.IsNullOrEmpty(txtPassword.Text) && String.IsNullOrEmpty(txtPasswordConfirmation.Text))
                throw new BusinessException(MessageProviderExtensions.RequiredField(lblPassword.Text));

            if (String.Compare(txtPassword.Text, txtPasswordConfirmation.Text, StringComparison.Ordinal) != 0)
                throw new BusinessException(MessageProvider.InvalidInputPasswordConfirmation);

            var usuario = new Usuario
            {
                DniEmpleado = Entity != null ? Entity.DniEmpleado : (int)cboEmpleado.SelectedValue,
                Username = txtUsername.Text.Trim(),
                Password = Entity != null && String.Compare(txtPassword.Text, Entity.Password, StringComparison.Ordinal) == 0 ?
                            Entity.Password
                            : txtPassword.Text.ComputeHash(),
                Roles = clbRoles.GetSelectedIds()
            };

            return usuario;
        }

        protected override void SetCreateBehavior()
        {
            var client = Proxy.It<IEmpleadoService>();
            Empleados = client.Proxy.ListWithoutUsuarios().Where(empleado => empleado.Activo).ToArray();

            if (Empleados.Length == 0)
            {
                MsgBox.ShowError(MessageProvider.NoEmpleadosWithoutUsuarios);
                Close();
            }

            cboEmpleado.SetDataSource(Empleados, x => x.Dni, x => String.Concat(x.Nombre, " ", x.Apellido));
        }

        protected override void SetUpdateBehavior()
        {
            txtUsername.Enabled = cboEmpleado.Visible = false;
            lblEmpleado.Visible = true;
        }

        protected override void Clean()
        {
            txtPassword.Text = txtPasswordConfirmation.Text = String.Empty;
            clbRoles.SetSelectedIds(new int[0]);
            if (Behavior == CuFormBehavior.Create)
                cboEmpleado.SelectedValue = Empleados[0].Dni;
        }
    }
}
