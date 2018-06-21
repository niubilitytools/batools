
@echo off 
echo 开启自动代理： 
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v AutoConfigURL /t REG_SZ /d "autoproxy.pfizer.com" /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyEnable /t REG_DWORD /d 0 /f 

ipconfig /flushdns
start "" "C:\Program Files\Internet Explorer\iexplore.exe"
taskkill /f /im iexplore.exe
