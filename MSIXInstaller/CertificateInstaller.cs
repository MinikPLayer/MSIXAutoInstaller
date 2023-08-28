using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSIXInstaller
{
    public class CertificateInstaller
    {
        public static void InstallCertificate(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var store = new System.Security.Cryptography.X509Certificates.X509Store(System.Security.Cryptography.X509Certificates.StoreName.TrustedPeople, System.Security.Cryptography.X509Certificates.StoreLocation.LocalMachine);
            store.Open(System.Security.Cryptography.X509Certificates.OpenFlags.ReadWrite);
            var certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2(bytes);
            store.Add(certificate);
            store.Close();

            Debug.WriteLine($"Installed certificate from {path}");
        }
    }
}
