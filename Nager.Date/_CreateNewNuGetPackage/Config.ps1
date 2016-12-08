#==========================================================
# Edit the variable values below to configure how your .nupkg file is packed (i.e. created) and pushed (i.e. uploaded) to the NuGet gallery.
#
# If you have modified this script:
#	- if you uninstall the "Create New NuGet Package From Project After Each Build" package, this file may not be removed automatically; you may need to manually delete it.
#	- if you update the "Create New NuGet Package From Project After Each Build" package, this file may not be updated unless you specify it to be overwritten, either by 
#		confirming the overwrite if prompted, or by providing the "-FileConflictAction Overwrite" parameter when installing from the command line.
#		If you overwrite this file then your custom changes will be lost, and you will need to manually reapply your changes.
#		If you are not using source control, I recommend backing up this file before updating the package so you can see what changes you had made to it.
#==========================================================

#------------------------------------------------
# Pack parameters used to create the .nupkg file.
#------------------------------------------------

# Specify the Version Number to use for the NuGet package. If not specified, the version number of the assembly being packed will be used.
# NuGet version number guidance: https://docs.nuget.org/docs/reference/versioning and the Semantic Versioning spec: http://semver.org/
# e.g. "" (use assembly's version), "1.2.3" (stable version), "1.2.3-alpha" (prerelease version).
$versionNumber = ""

# Specify any Release Notes for this package. 
# These will only be included in the package if you have a .nuspec file for the project in the same directory as the project file.
$releaseNotes = ""

# Specify a specific Configuration and/or Platform to only create a NuGet package when building the project with this Configuration and/or Platform.
#	e.g. $configuration = "Release"
#		 $platform = "AnyCPU"
$configuration = ""
$platform = ""

# Specify any NuGet Pack Properties to pass to MsBuild.
#	e.g. $packProperties = "TargetFrameworkVersion=v3.5;Optimize=true"
# Do not specify the "Configuration" or "Platform" here; use the $configuration and $platform variables above.
# MsBuild Properties that can be specified: http://msdn.microsoft.com/en-us/library/vstudio/bb629394.aspx
$packProperties = ""

# Specify any NuGet Pack options to pass to nuget.exe.
#	e.g. $packOptions = "-Symbols"
#	e.g. $packOptions = "-IncludeReferencedProjects -Symbols"
# Do not specify a "-Version" (use $versionNumber above), "-OutputDirectory", or "-NonInteractive", as these are already provided.
# Do not specify any "-Properties" here; instead use the $packProperties variable above.
# Do not specify "-Build", as this may result in an infinite build loop.
# NuGet Pack options that can be specified: http://docs.nuget.org/docs/reference/command-line-reference#Pack_Command_Options
# Use "-Symbols" to also create a symbols package. When pushing your package, the symbols package will automatically be detected and pushed as well: https://www.symbolsource.org/Public/Wiki/Publishing
$packOptions = ""

# Specify $true if the generated .nupkg file should be renamed to include the Configuration and Platform that was used to build the project, $false if not.
#	e.g. If $true, MyProject.1.1.5.6.nupkg might be renamed to MyProject.1.1.5.6.Debug.AnyCPU.nupkg
#	e.g. If $true, MyProject.1.1.5.6-beta1.nupkg might re renamed to MyProject.1.1.5.6-beta1.Release.x86.nupkg
$appendConfigurationAndPlatformToNuGetPackageFileName = $true


#------------------------------------------------
# Push parameters used to upload the .nupkg file to the NuGet gallery.
#------------------------------------------------

# The NuGet gallery to upload to. If not provided, the DefaultPushSource in your NuGet.config file is used (typically nuget.org).
$sourceToUploadTo = ""

# The API Key to use to upload the package to the gallery. If not provided and a system-level one does not exist for the specified Source, you will be prompted for it.
$apiKey = ""

# Specify any NuGet Push options to pass to nuget.exe.
#	e.g. $pushOptions = "-Timeout 120"
# Do not specify the "-Source" or "-ApiKey" here; use the variables above.
# NuGet Push options that can be specified: http://docs.nuget.org/docs/reference/command-line-reference#Push_Command_Options
$pushOptions = ""
