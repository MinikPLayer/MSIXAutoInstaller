using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace MSIXInstaller
{
    internal class Program
    {
        public static bool IsAdministrator()
        {
            using (var identity = System.Security.Principal.WindowsIdentity.GetCurrent())
            {
                var principal = new System.Security.Principal.WindowsPrincipal(identity);
                return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
        }

        static void Run(string[] args)
        {
            // TODO: Add architecture detection
            string path = Directory.GetCurrentDirectory();
            if (args.Length > 0)
            {
                path = args[0];
            }
            else if (Directory.Exists("Data"))
            {
                path = Path.Combine(path, "Data");
            }
            else
            {
                Log.LogError("Installer data corrupted or misconfigured:\n\nCannot find installer data directory. ");
                return;
            }

            var certFiles = Directory.GetFiles(path, "*.cer");
            if (certFiles.Length == 0)
            {
                Log.LogError("No certificates found");
                return;
            }

            if (certFiles.Length > 1)
            {
                Log.LogError("Multiple certificates found");
                return;
            }

            var msixFiles = Directory.GetFiles(path, "*.msix");
            var appxFiles = Directory.GetFiles(path, "*.appx");

            var installerFiles = msixFiles.Concat(appxFiles).ToArray();
            if (installerFiles.Length == 0)
            {
                Log.LogError("No .msix or .appx packages found");
                return;
            }

            if (!IsAdministrator())
            {
                Log.LogError("This application must be run as administrator");
                return;
            }

            var certificatePath = certFiles[0];
            try
            {
                CertificateInstaller.InstallCertificate(certificatePath);
            }
            catch (Exception e)
            {
                Log.LogError($"Cannot install the certificate, {e.Message}");
            }

            try
            {
                foreach (var installerFile in installerFiles)
                    MSIXInstaller.InstallMSIX(installerFile);
            }
            catch (Exception e)
            {
                Log.LogError($"Error while installing packages - {e.Message}");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch (Exception e)
            {
                Log.LogError($"Unknown error occured - {e.Message}");
            }         
        }
    }
}