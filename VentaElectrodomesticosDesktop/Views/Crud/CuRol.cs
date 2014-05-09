using System;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CuRol : CuForm<Rol, IRolService>
    {
        public Funcionalidad[] Funcionalidades { get; set; }

        public CuRol()
        {
            InitializeComponent();
        }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IRolService>();
            Funcionalidades = client.Proxy.ListFuncionalidades();
            clbFuncionalidades.SetItems(Funcionalidades);
        }

        protected override void SetEntity(Rol entity)
        {
            lblId.Text = entity.Id.ToString();
            txtNombre.Text = entity.Nombre;
            clbFuncionalidades.SetSelectedIds(entity.Funcionalidades);
        }

        protected override Rol GetEntity()
        {
            return new Rol
            {
                Id = lblId.Text.IntParse(),
                Nombre = txtNombre.Text.Trim(),
                Funcionalidades = clbFuncionalidades.GetSelectedIds()
            };
        }

        protected override void Clean()
        {
            txtNombre.Text = String.Empty;
            clbFuncionalidades.SetSelectedIds(new int[0]);
        }
    }
}
