using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Controls
{
    public partial class UcConsultaCategorias : UserControl
    {
        public Categoria[] Categorias { get; set; }
        public Categoria Categoria { get; set; }

        public new bool Enabled
        {
            get { return btnCategoria.Enabled; }
            set { btnCategoria.Enabled = value; }
        }

        public UcConsultaCategorias()
        {
            InitializeComponent();
        }

        private void UcConsultaCategorias_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                if (this.DesignMode)
                    return;

                var client = Proxy.It<ICategoriaService>();
                Categorias = client.Proxy.List();
            });
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                var consultaCategorias = new ConsultaCategorias
                {
                    Categorias = Categorias,
                    Categoria = Categoria
                };

                if (consultaCategorias.ShowDialog() == DialogResult.OK)
                {
                    Categoria = consultaCategorias.Categoria;
                    txtCategoria.Text = GetDescription(Categoria.Id);
                }
            });
        }

        internal void SetCategoria(int id)
        {
            txtCategoria.Text = GetDescription(id);
            Categoria = FindCategoria(Categorias, id);
        }

        public void Clean()
        {
            Categoria = null;
            txtCategoria.Text = String.Empty;
        }

        public string GetDescription(int categoriaId)
        {
            foreach (var categoria in Categorias)
            {
                if (categoria.Id == categoriaId)
                    return categoria.Nombre;

                var description = GetDescription(categoria.Children, categoriaId);
                if (!String.IsNullOrEmpty(description))
                    return String.Concat(categoria.Nombre, "¦", description);
            }
            return String.Empty;
        }

        private string GetDescription(Categoria[] categorias, int categoriaId)
        {
            foreach (var categoria in categorias)
            {
                if (categoria.Id == categoriaId)
                    return categoria.Nombre;

                var description = GetDescription(categoria.Children, categoriaId);
                if (!String.IsNullOrEmpty(description))
                    return String.Concat(categoria.Nombre, "¦", description);
            }
            return null;
        }

        private Categoria FindCategoria(Categoria[] categorias, int categoriaId)
        {
            foreach (var categoria in categorias)
            {
                if (categoriaId == categoria.Id)
                    return categoria;

                var child = FindCategoria(categoria.Children, categoriaId);
                if (child != null)
                    return child;
            }
            return null;
        }
    }
}
