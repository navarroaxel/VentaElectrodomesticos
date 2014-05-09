using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Model.Entities;
using VentaElectrodomesticos.Desktop.Common;

namespace VentaElectrodomesticos.Desktop.Views.Controls
{
    public partial class ConsultaCategorias : Form
    {
        public Categoria[] Categorias { get; set; }
        public Categoria Categoria { get; set; }

        public ConsultaCategorias()
        {
            InitializeComponent();
        }

        private void ConsultaCategorias_Load(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                FillTree(trvCategorias, Categorias);
                if (Categoria != null)
                {
                    trvCategorias.SelectedNode = FindNode(trvCategorias, Categoria.Id);
                }
            });
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Categoria = (Categoria)trvCategorias.SelectedNode.Tag;
                DialogResult = DialogResult.OK;
                Close();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Close();
            });
        }

        private void FillTree(TreeView treeView, Categoria[] tree)
        {
            tree.ForEach(x =>
            {
                var node = new TreeNode(x.Nombre) { Tag = x };
                treeView.Nodes.Add(node);
                FillNode(node, x.Children);
            });
        }

        private void FillNode(TreeNode parent, Categoria[] children)
        {
            children.ForEach(x =>
            {
                var node = new TreeNode(x.Nombre) { Tag = x };
                parent.Nodes.Add(node);
                FillNode(node, x.Children);
            });
        }

        private TreeNode FindNode(TreeView tree, int categoriaId)
        {
            foreach (TreeNode node in tree.Nodes)
            {
                if (categoriaId == ((Categoria)node.Tag).Id)
                    return node;
                var categNode = FindNode(node, categoriaId);
                if (categNode != null)
                    return categNode;
            }
            return null;
        }

        private TreeNode FindNode(TreeNode parent, int categoriaId)
        {
            foreach (TreeNode node in parent.Nodes)
            {
                if (categoriaId == ((Categoria)node.Tag).Id)
                    return node;
                var categNode = FindNode(node, categoriaId);
                if (categNode != null)
                    return categNode;
            }
            return null;
        }
    }
}
