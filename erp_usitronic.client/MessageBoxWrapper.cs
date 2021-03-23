using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erp_usitronic.client
{
    public static class MessageBoxWrapper
    {
        private const string CAPTION = "Erp Usitronic";

        #region MessageBox
        public static DialogResult ShowInformation(string message)
        {
            MessageBox.Show(message, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return DialogResult.OK;
        }

        public static DialogResult ShowError(string message)
        {
            MessageBox.Show(message, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return DialogResult.OK;
        }

        public static DialogResult ShowYesNo(string message)
        {
            return MessageBox.Show(message, CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
    }
}
