# MSIXInstaller / APPXInstaller
By default MSIX / APPX packages require a signed certificate (which is expensive) or for the user to install a self-signed certificate manually (which is tedious and hard for the end user). 

This installer automates this process by automatically installing the certificate and then launching app installer.

# Usage
Download the MSIX / APPX Installer for your target architecture from [releases](https://github.com/MinikPLayer/MSIXInstaller/releases/latest)

Put it into target directory, then place your published MSIX / APPX files into the "Data" folder.

In Data directory there should be only one .cer file, which will be automatically placed into the Trusted People certificate store.

Installer will then launch Windows App Installer for every .msix / .appx file inside the Data directory (not recursive).

# Portable version
Portable version can be run on any architecture, but requires **Installer.dll** and **Installer.runtimeconfig.json** to be placed alongisde **Installer.exe** file to run. 

Required files are packed into Installer_portable.zip file that can be downloaded from the releases page.
