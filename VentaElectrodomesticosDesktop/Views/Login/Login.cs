using System;
using System.Windows.Forms;
using VentaElectrodomesticos.Core.Common;
using VentaElectrodomesticos.Core.Services;
using VentaElectrodomesticos.Desktop.Common;
using VentaElectrodomesticos.Core.Resources;
using VentaElectrodomesticos.Core.Model.Entities;

namespace VentaElectrodomesticos.Desktop.Views.Login
{
    public partial class Login : Form
    {
        public Usuario Usuario { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, System.EventArgs e)
        {
            Try.It(() =>
            {
                var username = txtUsername.Text.Trim();
                if (String.IsNullOrEmpty(username))
                {
                    MsgBox.ShowError(MessageProviderExtensions.RequiredField(lblUsername.Text));
                    return;
                }

                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MsgBox.ShowError(MessageProviderExtensions.RequiredField(lblPassword.Text));
                    return;
                }

                var client = Proxy.It<ILoginService>();
                if ((Usuario = client.Proxy.Login(username, txtPassword.Text.ComputeHash())) != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Try.It(() =>
            {
                Application.Exit();
            });
        }
    }
}
