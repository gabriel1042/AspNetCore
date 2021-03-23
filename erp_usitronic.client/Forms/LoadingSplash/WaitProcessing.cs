using System.Drawing;
using System.Windows.Forms;

namespace erp_usitronic.client.Forms.LoadingSplash
{
    public partial class WaitProcessing : Form
    {
        private readonly Form _parent;

        public WaitProcessing(Form parent) : this()
        {
            _parent = parent;
            StartPosition = FormStartPosition.Manual;
            Location = CenterLocation();
        }

        private Point CenterLocation()
        {
            if (_parent is null) return Point.Empty;
            var x = _parent.Location.X + ((_parent.Width -  Width) / 2);
            var y = _parent.Location.Y + ((_parent.Height - Height) / 2);
            return new Point(x, y);
        }
        public WaitProcessing()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public void CloseForm()
        {
            DialogResult = DialogResult.OK;
            Close();
            Dispose();
        }
    }
}
