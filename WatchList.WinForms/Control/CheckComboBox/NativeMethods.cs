using System.Runtime.InteropServices;

namespace TestTask.Controls.CheckComboBox
{
    internal static class NativeMethods
    {
        internal const int WM_NCHITTEST = 0x0084;
        internal const int WM_NCACTIVATE = 0x0086;
        internal const int WS_EX_NOACTIVATE = 0x08000000;
        internal const int HTTRANSPARENT = -1;
        internal const int HTLEFT = 10;
        internal const int HTRIGHT = 11;
        internal const int HTTOP = 12;
        internal const int HTTOPLEFT = 13;
        internal const int HTTOPRIGHT = 14;
        internal const int HTBOTTOM = 15;
        internal const int HTBOTTOMLEFT = 16;
        internal const int HTBOTTOMRIGHT = 17;
        internal const int WM_USER = 0x0400;
        internal const int WM_REFLECT = WM_USER + 0x1C00;
        internal const int WM_COMMAND = 0x0111;
        internal const int CBN_DROPDOWN = 7;
        internal const int WM_GETMINMAXINFO = 0x0024;
        internal const int MAX_VALUES = 0xffff;
        internal const int VALUE_SIXTEEN = 16;

        internal static int HIWORD(int n) => (n >> VALUE_SIXTEEN) & MAX_VALUES;

        internal static int HIWORD(IntPtr n) => HIWORD(unchecked((int)(long)n));

        internal static int LOWORD(int n) => n & MAX_VALUES;

        internal static int LOWORD(IntPtr n) => LOWORD(unchecked((int)(long)n));

        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }
    }
}
