namespace VentaElectrodomesticos.Desktop.Views.Consultas
{
    partial class TableroControl
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalVentasTitle = new System.Windows.Forms.Label();
            this.lblTotalFacturacionTitle = new System.Windows.Forms.Label();
            this.lblProporcionFormaPagoTitle = new System.Windows.Forms.Label();
            this.lblMayorFacturaTitle = new System.Windows.Forms.Label();
            this.lblMayorDeudorTitle = new System.Windows.Forms.Label();
            this.lblVendedorTitle = new System.Windows.Forms.Label();
            this.lblProductoTitle = new System.Windows.Forms.Label();
            this.lblFaltanteStockTitle = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.lblTotalFacturacion = new System.Windows.Forms.Label();
            this.lblProporcionFormaPago = new System.Windows.Forms.Label();
            this.lblMayorFactura = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblMayorDeudor = new System.Windows.Forms.Label();
            this.lblFaltanteStock = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblNoData = new System.Windows.Forms.Label();
            this.ucSucursalAnio = new VentaElectrodomesticos.Desktop.Views.Controls.UcSucursalAnio();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(607, 308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Ce&rrar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalVentasTitle
            // 
            this.lblTotalVentasTitle.AutoSize = true;
            this.lblTotalVentasTitle.Location = new System.Drawing.Point(1, 81);
            this.lblTotalVentasTitle.Name = "lblTotalVentasTitle";
            this.lblTotalVentasTitle.Size = new System.Drawing.Size(81, 13);
            this.lblTotalVentasTitle.TabIndex = 7;
            this.lblTotalVentasTitle.Text = "Total de ventas";
            // 
            // lblTotalFacturacionTitle
            // 
            this.lblTotalFacturacionTitle.AutoSize = true;
            this.lblTotalFacturacionTitle.Location = new System.Drawing.Point(1, 109);
            this.lblTotalFacturacionTitle.Name = "lblTotalFacturacionTitle";
            this.lblTotalFacturacionTitle.Size = new System.Drawing.Size(105, 13);
            this.lblTotalFacturacionTitle.TabIndex = 8;
            this.lblTotalFacturacionTitle.Text = "Total de Facturación";
            // 
            // lblProporcionFormaPagoTitle
            // 
            this.lblProporcionFormaPagoTitle.AutoSize = true;
            this.lblProporcionFormaPagoTitle.Location = new System.Drawing.Point(1, 137);
            this.lblProporcionFormaPagoTitle.Name = "lblProporcionFormaPagoTitle";
            this.lblProporcionFormaPagoTitle.Size = new System.Drawing.Size(144, 13);
            this.lblProporcionFormaPagoTitle.TabIndex = 9;
            this.lblProporcionFormaPagoTitle.Text = "Proporción de forma de pago";
            // 
            // lblMayorFacturaTitle
            // 
            this.lblMayorFacturaTitle.AutoSize = true;
            this.lblMayorFacturaTitle.Location = new System.Drawing.Point(1, 165);
            this.lblMayorFacturaTitle.Name = "lblMayorFacturaTitle";
            this.lblMayorFacturaTitle.Size = new System.Drawing.Size(72, 13);
            this.lblMayorFacturaTitle.TabIndex = 10;
            this.lblMayorFacturaTitle.Text = "Mayor factura";
            // 
            // lblMayorDeudorTitle
            // 
            this.lblMayorDeudorTitle.AutoSize = true;
            this.lblMayorDeudorTitle.Location = new System.Drawing.Point(1, 193);
            this.lblMayorDeudorTitle.Name = "lblMayorDeudorTitle";
            this.lblMayorDeudorTitle.Size = new System.Drawing.Size(72, 13);
            this.lblMayorDeudorTitle.TabIndex = 11;
            this.lblMayorDeudorTitle.Text = "Mayor deudor";
            // 
            // lblVendedorTitle
            // 
            this.lblVendedorTitle.AutoSize = true;
            this.lblVendedorTitle.Location = new System.Drawing.Point(1, 221);
            this.lblVendedorTitle.Name = "lblVendedorTitle";
            this.lblVendedorTitle.Size = new System.Drawing.Size(91, 13);
            this.lblVendedorTitle.TabIndex = 12;
            this.lblVendedorTitle.Text = "Vendedor del año";
            // 
            // lblProductoTitle
            // 
            this.lblProductoTitle.AutoSize = true;
            this.lblProductoTitle.Location = new System.Drawing.Point(1, 249);
            this.lblProductoTitle.Name = "lblProductoTitle";
            this.lblProductoTitle.Size = new System.Drawing.Size(88, 13);
            this.lblProductoTitle.TabIndex = 13;
            this.lblProductoTitle.Text = "Producto del año";
            // 
            // lblFaltanteStockTitle
            // 
            this.lblFaltanteStockTitle.AutoSize = true;
            this.lblFaltanteStockTitle.Location = new System.Drawing.Point(1, 277);
            this.lblFaltanteStockTitle.Name = "lblFaltanteStockTitle";
            this.lblFaltanteStockTitle.Size = new System.Drawing.Size(89, 13);
            this.lblFaltanteStockTitle.TabIndex = 14;
            this.lblFaltanteStockTitle.Text = "Faltante de stock";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Location = new System.Drawing.Point(168, 81);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(0, 13);
            this.lblTotalVentas.TabIndex = 15;
            // 
            // lblTotalFacturacion
            // 
            this.lblTotalFacturacion.AutoSize = true;
            this.lblTotalFacturacion.Location = new System.Drawing.Point(168, 110);
            this.lblTotalFacturacion.Name = "lblTotalFacturacion";
            this.lblTotalFacturacion.Size = new System.Drawing.Size(0, 13);
            this.lblTotalFacturacion.TabIndex = 16;
            // 
            // lblProporcionFormaPago
            // 
            this.lblProporcionFormaPago.AutoSize = true;
            this.lblProporcionFormaPago.Location = new System.Drawing.Point(168, 139);
            this.lblProporcionFormaPago.Name = "lblProporcionFormaPago";
            this.lblProporcionFormaPago.Size = new System.Drawing.Size(0, 13);
            this.lblProporcionFormaPago.TabIndex = 17;
            // 
            // lblMayorFactura
            // 
            this.lblMayorFactura.AutoSize = true;
            this.lblMayorFactura.Location = new System.Drawing.Point(168, 168);
            this.lblMayorFactura.Name = "lblMayorFactura";
            this.lblMayorFactura.Size = new System.Drawing.Size(0, 13);
            this.lblMayorFactura.TabIndex = 18;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(168, 249);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 13);
            this.lblProducto.TabIndex = 21;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(168, 221);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(0, 13);
            this.lblVendedor.TabIndex = 20;
            // 
            // lblMayorDeudor
            // 
            this.lblMayorDeudor.AutoSize = true;
            this.lblMayorDeudor.Location = new System.Drawing.Point(168, 193);
            this.lblMayorDeudor.Name = "lblMayorDeudor";
            this.lblMayorDeudor.Size = new System.Drawing.Size(0, 13);
            this.lblMayorDeudor.TabIndex = 19;
            // 
            // lblFaltanteStock
            // 
            this.lblFaltanteStock.AutoSize = true;
            this.lblFaltanteStock.Location = new System.Drawing.Point(168, 277);
            this.lblFaltanteStock.Name = "lblFaltanteStock";
            this.lblFaltanteStock.Size = new System.Drawing.Size(0, 13);
            this.lblFaltanteStock.TabIndex = 22;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(443, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "&Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.ForeColor = System.Drawing.Color.Red;
            this.lblNoData.Location = new System.Drawing.Point(163, 50);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(300, 13);
            this.lblNoData.TabIndex = 24;
            this.lblNoData.Text = "No hay datos para la sucursal y año seleccionados.";
            this.lblNoData.Visible = false;
            // 
            // ucSucursalAnio
            // 
            this.ucSucursalAnio.Anio = 0;
            this.ucSucursalAnio.AutoSize = true;
            this.ucSucursalAnio.Location = new System.Drawing.Point(119, 12);
            this.ucSucursalAnio.Name = "ucSucursalAnio";
            this.ucSucursalAnio.Size = new System.Drawing.Size(319, 32);
            this.ucSucursalAnio.Sucursal = null;
            this.ucSucursalAnio.TabIndex = 0;
            // 
            // TableroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(694, 343);
            this.Controls.Add(this.lblNoData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblFaltanteStock);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblMayorDeudor);
            this.Controls.Add(this.lblMayorFactura);
            this.Controls.Add(this.lblProporcionFormaPago);
            this.Controls.Add(this.lblTotalFacturacion);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.lblFaltanteStockTitle);
            this.Controls.Add(this.lblProductoTitle);
            this.Controls.Add(this.lblVendedorTitle);
            this.Controls.Add(this.lblMayorDeudorTitle);
            this.Controls.Add(this.lblMayorFacturaTitle);
            this.Controls.Add(this.lblProporcionFormaPagoTitle);
            this.Controls.Add(this.lblTotalFacturacionTitle);
            this.Controls.Add(this.lblTotalVentasTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucSucursalAnio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TableroControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablero de Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VentaElectrodomesticos.Desktop.Views.Controls.UcSucursalAnio ucSucursalAnio;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalVentasTitle;
        private System.Windows.Forms.Label lblTotalFacturacionTitle;
        private System.Windows.Forms.Label lblProporcionFormaPagoTitle;
        private System.Windows.Forms.Label lblMayorFacturaTitle;
        private System.Windows.Forms.Label lblMayorDeudorTitle;
        private System.Windows.Forms.Label lblVendedorTitle;
        private System.Windows.Forms.Label lblProductoTitle;
        private System.Windows.Forms.Label lblFaltanteStockTitle;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label lblTotalFacturacion;
        private System.Windows.Forms.Label lblProporcionFormaPago;
        private System.Windows.Forms.Label lblMayorFactura;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblMayorDeudor;
        private System.Windows.Forms.Label lblFaltanteStock;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblNoData;
    }
}