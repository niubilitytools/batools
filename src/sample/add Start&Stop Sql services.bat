
reg add "HKEY_CLASSES_ROOT\Directory\shell\startsql" /ve /d "Start Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\startsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\startsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0startsql.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Drive\shell\startsql" /ve /d "Start Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\startsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\startsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0startsql.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\startsql" /ve /d "Start Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\startsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\startsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0startsql.bat\"" /f


echo installing stop services

reg add "HKEY_CLASSES_ROOT\Directory\shell\stopsql" /ve /d "Stop Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\stopsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\shell\stopsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0stopsql.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Drive\shell\stopsql" /ve /d "Stop Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\stopsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Drive\shell\stopsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0stopsql.bat\"" /f

reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\stopsql" /ve /d "Stop Sql Services" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\stopsql" /v "NoWorkingDirectory" /d "" /f
reg add "HKEY_CLASSES_ROOT\Directory\Background\shell\stopsql\command" /ve /d "%~sdp0runner.exe \"%~sdp0stopsql.bat\"" /f
 