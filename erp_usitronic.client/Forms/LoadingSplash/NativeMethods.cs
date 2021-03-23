using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace erp_usitronic.client.Forms.LoadingSplash
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr PostMessage(IntPtr hWnd, int message, IntPtr wParam, IntPtr lParam);

        private const int WM_CLOSE = 0x0010;
        public static void EndByHandle(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero) throw new ArgumentOutOfRangeException(nameof(hWnd));

            PostMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

        }
    }
}
