@ECHO OFF

set localRepositoryFolder=C:\Dev\nuget.repository\.development
echo The local repository folder is "%localRepositoryFolder%"

if not exist %localRepositoryFolder% (
	ECHO The local repository folder has been created.
	mkdir %localRepositoryFolder%
)

"%~1.nuget\nuget.exe" pack "%~2" -OutputDirectory "C:\Dev\nuget.repository\.development"  -Prop Configuration=%3
