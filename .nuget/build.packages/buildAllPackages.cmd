@ECHO OFF
SETLOCAL EnableDelayedExpansion

DEL packaging.log

ECHO BEGIN BUILDING PACKAGES >> packaging.log
ECHO ======================= >> packaging.log
ECHO. >> packaging.log
ECHO. >> packaging.log

REM Build all the packages

ECHO Building Packages

for /F "eol=; tokens=1" %%i in ('TYPE "%~2packages.list.txt"') do (
ECHO Packing : %%i
ECHO Package==^> %%i >> packaging.log
ECHO. >> packaging.log

IF EXIST "%~1%%i\%%~nxi.csproj" (
CALL "%~2buildPackage.cmd" "%~1" "%~1%%i\%%~nxi.csproj" %3 >> packaging.log 2>>&1
) ELSE (
CALL "%~2buildPackage.cmd" "%~1" "%~1%%i\%%~nxi.nuspec" %3 >> packaging.log 2>>&1
)

IF !errorlevel! NEQ 0 (
	ECHO Unable To Build Package!
	EXIT /B !errorLevel!
)

ECHO. >> packaging.log
ECHO == >> packaging.log
ECHO. >> packaging.log
)

ECHO. >> packaging.log

REM start notepad packaging.log
EXIT /B 0