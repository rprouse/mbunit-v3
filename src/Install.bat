@if not defined ECHO (echo off) else (echo %ECHO%)
REM
REM This script installs or uninstalls components.
REM

setlocal
set SRC_DIR=%~dp0
set BIN_DIR=%~dp0..\bin
set GACUTIL=%BIN_DIR%\gacutil.exe
if exist "%ProgramFiles(x86)%" (set GACUTIL40="%ProgramFiles(x86)%\Microsoft SDKs\Windows\v8.1A\Bin\NETFX 4.5.1 Tools\gacutil.exe") ELSE (set GACUTIL40="%PROGRAMFILES%\Microsoft SDKs\Windows\v8.1A\Bin\NETFX 4.5.1 Tools\gacutil.exe")
set ELEVATE=%BIN_DIR%\elevate.cmd
set REG=%BIN_DIR%\reg.exe

if "%~1"=="/x" (
    shift
) else (
    call "%ELEVATE%" "%~dpnx0" /x %*
    exit /b %ERRORLEVEL%
)

echo.
echo This script installs or uninstalls components built in the source tree
echo for local debugging purposes.
echo.
echo Choose the component to install or uninstall:
echo   1^) Install Gallio registry keys and plugins, including:
echo         - Reports
echo.
echo   0^) Uninstall all components.
echo.

:PROMPT
set ANSWER=%~1
if not defined ANSWER set /P ANSWER=Choice? 
echo.

if "%ANSWER%"=="1" call :INSTALL_GALLIO & goto :OK
if "%ANSWER%"=="0" call :UNINSTALL_GALLIO & goto :OK
goto :PROMPT

:OK
pause
exit /b 0


REM Install Gallio and installable components.
:INSTALL_GALLIO
echo ** Install Gallio. **
echo Adding registry keys.
"%REG%" ADD "HKEY_LOCAL_MACHINE\Software\Gallio.org\Gallio\0.0" /V InstallationFolder /D "%SRC_DIR%Gallio\Gallio" /F >nul
echo.

echo Installing plugins.
call "%SRC_DIR%Gallio.Utility.bat" Setup /install /v:verbose 
echo.
exit /b 0


REM Uninstalls Gallio.
:UNINSTALL_GALLIO
echo ** Uninstall Gallio. **
echo Deleting registry keys.
"%REG%" DELETE "HKEY_LOCAL_MACHINE\Software\Gallio.org\Gallio\0.0" /V InstallationFolder /F 2>nul >nul
echo.

echo Uninstalling plugins.
call "%SRC_DIR%Gallio.Utility.bat" Setup /uninstall /v:verbose 
echo.
exit /b 0
