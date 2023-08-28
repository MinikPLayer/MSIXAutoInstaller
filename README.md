# MSIXInstaller
By default MSIX packages require a signed certificate (which is expensive) or for the user to install self-signed certificate manually (which is tedious and hard for end user). 

This installer automates this process by automatically installing the certificate and then launching app installer.

# Usage
Download the MSIX Installer for your target architecture from [releases](https://github.com/MinikPLayer/MSIXInstaller/releases/latest)

Put it into target directory, then place your published MSIX files into the "MSIX" folder.

In MSIX directory there should be only one .cer file, which will be automatically placed into the Trusted People certificate store

Installer will then launch Windows App Installer for every .msix file inside the MSIX directory (not recursive)
