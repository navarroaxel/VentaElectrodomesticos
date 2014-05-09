namespace VentaElectrodomesticos.Desktop.Views.Crud
{
    partial class CrudProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblPrecioFrom = new System.Windows.Forms.Label();
            this.ucCategoria = new VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias();
            this.lblNombreMarca = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPrecioTo = new System.Windows.Forms.Label();
            this.txtPrecioFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtPrecioTo = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.grpFiltros.SuspendLayout();
            // 
            // lblCategoria
            // 
            this.lblCategoria.Location = new System.Drawing.Point(235, 22);
            this.lblCategoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 21);
            this.lblCategoria.TabIndex = 2;
            this.lblCategoria.Text = "Categoría";
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(113, 44);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(100, 20);
            this.txtNombreMarca.TabIndex = 3;
            // 
            // lblPrecioFrom
            // 
            this.lblPrecioFrom.AutoSize = true;
            this.lblPrecioFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrecioFrom.Location = new System.Drawing.Point(235, 49);
            this.lblPrecioFrom.Name = "lblPrecioFrom";
            this.lblPrecioFrom.Size = new System.Drawing.Size(69, 13);
            this.lblPrecioFrom.TabIndex = 47;
            this.lblPrecioFrom.Text = "Precio desde";
            // 
            // ucCategoria
            // 
            this.ucCategoria.Categoria = null;
            this.ucCategoria.Categorias = null;
            this.ucCategoria.Location = new System.Drawing.Point(310, 16);
            this.ucCategoria.Name = "ucCategoria";
            this.ucCategoria.Size = new System.Drawing.Size(228, 26);
            this.ucCategoria.TabIndex = 3;
            // 
            // lblNombreMarca
            // 
            this.lblNombreMarca.AutoSize = true;
            this.lblNombreMarca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNombreMarca.Location = new System.Drawing.Point(9, 47);
            this.lblNombreMarca.Name = "lblNombreMarca";
            this.lblNombreMarca.Size = new System.Drawing.Size(86, 13);
            this.lblNombreMarca.TabIndex = 39;
            this.lblNombreMarca.Text = "Nombre o Marca";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodigo.Location = new System.Drawing.Point(9, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 36;
            this.lblCodigo.Text = "Código";
            // 
            // lblPrecioTo
            // 
            this.lblPrecioTo.AutoSize = true;
            this.lblPrecioTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrecioTo.Location = new System.Drawing.Point(416, 49);
            this.lblPrecioTo.Name = "lblPrecioTo";
            this.lblPrecioTo.Size = new System.Drawing.Size(66, 13);
            this.lblPrecioTo.TabIndex = 5;
            this.lblPrecioTo.Text = "Precio hasta";
            // 
            // txtPrecioFrom
            // 
            this.txtPrecioFrom.Location = new System.Drawing.Point(310, 44);
            this.txtPrecioFrom.Mask = "########";
            this.txtPrecioFrom.Name = "txtPrecioFrom";
            this.txtPrecioFrom.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioFrom.TabIndex = 4;
            // 
            // txtPrecioTo
            // 
            this.txtPrecioTo.Location = new System.Drawing.Point(488, 44);
            this.txtPrecioTo.Mask = "########";
            this.txtPrecioTo.Name = "txtPrecioTo";
            this.txtPrecioTo.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioTo.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(113, 19);
            this.txtCodigo.Mask = "############";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // grpFiltros
            // 
            this.grpFiltros.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpFiltros.Controls.Add(this.txtCodigo);
            this.grpFiltros.Controls.Add(this.lblCodigo);
            this.grpFiltros.Controls.Add(this.txtPrecioTo);
            this.grpFiltros.Controls.Add(this.lblNombreMarca);
            this.grpFiltros.Controls.Add(this.txtPrecioFrom);
            this.grpFiltros.Controls.Add(this.ucCategoria);
            this.grpFiltros.Controls.Add(this.lblPrecioTo);
            this.grpFiltros.Controls.Add(this.lblPrecioFrom);
            this.grpFiltros.Controls.Add(this.lblCategoria);
            this.grpFiltros.Controls.Add(this.txtNombreMarca);
            this.grpFiltros.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grpFiltros.Location = new System.Drawing.Point(110, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(599, 74);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros de búsqueda";
            this.Controls.Add(this.grpFiltros);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.components = new System.ComponentModel.Container();
        }

        #endregion

        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label lblPrecioFrom;
        private VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias ucCategoria;
        private System.Windows.Forms.Label lblNombreMarca;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPrecioTo;
        private System.Windows.Forms.MaskedTextBox txtPrecioFrom;
        private System.Windows.Forms.MaskedTextBox txtPrecioTo;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.GroupBox grpFiltros;
    }
}
