using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erp_usitronic.client.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empresaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using(var form = new CompanyForm())
            {
                form.ShowDialog();
            }
        }

        private void bancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new BankForm())
            {
                form.ShowDialog();
            }
        }

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
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

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void pessoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new PersonForm())
            {
                form.ShowDialog();
            }
        }
    }
}
