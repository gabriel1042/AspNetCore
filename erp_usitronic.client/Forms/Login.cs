using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.client.Forms.LoadingSplash;
using erp_usitronic.client.HttpResources.Authentication;

namespace erp_usitronic.client.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        #region Events
        private async void btnEnter_Click(object sender, EventArgs e)
        {
            bool success = false;
            #if DEBUG 
                txtUser.Text = "usitronic";
                txtPassword.Text = "usi010203";
            #endif
            var tokenBody = new TokenBody
            {
                Name = txtUser.Text,
                AccessKey = txtPassword.Text
            };
            using (var waiting = Wait.Start(this))
            {
                success = await Token.GetNewAsync(tokenBody);
            }
            
            if (success)
            {
                Hide();
                using (var form = new MenuForm())
                {
                    form.ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBoxWrapper.ShowInformation("Usuário ou senha incorreto.");
                txtUser.Focus();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyValue == Keys.Escape)
                Close();

            if ((Keys)e.KeyValue == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
