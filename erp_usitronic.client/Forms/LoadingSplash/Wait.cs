using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erp_usitronic.client.Forms.LoadingSplash
{
    public class Wait : IDisposable
    {
        private FormCaller<WaitProcessing> _waitingProcessingHandler;
        private readonly Stack<byte> _calls;
        private Form _parent;
        private bool _disposed;
        private static Wait _wait;


        private Wait(Form parent)
        {
            _calls = new Stack<byte>();
            _parent = parent;
            if (!(_parent is null))
                _parent.Enabled = false;

        }



        private static Wait Intance(Form parent)
        {
            var aguarde = _wait ?? new Wait(parent);
            aguarde._calls.Push(0x1);
            return aguarde;
        }
        public static Wait Start(Form parent)
        {
            _wait = Intance(parent);

            if (_wait._waitingProcessingHandler is null)
                _wait.Show(parent);

            return _wait;
        }


        private void Show(Form parent)
        {
#pragma warning disable CA2000 // Descartar objetos antes de perder o escopo
            var aguardeProcessando = new WaitProcessing(parent);
#pragma warning restore CA2000 // Descartar objetos antes de perder o escopo
            _waitingProcessingHandler = new FormCaller<WaitProcessing>(aguardeProcessando);
            _waitingProcessingHandler.ExibirEmThreadSeparada();

        }

        private void Terminate()
        {

            _waitingProcessingHandler.Close();
            if (!(_parent is null))
            {
                _parent.Enabled = true;
                _parent.BringToFront();
            }
            _waitingProcessingHandler = null;
            _wait = null;
            _parent = null;
            _disposed = true;
        }
        private void Close()
        {
            _calls.Pop();
            if (_calls.Count > 0) return;
            Terminate();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Wait()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (!disposing) return;
            Close();
        }
    }
}
