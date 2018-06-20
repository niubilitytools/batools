
@echo off 
echo ¹Ø±Õ´úÀí£º 

reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v AutoConfigURL /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyEnable /t REG_DWORD /d 0 /f 
ipconfig /flushdns
start "" "C:\Program Files\Internet Explorer\iexplore.exe"
taskkill /f /im iexplore.exe
 