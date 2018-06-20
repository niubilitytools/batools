
@echo off

@echo ¿ªÆôIP´úÀí£º 

reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v AutoConfigURL /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyEnable /t REG_DWORD /d 1 /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyServer /d "10.97.18.71:80" /f
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /v ProxyOverride /t REG_SZ /d "<-loopback>;gold.xitu.io;xitu.io;azurewebsites.net;impservice.dictword.youdao.com;impservice.dictapp.youdao.com;logindict.youdao.com;cidian.youdao.com;fanyi.youdao.com;dict.youdao.com;localhost;has01.pfizer.com;ndhamrhas01;has02.pfizer.com;ndhamrhas02;has04.pfizer.com;ndhamrhas04;kvsj01.pfizer.com;ndhamrexj01vm;kvsj01s.pfizer.com;mopamrexj01ds;kvsj02.pfizer.com;mopamrexj02d;kvsj02s.pfizer.com;mopamrexj02ds;kvsj03.pfizer.com;mopamrexj03d;kvsj04.pfizer.com;ndhamrexj04vm;kvsj05.pfizer.com;mopamrexj05d;kvsj06.pfizer.com;mopamrexj06d;kvsj07.pfizer.com;mopamrexj07d;kvsj08.pfizer.com;mopamrexj08d;kvsj09.pfizer.com;mopamrexj09d;kvsj10.pfizer.com;ndhamrexj10;kvsj11.pfizer.com;ndhamrexj11;kvsmba01.pfizer.com;ndhamrexmba01;kvsmba02.pfizer.com;ndhamrexmba02vm;kvsmba03.pfizer.com;ndhamrexmba03vm;kvsmba04.pfizer.com;ndhamrexmba04;kvsmba05.pfizer.com;ndhamrexmba05;kvsmba06.pfizer.com;ndhamrexmba06;kvsmba07.pfizer.com;ndhamrexmba07;kvsmba08.pfizer.com;ndhamrexmba08;kvsmba09.pfizer.com;ndhamrexmba09;kvsmba10.pfizer.com;ndhamrexmba10;kvsmba11.pfizer.com;ndhamrexmba11;kvsmba12.pfizer.com;ndhamrexmba12;kvsmba13.pfizer.com;ndhamrexmba13;kvsmba14.pfizer.com;ndhamrexmba02s;kvsmba15.pfizer.com;ndhamrexmba01s;kvsmba20.pfizer.com;ndhamrexmba20;kvsmba21.pfizer.com;ndhamrexmba21;kvsmba22.pfizer.com;ndhamrexmba22;kvsmba23.pfizer.com;ndhamrexmba03s;kvsmba24.pfizer.com;ndhamrexmba24;kvsmba25.pfizer.com;ndhamrexmba25;kvsmba26.pfizer.com;ndhamrexmba26;kvsmba27.pfizer.com;ndhamrexmba27;<local>" /f
ipconfig /flushdns
start "" "C:\Program Files\Internet Explorer\iexplore.exe"
taskkill /f /im iexplore.exe
