using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Common;

namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    public partial class CrudRol : CrudForm<Rol, CuRol, IRolService>
    {
        public Funcionalidad[] Funcionalidades { get; set; }

        public CrudRol()
        {
            InitializeComponent();
        }

        protected override Func<Rol, int> GetId { get { return rol => rol.Id; } }

        protected override string EntityName { get { return MessageProvider.Rol; } }

        protected override void ViewLoad()
        {
            var client = Proxy.It<IRolService>();
            Funcionalidades = client.Proxy.ListFuncionalidades();
        }

        protected override void CleanFilters()
        {
            txtNombre.Text = txtId.Text = String.Empty;
        }

        protected override Rol GetFilter()
        {
            if (String.IsNullOrEmpty(txtId.Text)
                && String.IsNullOrEmpty(txtNombre.Text))
            {
                return null;
            }

            return new Rol
            {
                Id = txtId.Text.IntParse(),
                Nombre = txtNombre.Text
            };
        }

        protected override DataTable CreateDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre");
            table.Columns.Add("Funcionalidades");
            table.Columns.Add("Activo", typeof(bool));

            return table;
        }

        protected override DataRow CreateDataRow(DataTable table, Rol entity)
        {
            var row = table.NewRow();
            row[0] = entity.Id;
            row[1] = entity.Nombre;
            row[2] = String.Join("¦", Funcionalidades.Where(x => entity.Funcionalidades.Contains(x.Id)).Select(x => x.Descripcion).ToArray());
            row[3] = entity.Activo;

            return row;
        }
    }
}
