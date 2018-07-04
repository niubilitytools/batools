@echo off
setlocal enabledelayedexpansion
for /f "usebackq delims=" %%i in (`vswhere -all -property installationPath`) do (
  if /i "%1"=="cache" (
    set args=repair --cache
  ) else (
    set args=modify --nocache
  )
  start /wait /d "%ProgramFiles(x86)%\Microsoft Visual Studio\Installer" vs_installer.exe !args! --installPath "%%i" --passive --norestart
  if "%ERRORLEVEL%"=="3010" set REBOOTREQUIRED=1
)
if "%REBOOTREQUIRED%"=="1" (
  echo Please restart your machine
  exit /b 3010
)