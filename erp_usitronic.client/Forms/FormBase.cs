using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.business;

namespace erp_usitronic.client.Forms
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        protected virtual void btnNew_Click(object sender, EventArgs e)
        {
            ChangeFormStatus(StatusForm.EDITING);
            groupFields.ClearControls();
        }        

        protected virtual void btnEdit_Click(object sender, EventArgs e)
        {
            ChangeFormStatus(StatusForm.EDITING);
        }

        protected virtual void btnSave_Click(object sender, EventArgs e)
        {
            ChangeFormStatus(StatusForm.INITIAL);
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            ChangeFormStatus(StatusForm.INITIAL);
            groupFields.ClearControls();
        }

        protected virtual void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnExit_Click(object sender, EventArgs e)
        {

        }        

        protected virtual void FormBase_Load(object sender, EventArgs e)
        {
            ChangeFormStatus(StatusForm.INITIAL);
        }

        private void ChangeFormStatus(bool status)
        {
            btnEdit.Enabled = !status;
            btnExit.Enabled = !status;
            btnNew.Enabled = !status;
            btnDelete.Enabled = !status;
            btnSave.Enabled = status;
            btnCancel.Enabled = status;

            groupFilters.Enabled = !status;
            groupGrid.Enabled = !status;
            groupFields.Enabled = status;
        }
    }

    public static class StatusForm
    {
        public const bool EDITING = true;
        public const bool INITIAL = false;
    }
}
