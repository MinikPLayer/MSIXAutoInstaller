using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIXInstaller
{
    public static class MSIXInstaller
    {
        public static void InstallMSIX(string msixFile)
        {
            var process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = msixFile;

            process.Start();
        }
    }
}
