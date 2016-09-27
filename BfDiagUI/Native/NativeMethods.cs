using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
//using System.Internal;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
    internal static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMATA
        {
            public int cbSize = Marshal.SizeOf(typeof(NativeMethods.CHARFORMATA));

            public int dwMask;

            public int dwEffects;

            public int yHeight;

            public int yOffset;

            public int crTextColor;

            public byte bCharSet;

            public byte bPitchAndFamily;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szFaceName = new byte[32];
        }
    }
}
