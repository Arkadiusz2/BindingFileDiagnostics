using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BfDiagUI.API
{
    static class User32
    {
        public const int EM_LINEINDEX = 0xBB;
        public const int EM_GETFIRSTVISIBLELINE = 0xCE;
        public const int EM_LINESCROLL = 0xB6;

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        [DllImport("User32.Dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}
