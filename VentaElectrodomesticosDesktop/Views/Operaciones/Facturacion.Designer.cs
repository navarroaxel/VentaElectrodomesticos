namespace VentaElectrodomesticos.Desktop.Views.Operaciones
{
    partial class Facturacion
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
            this.btnRemoveAllProducto = new System.Windows.Forms.Button();
            this.btnRemoveProducto = new System.Windows.Forms.Button();
            this.btnAddProducto = new System.Windows.Forms.Button();
            this.dgvSelectedProductos = new System.Windows.Forms.DataGridView();
            this.btnSearchProductos = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtPrecioTo = new System.Windows.Forms.MaskedTextBox();
            this.txtPrecioFrom = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblPrecioTo = new System.Windows.Forms.Label();
            this.lblPrecioFrom = new System.Windows.Forms.Label();
            this.lblNombreMarca = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.gpbFormaPago = new System.Windows.Forms.GroupBox();
            this.lblPagosLabel = new System.Windows.Forms.Label();
            this.numCuotas = new System.Windows.Forms.NumericUpDown();
            this.lblPagos = new System.Windows.Forms.Label();
            this.radCuotas = new System.Windows.Forms.RadioButton();
            this.radEfectivo = new System.Windows.Forms.RadioButton();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPercentSign = new System.Windows.Forms.Label();
            this.numDescuento = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblSubtotalLabel = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.btnAcceptClient = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAcceptCancel = new System.Windows.Forms.Panel();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.pnlActionsProducto = new System.Windows.Forms.Panel();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.pnlProductos = new System.Windows.Forms.Panel();
            this.ucConsultaCategorias = new VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.ucConsultaClientes = new VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaClientes();
            this.pnlSelectedProductos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gpbFormaPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnlAcceptCancel.SuspendLayout();
            this.pnlTotales.SuspendLayout();
            this.pnlActionsProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.pnlProductos.SuspendLayout();
            this.pnlCliente.SuspendLayout();
            this.pnlSelectedProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemoveAllProducto
            // 
            this.btnRemoveAllProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAllProducto.Location = new System.Drawing.Point(807, -1);
            this.btnRemoveAllProducto.Name = "btnRemoveAllProducto";
            this.btnRemoveAllProducto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllProducto.TabIndex = 15;
            this.btnRemoveAllProducto.Text = "Quitar todos";
            this.btnRemoveAllProducto.UseVisualStyleBackColor = true;
            this.btnRemoveAllProducto.Click += new System.EventHandler(this.btnRemoveAllProducto_Click);
            // 
            // btnRemoveProducto
            // 
            this.btnRemoveProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProducto.Location = new System.Drawing.Point(726, -1);
            this.btnRemoveProducto.Name = "btnRemoveProducto";
            this.btnRemoveProducto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProducto.TabIndex = 14;
            this.btnRemoveProducto.Text = "Quitar";
            this.btnRemoveProducto.UseVisualStyleBackColor = true;
            this.btnRemoveProducto.Click += new System.EventHandler(this.btnRemoveProducto_Click);
            // 
            // btnAddProducto
            // 
            this.btnAddProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProducto.Location = new System.Drawing.Point(638, -1);
            this.btnAddProducto.Name = "btnAddProducto";
            this.btnAddProducto.Size = new System.Drawing.Size(75, 23);
            this.btnAddProducto.TabIndex = 13;
            this.btnAddProducto.Text = "Añadir";
            this.btnAddProducto.UseVisualStyleBackColor = true;
            this.btnAddProducto.Click += new System.EventHandler(this.btnAddProducto_Click);
            // 
            // dgvSelectedProductos
            // 
            this.dgvSelectedProductos.AllowUserToAddRows = false;
            this.dgvSelectedProductos.AllowUserToDeleteRows = false;
            this.dgvSelectedProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectedProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSelectedProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedProductos.Location = new System.Drawing.Point(3, 0);
            this.dgvSelectedProductos.Name = "dgvSelectedProductos";
            this.dgvSelectedProductos.ReadOnly = true;
            this.dgvSelectedProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedProductos.Size = new System.Drawing.Size(876, 176);
            this.dgvSelectedProductos.TabIndex = 16;
            // 
            // btnSearchProductos
            // 
            this.btnSearchProductos.Location = new System.Drawing.Point(596, 5);
            this.btnSearchProductos.Name = "btnSearchProductos";
            this.btnSearchProductos.Size = new System.Drawing.Size(75, 23);
            this.btnSearchProductos.TabIndex = 9;
            this.btnSearchProductos.Text = "Buscar";
            this.btnSearchProductos.UseVisualStyleBackColor = true;
            this.btnSearchProductos.Click += new System.EventHandler(this.btnSearchProductos_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(596, 37);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 10;
            this.btnClean.Text = "Cancelar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(252, 10);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(54, 13);
            this.lblCategoria.TabIndex = 9;
            this.lblCategoria.Text = "Categoría";
            // 
            // txtPrecioTo
            // 
            this.txtPrecioTo.Location = new System.Drawing.Point(490, 39);
            this.txtPrecioTo.Mask = "########";
            this.txtPrecioTo.Name = "txtPrecioTo";
            this.txtPrecioTo.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioTo.TabIndex = 8;
            // 
            // txtPrecioFrom
            // 
            this.txtPrecioFrom.Location = new System.Drawing.Point(327, 39);
            this.txtPrecioFrom.Mask = "########";
            this.txtPrecioFrom.Name = "txtPrecioFrom";
            this.txtPrecioFrom.Size = new System.Drawing.Size(85, 20);
            this.txtPrecioFrom.TabIndex = 7;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(95, 7);
            this.txtCodigo.Mask = "############";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(151, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(95, 39);
            this.txtNombreMarca.MaxLength = 100;
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(151, 20);
            this.txtNombreMarca.TabIndex = 5;
            // 
            // lblPrecioTo
            // 
            this.lblPrecioTo.AutoSize = true;
            this.lblPrecioTo.Location = new System.Drawing.Point(418, 42);
            this.lblPrecioTo.Name = "lblPrecioTo";
            this.lblPrecioTo.Size = new System.Drawing.Size(66, 13);
            this.lblPrecioTo.TabIndex = 4;
            this.lblPrecioTo.Text = "Precio hasta";
            // 
            // lblPrecioFrom
            // 
            this.lblPrecioFrom.AutoSize = true;
            this.lblPrecioFrom.Location = new System.Drawing.Point(252, 42);
            this.lblPrecioFrom.Name = "lblPrecioFrom";
            this.lblPrecioFrom.Size = new System.Drawing.Size(69, 13);
            this.lblPrecioFrom.TabIndex = 3;
            this.lblPrecioFrom.Text = "Precio desde";
            // 
            // lblNombreMarca
            // 
            this.lblNombreMarca.AutoSize = true;
            this.lblNombreMarca.Location = new System.Drawing.Point(3, 42);
            this.lblNombreMarca.Name = "lblNombreMarca";
            this.lblNombreMarca.Size = new System.Drawing.Size(86, 13);
            this.lblNombreMarca.TabIndex = 2;
            this.lblNombreMarca.Text = "Nombre o Marca";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(3, 10);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(3, 66);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(876, 201);
            this.dgvProductos.TabIndex = 11;
            // 
            // gpbFormaPago
            // 
            this.gpbFormaPago.Controls.Add(this.lblPagosLabel);
            this.gpbFormaPago.Controls.Add(this.numCuotas);
            this.gpbFormaPago.Controls.Add(this.lblPagos);
            this.gpbFormaPago.Controls.Add(this.radCuotas);
            this.gpbFormaPago.Controls.Add(this.radEfectivo);
            this.gpbFormaPago.Location = new System.Drawing.Point(19, 3);
            this.gpbFormaPago.Name = "gpbFormaPago";
            this.gpbFormaPago.Size = new System.Drawing.Size(332, 56);
            this.gpbFormaPago.TabIndex = 18;
            this.gpbFormaPago.TabStop = false;
            this.gpbFormaPago.Text = "Forma de Pago";
            // 
            // lblPagosLabel
            // 
            this.lblPagosLabel.AutoSize = true;
            this.lblPagosLabel.Location = new System.Drawing.Point(202, 24);
            this.lblPagosLabel.Name = "lblPagosLabel";
            this.lblPagosLabel.Size = new System.Drawing.Size(60, 13);
            this.lblPagosLabel.TabIndex = 9;
            this.lblPagosLabel.Text = "pagos de $";
            this.lblPagosLabel.Visible = false;
            // 
            // numCuotas
            // 
            this.numCuotas.Location = new System.Drawing.Point(140, 22);
            this.numCuotas.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numCuotas.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numCuotas.Name = "numCuotas";
            this.numCuotas.Size = new System.Drawing.Size(56, 20);
            this.numCuotas.TabIndex = 2;
            this.numCuotas.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numCuotas.Visible = false;
            this.numCuotas.ValueChanged += new System.EventHandler(this.numCuotas_ValueChanged);
            // 
            // lblPagos
            // 
            this.lblPagos.AutoSize = true;
            this.lblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagos.Location = new System.Drawing.Point(268, 24);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.Size = new System.Drawing.Size(14, 13);
            this.lblPagos.TabIndex = 8;
            this.lblPagos.Text = "0";
            this.lblPagos.Visible = false;
            // 
            // radCuotas
            // 
            this.radCuotas.AutoSize = true;
            this.radCuotas.Location = new System.Drawing.Point(76, 22);
            this.radCuotas.Name = "radCuotas";
            this.radCuotas.Size = new System.Drawing.Size(58, 17);
            this.radCuotas.TabIndex = 1;
            this.radCuotas.TabStop = true;
            this.radCuotas.Text = "Cuotas";
            this.radCuotas.UseVisualStyleBackColor = true;
            this.radCuotas.CheckedChanged += new System.EventHandler(this.radFormaPago_CheckedChanged);
            // 
            // radEfectivo
            // 
            this.radEfectivo.AutoSize = true;
            this.radEfectivo.Checked = true;
            this.radEfectivo.Location = new System.Drawing.Point(6, 22);
            this.radEfectivo.Name = "radEfectivo";
            this.radEfectivo.Size = new System.Drawing.Size(64, 17);
            this.radEfectivo.TabIndex = 0;
            this.radEfectivo.TabStop = true;
            this.radEfectivo.Text = "Efectivo";
            this.radEfectivo.UseVisualStyleBackColor = true;
            this.radEfectivo.CheckedChanged += new System.EventHandler(this.radFormaPago_CheckedChanged);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(812, 1);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(14, 13);
            this.lblSubtotal.TabIndex = 6;
            this.lblSubtotal.Text = "0";
            // 
            // lblPercentSign
            // 
            this.lblPercentSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPercentSign.AutoSize = true;
            this.lblPercentSign.Location = new System.Drawing.Point(863, 25);
            this.lblPercentSign.Name = "lblPercentSign";
            this.lblPercentSign.Size = new System.Drawing.Size(15, 13);
            this.lblPercentSign.TabIndex = 5;
            this.lblPercentSign.Text = "%";
            // 
            // numDescuento
            // 
            this.numDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numDescuento.Location = new System.Drawing.Point(815, 21);
            this.numDescuento.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(42, 20);
            this.numDescuento.TabIndex = 17;
            this.numDescuento.ValueChanged += new System.EventHandler(this.numDescuento_ValueChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(812, 47);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(14, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Location = new System.Drawing.Point(750, 47);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(31, 13);
            this.lblTotalLabel.TabIndex = 2;
            this.lblTotalLabel.Text = "Total";
            // 
            // lblDescuento
            // 
            this.lblDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Location = new System.Drawing.Point(750, 23);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(59, 13);
            this.lblDescuento.TabIndex = 1;
            this.lblDescuento.Text = "Descuento";
            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalLabel.AutoSize = true;
            this.lblSubtotalLabel.Location = new System.Drawing.Point(750, 1);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(46, 13);
            this.lblSubtotalLabel.TabIndex = 0;
            this.lblSubtotalLabel.Text = "Subtotal";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(732, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 19;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(807, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(241, 1);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(151, 21);
            this.cboSucursal.TabIndex = 1;
            // 
            // cboProvincia
            // 
            this.cboProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(60, 1);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(121, 21);
            this.cboProvincia.TabIndex = 0;
            this.cboProvincia.SelectedValueChanged += new System.EventHandler(this.cboProvincia_SelectedValueChanged);
            // 
            // btnAcceptClient
            // 
            this.btnAcceptClient.Location = new System.Drawing.Point(677, -1);
            this.btnAcceptClient.Name = "btnAcceptClient";
            this.btnAcceptClient.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptClient.TabIndex = 3;
            this.btnAcceptClient.Text = "Aceptar";
            this.btnAcceptClient.UseVisualStyleBackColor = true;
            this.btnAcceptClient.Click += new System.EventHandler(this.btnAcceptClient_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Location = new System.Drawing.Point(187, 4);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(48, 13);
            this.lblSucursal.TabIndex = 9;
            this.lblSucursal.Text = "Sucursal";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Location = new System.Drawing.Point(3, 4);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(51, 13);
            this.lblProvincia.TabIndex = 8;
            this.lblProvincia.Text = "Provincia";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(398, 4);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente";
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlAcceptCancel, 0, 5);
            this.tlpMain.Controls.Add(this.pnlTotales, 0, 4);
            this.tlpMain.Controls.Add(this.pnlActionsProducto, 0, 2);
            this.tlpMain.Controls.Add(this.pnlProductos, 0, 1);
            this.tlpMain.Controls.Add(this.pnlCliente, 0, 0);
            this.tlpMain.Controls.Add(this.pnlSelectedProductos, 0, 3);
            this.tlpMain.Location = new System.Drawing.Point(-1, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.Size = new System.Drawing.Size(888, 615);
            this.tlpMain.TabIndex = 17;
            // 
            // pnlAcceptCancel
            // 
            this.pnlAcceptCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAcceptCancel.Controls.Add(this.btnCancel);
            this.pnlAcceptCancel.Controls.Add(this.btnAccept);
            this.pnlAcceptCancel.Location = new System.Drawing.Point(3, 589);
            this.pnlAcceptCancel.Name = "pnlAcceptCancel";
            this.pnlAcceptCancel.Size = new System.Drawing.Size(882, 23);
            this.pnlAcceptCancel.TabIndex = 5;
            // 
            // pnlTotales
            // 
            this.pnlTotales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTotales.Controls.Add(this.gpbFormaPago);
            this.pnlTotales.Controls.Add(this.lblSubtotal);
            this.pnlTotales.Controls.Add(this.lblSubtotalLabel);
            this.pnlTotales.Controls.Add(this.lblPercentSign);
            this.pnlTotales.Controls.Add(this.lblDescuento);
            this.pnlTotales.Controls.Add(this.numDescuento);
            this.pnlTotales.Controls.Add(this.lblTotalLabel);
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Enabled = false;
            this.pnlTotales.Location = new System.Drawing.Point(3, 516);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(882, 67);
            this.pnlTotales.TabIndex = 4;
            // 
            // pnlActionsProducto
            // 
            this.pnlActionsProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActionsProducto.Controls.Add(this.numCantidad);
            this.pnlActionsProducto.Controls.Add(this.lblCantidad);
            this.pnlActionsProducto.Controls.Add(this.btnRemoveAllProducto);
            this.pnlActionsProducto.Controls.Add(this.btnRemoveProducto);
            this.pnlActionsProducto.Controls.Add(this.btnAddProducto);
            this.pnlActionsProducto.Enabled = false;
            this.pnlActionsProducto.Location = new System.Drawing.Point(3, 306);
            this.pnlActionsProducto.Name = "pnlActionsProducto";
            this.pnlActionsProducto.Size = new System.Drawing.Size(882, 22);
            this.pnlActionsProducto.TabIndex = 2;
            // 
            // numCantidad
            // 
            this.numCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numCantidad.Location = new System.Drawing.Point(516, 2);
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(106, 20);
            this.numCantidad.TabIndex = 12;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(461, 4);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 17;
            this.lblCantidad.Text = "Cantidad";
            // 
            // pnlProductos
            // 
            this.pnlProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductos.Controls.Add(this.lblCodigo);
            this.pnlProductos.Controls.Add(this.dgvProductos);
            this.pnlProductos.Controls.Add(this.btnSearchProductos);
            this.pnlProductos.Controls.Add(this.lblPrecioFrom);
            this.pnlProductos.Controls.Add(this.btnClean);
            this.pnlProductos.Controls.Add(this.lblNombreMarca);
            this.pnlProductos.Controls.Add(this.ucConsultaCategorias);
            this.pnlProductos.Controls.Add(this.lblPrecioTo);
            this.pnlProductos.Controls.Add(this.lblCategoria);
            this.pnlProductos.Controls.Add(this.txtNombreMarca);
            this.pnlProductos.Controls.Add(this.txtPrecioTo);
            this.pnlProductos.Controls.Add(this.txtCodigo);
            this.pnlProductos.Controls.Add(this.txtPrecioFrom);
            this.pnlProductos.Enabled = false;
            this.pnlProductos.Location = new System.Drawing.Point(3, 33);
            this.pnlProductos.Name = "pnlProductos";
            this.pnlProductos.Size = new System.Drawing.Size(882, 267);
            this.pnlProductos.TabIndex = 1;
            // 
            // ucConsultaCategorias
            // 
            this.ucConsultaCategorias.AutoSize = true;
            this.ucConsultaCategorias.Categoria = null;
            this.ucConsultaCategorias.Categorias = null;
            this.ucConsultaCategorias.Location = new System.Drawing.Point(327, 4);
            this.ucConsultaCategorias.Name = "ucConsultaCategorias";
            this.ucConsultaCategorias.Size = new System.Drawing.Size(228, 27);
            this.ucConsultaCategorias.TabIndex = 6;
            // 
            // pnlCliente
            // 
            this.pnlCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCliente.Controls.Add(this.ucConsultaClientes);
            this.pnlCliente.Controls.Add(this.lblProvincia);
            this.pnlCliente.Controls.Add(this.cboProvincia);
            this.pnlCliente.Controls.Add(this.lblSucursal);
            this.pnlCliente.Controls.Add(this.cboSucursal);
            this.pnlCliente.Controls.Add(this.lblCliente);
            this.pnlCliente.Controls.Add(this.btnAcceptClient);
            this.pnlCliente.Location = new System.Drawing.Point(3, 3);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(882, 24);
            this.pnlCliente.TabIndex = 0;
            // 
            // ucConsultaClientes
            // 
            this.ucConsultaClientes.Cliente = null;
            this.ucConsultaClientes.Location = new System.Drawing.Point(443, -2);
            this.ucConsultaClientes.Name = "ucConsultaClientes";
            this.ucConsultaClientes.Size = new System.Drawing.Size(228, 26);
            this.ucConsultaClientes.TabIndex = 2;
            // 
            // pnlSelectedProductos
            // 
            this.pnlSelectedProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelectedProductos.Controls.Add(this.dgvSelectedProductos);
            this.pnlSelectedProductos.Location = new System.Drawing.Point(3, 334);
            this.pnlSelectedProductos.Name = "pnlSelectedProductos";
            this.pnlSelectedProductos.Size = new System.Drawing.Size(882, 176);
            this.pnlSelectedProductos.TabIndex = 3;
            // 
            // Facturacion
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(892, 623);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Facturacion";
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gpbFormaPago.ResumeLayout(false);
            this.gpbFormaPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCuotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnlAcceptCancel.ResumeLayout(false);
            this.pnlTotales.ResumeLayout(false);
            this.pnlTotales.PerformLayout();
            this.pnlActionsProducto.ResumeLayout(false);
            this.pnlActionsProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.pnlProductos.ResumeLayout(false);
            this.pnlProductos.PerformLayout();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            this.pnlSelectedProductos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label lblPrecioTo;
        private System.Windows.Forms.Label lblPrecioFrom;
        private System.Windows.Forms.Label lblNombreMarca;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias ucConsultaCategorias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.MaskedTextBox txtPrecioTo;
        private System.Windows.Forms.MaskedTextBox txtPrecioFrom;
        private System.Windows.Forms.Button btnSearchProductos;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnRemoveProducto;
        private System.Windows.Forms.Button btnAddProducto;
        private System.Windows.Forms.DataGridView dgvSelectedProductos;
        private System.Windows.Forms.Button btnRemoveAllProducto;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblSubtotalLabel;
        private System.Windows.Forms.NumericUpDown numDescuento;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblPercentSign;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.GroupBox gpbFormaPago;
        private System.Windows.Forms.NumericUpDown numCuotas;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.RadioButton radCuotas;
        private System.Windows.Forms.RadioButton radEfectivo;
        private System.Windows.Forms.Label lblPagosLabel;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Button btnAcceptClient;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblProvincia;
        private VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaClientes ucConsultaClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlActionsProducto;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Panel pnlAcceptCancel;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Panel pnlSelectedProductos;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown numCantidad;
    }
}