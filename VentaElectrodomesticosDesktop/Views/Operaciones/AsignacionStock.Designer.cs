namespace VentaElectrodomesticos.Desktop.Views.Operaciones
{
    partial class AsignacionStock
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
            this.dgvAnalistas = new System.Windows.Forms.DataGridView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.MaskedTextBox();
            this.btnSearchAnalista = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnSearchProducto = new System.Windows.Forms.Button();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblNombreMarca = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblStockIngreso = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblStockLabel = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.lblSucural = new System.Windows.Forms.Label();
            this.lblAnalista = new System.Windows.Forms.Label();
            this.lblAnalistaLabel = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblProductoLabel = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAsignacion = new System.Windows.Forms.Panel();
            this.txtStock = new System.Windows.Forms.MaskedTextBox();
            this.pnlProducto = new System.Windows.Forms.Panel();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.ucConsultaCategorias = new VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias();
            this.txtCodigo = new System.Windows.Forms.MaskedTextBox();
            this.pnlAcceptCancel = new System.Windows.Forms.Panel();
            this.pnlAnalista = new System.Windows.Forms.Panel();
            this.pnlAcceptAnalistaProducto = new System.Windows.Forms.Panel();
            this.btnAcceptAnalistaProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalistas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnlAsignacion.SuspendLayout();
            this.pnlProducto.SuspendLayout();
            this.pnlAcceptCancel.SuspendLayout();
            this.pnlAnalista.SuspendLayout();
            this.pnlAcceptAnalistaProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAnalistas
            // 
            this.dgvAnalistas.AllowUserToAddRows = false;
            this.dgvAnalistas.AllowUserToDeleteRows = false;
            this.dgvAnalistas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnalistas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAnalistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalistas.Location = new System.Drawing.Point(6, 40);
            this.dgvAnalistas.MultiSelect = false;
            this.dgvAnalistas.Name = "dgvAnalistas";
            this.dgvAnalistas.ReadOnly = true;
            this.dgvAnalistas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalistas.Size = new System.Drawing.Size(790, 182);
            this.dgvAnalistas.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(7, 16);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(214, 16);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(57, 13);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(151, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(264, 13);
            this.txtApellido.MaxLength = 40;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(151, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(421, 16);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 5;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(453, 12);
            this.txtDni.Mask = "########";
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 3;
            // 
            // btnSearchAnalista
            // 
            this.btnSearchAnalista.Location = new System.Drawing.Point(649, 11);
            this.btnSearchAnalista.Name = "btnSearchAnalista";
            this.btnSearchAnalista.Size = new System.Drawing.Size(98, 23);
            this.btnSearchAnalista.TabIndex = 4;
            this.btnSearchAnalista.Text = "Buscar Analista";
            this.btnSearchAnalista.UseVisualStyleBackColor = true;
            this.btnSearchAnalista.Click += new System.EventHandler(this.btnSearchAnalista_Click);
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
            this.dgvProductos.Location = new System.Drawing.Point(6, 32);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(790, 189);
            this.dgvProductos.TabIndex = 5;
            // 
            // btnSearchProducto
            // 
            this.btnSearchProducto.Location = new System.Drawing.Point(649, 4);
            this.btnSearchProducto.Name = "btnSearchProducto";
            this.btnSearchProducto.Size = new System.Drawing.Size(98, 23);
            this.btnSearchProducto.TabIndex = 4;
            this.btnSearchProducto.Text = "Buscar Producto";
            this.btnSearchProducto.UseVisualStyleBackColor = true;
            this.btnSearchProducto.Click += new System.EventHandler(this.btnSearchProducto_Click);
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(252, 6);
            this.txtNombreMarca.MaxLength = 100;
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(100, 20);
            this.txtNombreMarca.TabIndex = 2;
            // 
            // lblNombreMarca
            // 
            this.lblNombreMarca.AutoSize = true;
            this.lblNombreMarca.Location = new System.Drawing.Point(160, 9);
            this.lblNombreMarca.Name = "lblNombreMarca";
            this.lblNombreMarca.Size = new System.Drawing.Size(86, 13);
            this.lblNombreMarca.TabIndex = 10;
            this.lblNombreMarca.Text = "Nombre o Marca";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(4, 9);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Text = "Código";
            // 
            // lblStockIngreso
            // 
            this.lblStockIngreso.AutoSize = true;
            this.lblStockIngreso.Location = new System.Drawing.Point(478, 37);
            this.lblStockIngreso.Name = "lblStockIngreso";
            this.lblStockIngreso.Size = new System.Drawing.Size(82, 13);
            this.lblStockIngreso.TabIndex = 8;
            this.lblStockIngreso.Text = "Stock a Asignar";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(409, 37);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(0, 13);
            this.lblStock.TabIndex = 7;
            // 
            // lblStockLabel
            // 
            this.lblStockLabel.AutoSize = true;
            this.lblStockLabel.Location = new System.Drawing.Point(335, 37);
            this.lblStockLabel.Name = "lblStockLabel";
            this.lblStockLabel.Size = new System.Drawing.Size(68, 13);
            this.lblStockLabel.TabIndex = 6;
            this.lblStockLabel.Text = "Stock Actual";
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(62, 34);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(201, 21);
            this.cboSucursal.TabIndex = 0;
            this.cboSucursal.SelectedValueChanged += new System.EventHandler(this.cboSucursal_SelectedValueChanged);
            // 
            // lblSucural
            // 
            this.lblSucural.AutoSize = true;
            this.lblSucural.Location = new System.Drawing.Point(3, 37);
            this.lblSucural.Name = "lblSucural";
            this.lblSucural.Size = new System.Drawing.Size(48, 13);
            this.lblSucural.TabIndex = 4;
            this.lblSucural.Text = "Sucursal";
            // 
            // lblAnalista
            // 
            this.lblAnalista.AutoSize = true;
            this.lblAnalista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalista.Location = new System.Drawing.Point(385, 11);
            this.lblAnalista.Name = "lblAnalista";
            this.lblAnalista.Size = new System.Drawing.Size(0, 13);
            this.lblAnalista.TabIndex = 3;
            // 
            // lblAnalistaLabel
            // 
            this.lblAnalistaLabel.AutoSize = true;
            this.lblAnalistaLabel.Location = new System.Drawing.Point(335, 11);
            this.lblAnalistaLabel.Name = "lblAnalistaLabel";
            this.lblAnalistaLabel.Size = new System.Drawing.Size(44, 13);
            this.lblAnalistaLabel.TabIndex = 2;
            this.lblAnalistaLabel.Text = "Analista";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.Location = new System.Drawing.Point(59, 11);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 13);
            this.lblProducto.TabIndex = 1;
            // 
            // lblProductoLabel
            // 
            this.lblProductoLabel.AutoSize = true;
            this.lblProductoLabel.Location = new System.Drawing.Point(3, 11);
            this.lblProductoLabel.Name = "lblProductoLabel";
            this.lblProductoLabel.Size = new System.Drawing.Size(50, 13);
            this.lblProductoLabel.TabIndex = 0;
            this.lblProductoLabel.Text = "Producto";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(640, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Acep&tar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(721, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Canc&elar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlAsignacion, 0, 3);
            this.tlpMain.Controls.Add(this.pnlProducto, 0, 1);
            this.tlpMain.Controls.Add(this.pnlAcceptCancel, 0, 4);
            this.tlpMain.Controls.Add(this.pnlAnalista, 0, 0);
            this.tlpMain.Controls.Add(this.pnlAcceptAnalistaProducto, 0, 2);
            this.tlpMain.Location = new System.Drawing.Point(-1, 2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.Size = new System.Drawing.Size(805, 581);
            this.tlpMain.TabIndex = 19;
            // 
            // pnlAsignacion
            // 
            this.pnlAsignacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAsignacion.Controls.Add(this.txtStock);
            this.pnlAsignacion.Controls.Add(this.lblProductoLabel);
            this.pnlAsignacion.Controls.Add(this.lblStockIngreso);
            this.pnlAsignacion.Controls.Add(this.lblProducto);
            this.pnlAsignacion.Controls.Add(this.lblStock);
            this.pnlAsignacion.Controls.Add(this.lblAnalistaLabel);
            this.pnlAsignacion.Controls.Add(this.lblStockLabel);
            this.pnlAsignacion.Controls.Add(this.lblAnalista);
            this.pnlAsignacion.Controls.Add(this.cboSucursal);
            this.pnlAsignacion.Controls.Add(this.lblSucural);
            this.pnlAsignacion.Enabled = false;
            this.pnlAsignacion.Location = new System.Drawing.Point(3, 487);
            this.pnlAsignacion.Name = "pnlAsignacion";
            this.pnlAsignacion.Size = new System.Drawing.Size(799, 63);
            this.pnlAsignacion.TabIndex = 2;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(566, 34);
            this.txtStock.Mask = "######";
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 9;
            // 
            // pnlProducto
            // 
            this.pnlProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProducto.Controls.Add(this.lblCategoria);
            this.pnlProducto.Controls.Add(this.lblCodigo);
            this.pnlProducto.Controls.Add(this.ucConsultaCategorias);
            this.pnlProducto.Controls.Add(this.dgvProductos);
            this.pnlProducto.Controls.Add(this.txtCodigo);
            this.pnlProducto.Controls.Add(this.lblNombreMarca);
            this.pnlProducto.Controls.Add(this.txtNombreMarca);
            this.pnlProducto.Controls.Add(this.btnSearchProducto);
            this.pnlProducto.Location = new System.Drawing.Point(3, 231);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new System.Drawing.Size(799, 222);
            this.pnlProducto.TabIndex = 1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(358, 9);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 22;
            this.lblCategoria.Text = "Categoria";
            // 
            // ucConsultaCategorias
            // 
            this.ucConsultaCategorias.Categoria = null;
            this.ucConsultaCategorias.Categorias = null;
            this.ucConsultaCategorias.Location = new System.Drawing.Point(416, 2);
            this.ucConsultaCategorias.Name = "ucConsultaCategorias";
            this.ucConsultaCategorias.Size = new System.Drawing.Size(227, 26);
            this.ucConsultaCategorias.TabIndex = 3;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(50, 6);
            this.txtCodigo.Mask = "############";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // pnlAcceptCancel
            // 
            this.pnlAcceptCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAcceptCancel.Controls.Add(this.btnCancel);
            this.pnlAcceptCancel.Controls.Add(this.btnAccept);
            this.pnlAcceptCancel.Location = new System.Drawing.Point(3, 556);
            this.pnlAcceptCancel.Name = "pnlAcceptCancel";
            this.pnlAcceptCancel.Size = new System.Drawing.Size(799, 22);
            this.pnlAcceptCancel.TabIndex = 3;
            // 
            // pnlAnalista
            // 
            this.pnlAnalista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnalista.Controls.Add(this.lblNombre);
            this.pnlAnalista.Controls.Add(this.dgvAnalistas);
            this.pnlAnalista.Controls.Add(this.lblApellido);
            this.pnlAnalista.Controls.Add(this.txtNombre);
            this.pnlAnalista.Controls.Add(this.txtApellido);
            this.pnlAnalista.Controls.Add(this.lblDni);
            this.pnlAnalista.Controls.Add(this.txtDni);
            this.pnlAnalista.Controls.Add(this.btnSearchAnalista);
            this.pnlAnalista.Location = new System.Drawing.Point(3, 3);
            this.pnlAnalista.Name = "pnlAnalista";
            this.pnlAnalista.Size = new System.Drawing.Size(799, 222);
            this.pnlAnalista.TabIndex = 0;
            // 
            // pnlAcceptAnalistaProducto
            // 
            this.pnlAcceptAnalistaProducto.Controls.Add(this.btnAcceptAnalistaProducto);
            this.pnlAcceptAnalistaProducto.Location = new System.Drawing.Point(3, 459);
            this.pnlAcceptAnalistaProducto.Name = "pnlAcceptAnalistaProducto";
            this.pnlAcceptAnalistaProducto.Size = new System.Drawing.Size(799, 22);
            this.pnlAcceptAnalistaProducto.TabIndex = 4;
            // 
            // btnAcceptAnalistaProducto
            // 
            this.btnAcceptAnalistaProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptAnalistaProducto.Location = new System.Drawing.Point(721, -1);
            this.btnAcceptAnalistaProducto.Name = "btnAcceptAnalistaProducto";
            this.btnAcceptAnalistaProducto.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptAnalistaProducto.TabIndex = 0;
            this.btnAcceptAnalistaProducto.Text = "Aceptar";
            this.btnAcceptAnalistaProducto.UseVisualStyleBackColor = true;
            this.btnAcceptAnalistaProducto.Click += new System.EventHandler(this.btnAcceptAnalistaProducto_Click);
            // 
            // AsignacionStock
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(804, 585);
            this.Controls.Add(this.tlpMain);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "AsignacionStock";
            this.Text = "Asginación de Stock";
            this.Load += new System.EventHandler(this.AsignacionStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalistas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnlAsignacion.ResumeLayout(false);
            this.pnlAsignacion.PerformLayout();
            this.pnlProducto.ResumeLayout(false);
            this.pnlProducto.PerformLayout();
            this.pnlAcceptCancel.ResumeLayout(false);
            this.pnlAnalista.ResumeLayout(false);
            this.pnlAnalista.PerformLayout();
            this.pnlAcceptAnalistaProducto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnalistas;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.MaskedTextBox txtDni;
        private System.Windows.Forms.Button btnSearchAnalista;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnSearchProducto;
        private System.Windows.Forms.TextBox txtNombreMarca;
        private System.Windows.Forms.Label lblNombreMarca;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label lblSucural;
        private System.Windows.Forms.Label lblAnalista;
        private System.Windows.Forms.Label lblAnalistaLabel;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblProductoLabel;
        private System.Windows.Forms.Label lblStockIngreso;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblStockLabel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlAsignacion;
        private System.Windows.Forms.Panel pnlProducto;
        private System.Windows.Forms.Panel pnlAnalista;
        private System.Windows.Forms.Panel pnlAcceptCancel;
        private System.Windows.Forms.MaskedTextBox txtCodigo;
        private VentaElectrodomesticos.Desktop.Views.Controls.UcConsultaCategorias ucConsultaCategorias;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Panel pnlAcceptAnalistaProducto;
        private System.Windows.Forms.Button btnAcceptAnalistaProducto;
        private System.Windows.Forms.MaskedTextBox txtStock;
    }
}