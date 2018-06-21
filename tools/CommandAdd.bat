@echo off
echo ÃÌº”√¸¡ÓµΩ”“º¸≤Àµ•

set key=ProxyDisable
set name=Proxy Disable


reg add "HKEY_CLASSES_ROOT\Drive\shell\%key%" /ve /d "%name%" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\%key%" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\%key%\command" /ve /d "%~sdp0runas.exe \"%~sdp0%key%.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Directory\shell\%key%" /ve /d "%name%" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\%key%" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\%key%\command" /ve /d "%~sdp0runas.exe \"%~sdp0%key%.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\%key%" /ve /d "%name%" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\%key%" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\%key%\command" /ve /d "%~sdp0runas.exe \"%~sdp0%key%.bat\"" /f

reg add "HKEY_CLASSES_ROOT\LibraryFolder\shell\%key%" /ve /d "%name%" /f
reg add "HKEY_CLASSES_ROOT\LibraryFolder\shell\%key%" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\LibraryFolder\shell\%key%\command" /ve /d "%~sdp0runas.exe \"%~sdp0%key%.bat\"" /f

reg add "HKEY_CLASSES_ROOT\LibraryFolder\Background\shell\%key%" /ve /d "%name%" /f
reg add "HKEY_CLASSES_ROOT\LibraryFolder\Background\shell\%key%" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\LibraryFolder\Background\shell\%key%\command" /ve /d "%~sdp0runas.exe \"%~sdp0%key%.bat\"" /f
