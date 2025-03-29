echo off

echo *************************   WARNING  **************************
echo * In order to correctly compile the ECExplorer source files,  *
echo * be sure to have the C# compiler (csc.exe) path in your      *
echo * system path (control panel - system - advanced system       *
echo * properties - environment variables - user variables).       *
echo * The C# compiler path depends on the .NET Framework in       *
echo * your system but is generally something like                 *
echo * "C:\Windows\Microsoft.NET\Framework\v4.0.xxxxx".            *
echo ***************************************************************

csc.exe /target:winexe /platform:anycpu /out:ECExplorer.exe /nowin32manifest /doc:ECExplorer.xml /reference:OpenHardwareMonitorLib.dll *.cs

pause