namespace VentaElectrodomesticos.Desktop.Views
{
    partial class Main
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuCrud = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCrudEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCrudRol = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCrudUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCrudCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCrudProducto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOperaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAsignacionStock = new System.Windows.Forms.ToolStripMenuItem();
            this.mniFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEfectuarPago = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTableControl = new System.Windows.Forms.ToolStripMenuItem();
            this.mniClientesPremium = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMejoresCategorias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCrud,
            this.mnuOperaciones,
            this.mnuConsultas,
            this.mnuAccount,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(912, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Menú Principal";
            // 
            // mnuCrud
            // 
            this.mnuCrud.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCrudEmpleado,
            this.mniCrudRol,
            this.mniCrudUsuario,
            this.mniCrudCliente,
            this.mniCrudProducto});
            this.mnuCrud.Enabled = false;
            this.mnuCrud.Name = "mnuCrud";
            this.mnuCrud.Size = new System.Drawing.Size(50, 20);
            this.mnuCrud.Text = "&ABMs";
            this.mnuCrud.Visible = false;
            // 
            // mniCrudEmpleado
            // 
            this.mniCrudEmpleado.Enabled = false;
            this.mniCrudEmpleado.Name = "mniCrudEmpleado";
            this.mniCrudEmpleado.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mniCrudEmpleado.Size = new System.Drawing.Size(212, 22);
            this.mniCrudEmpleado.Text = "ABM de &Empleado";
            this.mniCrudEmpleado.Visible = false;
            this.mniCrudEmpleado.Click += new System.EventHandler(this.mniCrudEmpleado_Click);
            // 
            // mniCrudRol
            // 
            this.mniCrudRol.Enabled = false;
            this.mniCrudRol.Name = "mniCrudRol";
            this.mniCrudRol.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mniCrudRol.Size = new System.Drawing.Size(212, 22);
            this.mniCrudRol.Text = "ABM de &Rol";
            this.mniCrudRol.Visible = false;
            this.mniCrudRol.Click += new System.EventHandler(this.mniCrudRol_Click);
            // 
            // mniCrudUsuario
            // 
            this.mniCrudUsuario.Enabled = false;
            this.mniCrudUsuario.Name = "mniCrudUsuario";
            this.mniCrudUsuario.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.mniCrudUsuario.Size = new System.Drawing.Size(212, 22);
            this.mniCrudUsuario.Text = "ABM de &Usuario";
            this.mniCrudUsuario.Visible = false;
            this.mniCrudUsuario.Click += new System.EventHandler(this.mniCrudUsuario_Click);
            // 
            // mniCrudCliente
            // 
            this.mniCrudCliente.Enabled = false;
            this.mniCrudCliente.Name = "mniCrudCliente";
            this.mniCrudCliente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.mniCrudCliente.Size = new System.Drawing.Size(212, 22);
            this.mniCrudCliente.Text = "ABM de &Cliente";
            this.mniCrudCliente.Visible = false;
            this.mniCrudCliente.Click += new System.EventHandler(this.mniCrudCliente_Click);
            // 
            // mniCrudProducto
            // 
            this.mniCrudProducto.Enabled = false;
            this.mniCrudProducto.Name = "mniCrudProducto";
            this.mniCrudProducto.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.mniCrudProducto.Size = new System.Drawing.Size(212, 22);
            this.mniCrudProducto.Text = "ABM de &Producto";
            this.mniCrudProducto.Visible = false;
            this.mniCrudProducto.Click += new System.EventHandler(this.mniCrudProducto_Click);
            // 
            // mnuOperaciones
            // 
            this.mnuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAsignacionStock,
            this.mniFacturacion,
            this.mniEfectuarPago});
            this.mnuOperaciones.Enabled = false;
            this.mnuOperaciones.Name = "mnuOperaciones";
            this.mnuOperaciones.Size = new System.Drawing.Size(85, 20);
            this.mnuOperaciones.Text = "&Operaciones";
            this.mnuOperaciones.Visible = false;
            // 
            // mniAsignacionStock
            // 
            this.mniAsignacionStock.Enabled = false;
            this.mniAsignacionStock.Name = "mniAsignacionStock";
            this.mniAsignacionStock.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mniAsignacionStock.Size = new System.Drawing.Size(200, 22);
            this.mniAsignacionStock.Text = "Asignación de &Stock";
            this.mniAsignacionStock.Visible = false;
            this.mniAsignacionStock.Click += new System.EventHandler(this.mniAsignacionStock_Click);
            // 
            // mniFacturacion
            // 
            this.mniFacturacion.Enabled = false;
            this.mniFacturacion.Name = "mniFacturacion";
            this.mniFacturacion.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.mniFacturacion.Size = new System.Drawing.Size(200, 22);
            this.mniFacturacion.Text = "&Facturación";
            this.mniFacturacion.Visible = false;
            this.mniFacturacion.Click += new System.EventHandler(this.mniFacturacion_Click);
            // 
            // mniEfectuarPago
            // 
            this.mniEfectuarPago.Enabled = false;
            this.mniEfectuarPago.Name = "mniEfectuarPago";
            this.mniEfectuarPago.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mniEfectuarPago.Size = new System.Drawing.Size(200, 22);
            this.mniEfectuarPago.Text = "Efectuar &Pago";
            this.mniEfectuarPago.Visible = false;
            this.mniEfectuarPago.Click += new System.EventHandler(this.mniEfectuarPago_Click);
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTableControl,
            this.mniClientesPremium,
            this.mniMejoresCategorias});
            this.mnuConsultas.Enabled = false;
            this.mnuConsultas.Name = "mnuConsultas";
            this.mnuConsultas.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuConsultas.Size = new System.Drawing.Size(71, 20);
            this.mnuConsultas.Text = "&Consultas";
            this.mnuConsultas.Visible = false;
            // 
            // mniTableControl
            // 
            this.mniTableControl.Enabled = false;
            this.mniTableControl.Name = "mniTableControl";
            this.mniTableControl.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mniTableControl.Size = new System.Drawing.Size(194, 22);
            this.mniTableControl.Text = "&Tablero de Control";
            this.mniTableControl.Visible = false;
            this.mniTableControl.Click += new System.EventHandler(this.mniTableControl_Click);
            // 
            // mniClientesPremium
            // 
            this.mniClientesPremium.Enabled = false;
            this.mniClientesPremium.Name = "mniClientesPremium";
            this.mniClientesPremium.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mniClientesPremium.Size = new System.Drawing.Size(194, 22);
            this.mniClientesPremium.Text = "Clientes Pre&mium";
            this.mniClientesPremium.Visible = false;
            this.mniClientesPremium.Click += new System.EventHandler(this.mniClientesPremium_Click);
            // 
            // mniMejoresCategorias
            // 
            this.mniMejoresCategorias.Enabled = false;
            this.mniMejoresCategorias.Name = "mniMejoresCategorias";
            this.mniMejoresCategorias.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mniMejoresCategorias.Size = new System.Drawing.Size(194, 22);
            this.mniMejoresCategorias.Text = "&Mejores Categorias";
            this.mniMejoresCategorias.Visible = false;
            this.mniMejoresCategorias.Click += new System.EventHandler(this.mniMejoresCategorias_Click);
            // 
            // mnuAccount
            // 
            this.mnuAccount.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogOut});
            this.mnuAccount.Name = "mnuAccount";
            this.mnuAccount.Size = new System.Drawing.Size(57, 20);
            this.mnuAccount.Text = "C&uenta";
            // 
            // mnuLogOut
            // 
            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Size = new System.Drawing.Size(142, 22);
            this.mnuLogOut.Text = "Cerrar &sesión";
            this.mnuLogOut.Click += new System.EventHandler(this.mnuLogOut_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(53, 20);
            this.mnuHelp.Text = "Ay&uda";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mniAbout.Size = new System.Drawing.Size(154, 22);
            this.mniAbout.Text = "&Acerca de...";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(912, 589);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "Main";
            this.Text = "Venta de Electrodomésticos - DOTNETPY - Gestión de Datos - 1C 2011";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuCrud;
        private System.Windows.Forms.ToolStripMenuItem mniCrudEmpleado;
        private System.Windows.Forms.ToolStripMenuItem mniCrudRol;
        private System.Windows.Forms.ToolStripMenuItem mniCrudUsuario;
        private System.Windows.Forms.ToolStripMenuItem mniCrudCliente;
        private System.Windows.Forms.ToolStripMenuItem mniCrudProducto;
        private System.Windows.Forms.ToolStripMenuItem mnuOperaciones;
        private System.Windows.Forms.ToolStripMenuItem mniAsignacionStock;
        private System.Windows.Forms.ToolStripMenuItem mniFacturacion;
        private System.Windows.Forms.ToolStripMenuItem mniEfectuarPago;
        private System.Windows.Forms.ToolStripMenuItem mnuConsultas;
        private System.Windows.Forms.ToolStripMenuItem mniTableControl;
        private System.Windows.Forms.ToolStripMenuItem mniClientesPremium;
        private System.Windows.Forms.ToolStripMenuItem mniMejoresCategorias;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOut;
    }
}