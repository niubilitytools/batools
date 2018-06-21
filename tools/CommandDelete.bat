@echo off

set key=ProxyIp
set name=Proxy Ip

reg delete "HKEY_CLASSES_ROOT\Directory\shell\%key%" /f
reg delete "HKEY_CLASSES_ROOT\Drive\shell\%key%" /f
reg delete "HKEY_CLASSES_ROOT\Directory\Background\shell\%key%" /f

