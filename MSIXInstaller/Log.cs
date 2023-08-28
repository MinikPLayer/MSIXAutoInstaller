using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MSIXInstaller
{

    public static class Log
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public static void LogDebug(string message)
        {
            Debug.WriteLine(message);
        }

        public static void LogError(string message)
        {
            MessageBox(IntPtr.Zero, message, "Error", (uint)0x00000010L);
        }
    }
}
