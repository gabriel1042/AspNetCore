using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using erp_usitronic.business;

namespace erp_usitronic.client.Forms.LoadingSplash
{
    [SuppressUnmanagedCodeSecurity]
    public class FormCaller<TForm> where TForm : Form
    {        
        public const int WM_NCPAINT = 0x85;
        

        public TForm Form { get; }
        private IntPtr _handle;
        private bool _pendingClose;

        public FormCaller(TForm form)
        {
            Form = form;
            _handle = IntPtr.Zero;
            _pendingClose = false;
        }


        public void ExibirEmThreadSeparada()
        {
            _pendingClose = false;
            Form.HandleCreated += Form_HandleCreated;
            Form.HandleDestroyed += Form_HandleDestroyed;
            Form.RodarEmThreadSeparada(true);
            Thread.Yield();
            Thread.Sleep(10);
        }
        private void Form_HandleCreated(object sender, EventArgs e)
        {
            if (!(sender is Control form)) return;

            _handle = form.Handle;
            form.HandleCreated -= Form_HandleCreated;
            if (_pendingClose)
                EndForm();
        }

        private void Form_HandleDestroyed(object sender, EventArgs e)
        {
            if (!(sender is Control form)) return;
            _handle = IntPtr.Zero;
            form.HandleDestroyed -= Form_HandleDestroyed;
            form.Dispose();
        }

        public void Close()
        {
            Thread.Yield();
            if (_handle != IntPtr.Zero)
                EndForm();
            else
                _pendingClose = true;
        }

        private void EndForm()
        {
            NativeMethods.EndByHandle(_handle);
        }
    }
}
