#Requires -Version 2.0
<#
	.SYNOPSIS
	Creates a NuGet Package (.nupkg) file from the given Project or NuSpec file, and optionally uploads it to a NuGet Gallery.
	
	.DESCRIPTION
	Creates a NuGet Package (.nupkg) file from the given Project or NuSpec file.
	Additional parameters may be provided to also upload the new NuGet package to a NuGet Gallery.
    If an "-OutputDirectory" is not provided via the PackOptions parameter, the default is to place the .nupkg file in a "New-NuGetPackages" directory in the same directory as the .nuspec or project file being packed.
    If a NuGet Package file is specified (rather than a Project or NuSpec file), we will simply push that package to the NuGet Gallery.
	
	.PARAMETER NuSpecFilePath
	The path to the .nuspec file to pack.
	If you intend to pack a project file that has an accompanying .nuspec file, use the ProjectFilePath parameter instead.

	.PARAMETER ProjectFilePath
	The path to the project file (e.g. .csproj, .vbproj, .fsproj) to pack.
	If packing a project file that has an accompanying .nuspec file, the nuspec file will automatically be picked up by the NuGet executable.

    .PARAMETER PackageFilePath
    The path to the NuGet package file (.nupkg) to push to the NuGet gallery.
    If provided a new package will not be created; we will simply push to specified NuGet package to the NuGet gallery.

	.PARAMETER VersionNumber
	The version number to use for the NuGet package.
	The version element in the .nuspec file (if available) will be updated with the given value unless the DoNotUpdateNuSpecFile switch is provided.
	If this parameter is not provided then you will be prompted for the version number to use (unless the NoPrompt or NoPromptForVersionNumber switch is provided).
	If the "-Version" parameter is provided in the PackOptions, that version will be used for the NuGet package, but this version will be used to update the .nuspec file (if available).

	.PARAMETER ReleaseNotes
	The release notes to use for the NuGet package.
	The release notes element in the .nuspec file (if available) will be updated with the given value unless the DoNotUpdateNuSpecFile switch is provided.
	
	.PARAMETER PackOptions
	The arguments to pass to NuGet's Pack command. These will be passed to the NuGet executable as-is, so be sure to follow the NuGet's required syntax.	
	By default this is set to "-Build" in order to be able to create a package from a project that has not been manually built yet.
	See http://docs.nuget.org/docs/reference/command-line-reference for valid parameters.

	.PARAMETER PushPackageToNuGetGallery
	If this switch is provided the NuGet package will be pushed to the NuGet gallery.
	Use the PushOptions to specify a custom gallery to push to, or an API key if required.

	.PARAMETER PushOptions
	The arguments to pass to NuGet's Push command. These will be passed to the NuGet executable as-is, so be sure to follow the NuGet's required syntax.	
	See http://docs.nuget.org/docs/reference/command-line-reference for valid parameters.

    .PARAMETER DeletePackageAfterPush
    If this switch is provided and the package is successfully pushed to a NuGet gallery, the NuGet package file will then be deleted.
	
	.PARAMETER NoPrompt
	If this switch is provided the user will not be prompted for the version number or release notes; the current ones in the .nuspec file will be used (if available).
	The user will not be prompted for any other form of input either, such as if they want to push the package to a gallery, or to give input before the script exits when an error occurs.
    This parameter should be provided when an automated mechanism is running this script (e.g. an automated build system).
	
	.PARAMETER NoPromptExceptOnError
	The same as NoPrompt except if an error occurs the user will be prompted for input before the script exists, making sure they are notified that an error occurred.
	If both this and the NoPrompt switch are provided, the NoPrompt switch will be used.
	If both this and the NoPromptForInputOnError switch are provided, it is the same as providing the NoPrompt switch.
	
	.PARAMETER NoPromptForVersionNumber
	If this switch is provided the user will not be prompted for the version number; the one in the .nuspec file will be used (if available).
	
	.PARAMETER NoPromptForReleaseNotes
	If this switch is provided the user will not be prompted for the release notes; the ones in the .nuspec file will be used (if available).
	
	.PARAMETER NoPromptForPushPackageToNuGetGallery
	If this switch is provided the user will not be asked if they want to push the new package to the NuGet Gallery when the PushPackageToNuGetGallery switch is not provided.	
	
	.PARAMETER NoPromptForInputOnError
	If this switch is provided the user will not be prompted for input before the script exits when an error occurs, so they may not notice than an error occurred.	
	
	.PARAMETER UsePowerShellPrompts
	If this switch is provided any prompts for user input will be made via the PowerShell console, rather than the regular GUI components.
	This may be preferable when attempting to pipe input into the cmdlet.
	
	.PARAMETER DoNotUpdateNuSpecFile
	If this switch is provided a backup of the .nuspec file (if available) will be made, changes will be made to the original .nuspec file in order to 
	properly perform the pack, and then the original file will be restored once the pack is complete.

	.PARAMETER NuGetExecutableFilePath
	The full path to NuGet.exe.
	If not provided it is assumed that NuGet.exe is in the same directory as this script, or that NuGet.exe has been added to your PATH and can be called directly from the command prompt.

	.PARAMETER UpdateNuGetExecutable
	If this switch is provided "NuGet.exe update -self" will be performed before packing or pushing anything.
	Provide this switch to ensure your NuGet executable is always up-to-date on the latest version.

	.EXAMPLE
	& .\New-NuGetPackage.ps1

	Run the script without any parameters (e.g. as if it was ran directly from Windows Explorer).
	This will prompt the user for a .nuspec, project, or .nupkg file if one is not found in the same directory as the script, as well as for any other input that is required.
	This assumes that you are currently in the same directory as the New-NuGetPackage.ps1 script, since a relative path is supplied.

	.EXAMPLE
	& "C:\Some Folder\New-NuGetPackage.ps1" -NuSpecFilePath ".\Some Folder\SomeNuSpecFile.nuspec" -Verbose

	Create a new package from the SomeNuSpecFile.nuspec file.
	This can be ran from any directory since an absolute path to the New-NuGetPackage.ps1 script is supplied.
	Additional information will be displayed about the operations being performed because the -Verbose switch was supplied.
	
	.EXAMPLE
	& .\New-NuGetPackage.ps1 -ProjectFilePath "C:\Some Folder\TestProject.csproj" -VersionNumber "1.1" -ReleaseNotes "Version 1.1 contains many bug fixes."

	Create a new package from the TestProject.csproj file.
	Because the VersionNumber and ReleaseNotes parameters are provided, the user will not be prompted for them.
	If "C:\Some Folder\TestProject.nuspec" exists, it will automatically be picked up and used when creating the package; if it contained a version number or release notes, they will be overwritten with the ones provided.

	.EXAMPLE
	& .\New-NuGetPackage.ps1 -ProjectFilePath "C:\Some Folder\TestProject.csproj" -PackOptions "-Build -OutputDirectory ""C:\Output""" -UsePowerShellPrompts

	Create a new package from the TestProject.csproj file, building the project before packing it and saving the  package in "C:\Output".
	Because the UsePowerShellPrompts parameter was provided, all prompts will be made via the PowerShell console instead of GUI popups.
	
	.EXAMPLE
	& .\New-NuGetPackage.ps1 -NuSpecFilePath "C:\Some Folder\SomeNuSpecFile.nuspec" -NoPrompt
	
	Create a new package from SomeNuSpecFile.nuspec without prompting the user for anything, so the existing version number and release notes in the .nuspec file will be used.
	
	.EXAMPLE	
	& .\New-NuGetPackage.ps1 -NuSpecFilePath ".\Some Folder\SomeNuSpecFile.nuspec" -VersionNumber "9.9.9.9" -DoNotUpdateNuSpecFile
	
	Create a new package with version number "9.9.9.9" from SomeNuSpecFile.nuspec without saving the changes to the file.
	
	.EXAMPLE
	& .\New-NuGetPackage.ps1 -NuSpecFilePath "C:\Some Folder\SomeNuSpecFile.nuspec" -PushPackageToNuGetGallery -PushOptions "-Source ""http://my.server.com/MyNuGetGallery"" -ApiKey ""EAE1E980-5ECB-4453-9623-F0A0250E3A57"""
	
	Create a new package from SomeNuSpecFile.nuspec and push it to a custom NuGet gallery using the user's unique Api Key.
	
	.EXAMPLE
	& .\New-NuGetPackage.ps1 -NuSpecFilePath "C:\Some Folder\SomeNuSpecFile.nuspec" -NuGetExecutableFilePath "C:\Utils\NuGet.exe"

	Create a new package from SomeNuSpecFile.nuspec by specifying the path to the NuGet executable (required when NuGet.exe is not in the user's PATH).

    .EXAMPLE
    & New-NuGetPackage.ps1 -PackageFilePath "C:\Some Folder\MyPackage.nupkg"

    Push the existing "MyPackage.nupkg" file to the NuGet gallery.
    User will be prompted to confirm that they want to push the package; to avoid this prompt supply the -PushPackageToNuGetGallery switch.

	.EXAMPLE
	& .\New-NuGetPackage.ps1 -NoPromptForInputOnError -UpdateNuGetExecutable

	Create a new package or push an existing package by auto-finding the .nuspec, project, or .nupkg file to use, and prompting for one if none are found.
	Will not prompt the user for input before exitting the script when an error occurs.

	.OUTPUTS
	Returns the full path to the NuGet package that was created.
	If a NuGet package was not required to be created (e.g. you were just pushing an existing package), then nothing is returned.
	Use the -Verbose switch to see more detailed information about the operations performed.
	
	.LINK
	Project home: https://newnugetpackage.codeplex.com

	.NOTES
	Author: Daniel Schroeder
	Version: 1.5.6
	
	This script is designed to be called from PowerShell or ran directly from Windows Explorer.
	If this script is ran without the $NuSpecFilePath, $ProjectFilePath, and $PackageFilePath parameters, it will automatically search for a .nuspec, project, or package file in the 
	same directory as the script and use it if one is found. If none or more than one are found, the user will be prompted to specify the file to use.
#>
[CmdletBinding(DefaultParameterSetName="PackUsingNuSpec")]
param
(
	[parameter(Position=1,Mandatory=$false,ParameterSetName="PackUsingNuSpec")]
	[ValidateScript({Test-Path $_ -PathType Leaf})]
	[string] $NuSpecFilePath,

	[parameter(Position=1,Mandatory=$false,ParameterSetName="PackUsingProject")]
	[ValidateScript({Test-Path $_ -PathType Leaf})]
	[string] $ProjectFilePath,
    
    [parameter(Position=1,Mandatory=$false,ParameterSetName="PushExistingPackage")]
	[ValidateScript({Test-Path $_ -PathType Leaf})]
    [string] $PackageFilePath,

	[parameter(Position=2,Mandatory=$false,HelpMessage="The new version number to use for the NuGet Package.",ParameterSetName="PackUsingNuSpec")]
    [parameter(Position=2,Mandatory=$false,HelpMessage="The new version number to use for the NuGet Package.",ParameterSetName="PackUsingProject")]
	[ValidatePattern('(?i)(^(\d+(\.\d+){1,3})$)|(^(\d+\.\d+\.\d+-[a-zA-Z0-9\-\.\+]+)$)|(^(\$version\$)$)|(^$)')]	# This validation is duplicated in the Update-NuSpecFile function, so update it in both places. This regex does not represent Sematic Versioning, but the versioning that NuGet.exe allows.
	[Alias("Version")]
	[Alias("V")]
	[string] $VersionNumber,

    [parameter(ParameterSetName="PackUsingNuSpec")]
    [parameter(ParameterSetName="PackUsingProject")]
	[Alias("Notes")]
	[string] $ReleaseNotes,
	
    [parameter(ParameterSetName="PackUsingNuSpec")]
    [parameter(ParameterSetName="PackUsingProject")]
	[Alias("PO")]
	[string] $PackOptions = "-Build",	# Build projects by default to make sure the files to pack exist.

	[Alias("Push")]
	[switch] $PushPackageToNuGetGallery,

	[string] $PushOptions,

    [Alias("DPAP")]
    [switch] $DeletePackageAfterPush,
	
	[Alias("NP")]
	[switch] $NoPrompt,
	
	[Alias("NPEOE")]
	[switch] $NoPromptExceptOnError,

    [parameter(ParameterSetName="PackUsingNuSpec")]
    [parameter(ParameterSetName="PackUsingProject")]	
	[Alias("NPFVN")]
	[switch] $NoPromptForVersionNumber,
	
    [parameter(ParameterSetName="PackUsingNuSpec")]
    [parameter(ParameterSetName="PackUsingProject")]
	[Alias("NPFRN")]
	[switch] $NoPromptForReleaseNotes,
	
	[Alias("NPFPPTNG")]
	[switch] $NoPromptForPushPackageToNuGetGallery,
	
	[Alias("NPFIOE")]
	[switch] $NoPromptForInputOnError,
	
	[Alias("UPSP")]
	[switch] $UsePowerShellPrompts,
	
    [parameter(ParameterSetName="PackUsingNuSpec")]
    [parameter(ParameterSetName="PackUsingProject")]
	[Alias("NoUpdate")]
	[switch] $DoNotUpdateNuSpecFile,
	
	[Alias("NuGet")]
	[string] $NuGetExecutableFilePath,
	
	[Alias("UNE")]
	[switch] $UpdateNuGetExecutable
)

# Turn on Strict Mode to help catch syntax-related errors.
# 	This must come after a script's/function's param section.
# 	Forces a function to be the first non-comment code to appear in a PowerShell Module.
Set-StrictMode -Version Latest

# Default the ParameterSet variables that may not have been set depending on which parameter set is being used. This is required for PowerShell v2.0 compatibility.
if (!(Test-Path Variable:Private:NuSpecFilePath)) { $NuSpecFilePath = $null }
if (!(Test-Path Variable:Private:ProjectFilePath)) { $ProjectFilePath = $null }
if (!(Test-Path Variable:Private:PackageFilePath)) { $PackageFilePath = $null }
if (!(Test-Path Variable:Private:VersionNumber)) { $VersionNumber = $null }
if (!(Test-Path Variable:Private:ReleaseNotes)) { $ReleaseNotes = $null }
if (!(Test-Path Variable:Private:PackOptions)) { $PackOptions = $null }
if (!(Test-Path Variable:Private:NoPromptForVersionNumber)) { $NoPromptForVersionNumber = $false }
if (!(Test-Path Variable:Private:NoPromptForReleaseNotes)) { $NoPromptForReleaseNotes = $false }
if (!(Test-Path Variable:Private:DoNotUpdateNuSpecFile)) { $DoNotUpdateNuSpecFile = $false }


#==========================================================
# Define any necessary global variables, such as file paths.
#==========================================================

# Import any necessary assemblies.
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName Microsoft.VisualBasic

# Get the directory that this script is in.
$THIS_SCRIPTS_DIRECTORY_PATH = Split-Path $script:MyInvocation.MyCommand.Path

# The list of project type extensions that NuGet supports packing.
$VALID_NUGET_PROJECT_TYPE_EXTENSIONS_ARRAY = @(".csproj", ".vbproj", ".fsproj")

$VALID_NUGET_PROJECT_TYPE_EXTENSIONS_WITH_WILDCARD_ARRAY = @()
foreach ($extension in $VALID_NUGET_PROJECT_TYPE_EXTENSIONS_ARRAY)
{ 
	$VALID_NUGET_PROJECT_TYPE_EXTENSIONS_WITH_WILDCARD_ARRAY += "*$extension"
}

# The directory to put the NuGet package into if one is not supplied.
$DEFAULT_DIRECTORY_TO_PUT_NUGET_PACKAGES_IN = "New-NuGetPackages"

# The file path where the API keys are saved.
$NUGET_CONFIG_FILE_PATH = Join-Path $env:APPDATA "NuGet\NuGet.config"

# The default NuGet source to push to when one is not explicitly provided.
$DEFAULT_NUGET_SOURCE_TO_PUSH_TO = "https://www.nuget.org"

#==========================================================
# Strings to look for in console app output.
# If running in a non-english language, these strings will need to be changed to the strings returned by the console apps when running in the non-english language.
#==========================================================

# TF.exe output strings.
$TF_EXE_NO_WORKING_FOLDER_MAPPING_ERROR_MESSAGE = 'There is no working folder mapping for'
$TF_EXE_NO_PENDING_CHANGES_MESSAGE = 'There are no pending changes.'
$TF_EXE_KEYWORD_IN_PENDING_CHANGES_MESSAGE = 'change\(s\)'	# Escape regular expression characters.

# NuGet.exe output strings.
$NUGET_EXE_SUCCESSFULLY_CREATED_PACKAGE_MESSAGE_REGEX = [regex] "(?i)(Successfully created package '(?<FilePath>.*?)'.)"
$NUGET_EXE_SUCCESSFULLY_PUSHED_PACKAGE_MESSAGE = 'Your package was pushed.'
$NUGET_EXE_SUCCESSFULLY_SAVED_API_KEY_MESSAGE = "The API Key '{0}' was saved for '{1}'."
$NUGET_EXE_SUCCESSFULLY_UPDATED_TO_NEW_VERSION = 'Update successful.'

#==========================================================
# Define functions used by the script.
#==========================================================

# Catch any exceptions thrown, display the error message, wait for input if appropriate, and then stop the script.
trap [Exception] 
{
	$errorMessage = $_
	Write-Host "An error occurred while running New-NuGetPackage script:`n$errorMessage`n" -Foreground Red
	
	if (!$NoPromptForInputOnError)
	{
		# If we should prompt directly from PowerShell.
		if ($UsePowerShellPrompts)
		{
			Write-Host "Press any key to continue ..."
			$x = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyUp")
		}
		# Else use a nice GUI prompt.
		else
		{
			$VersionNumber = Read-MessageBoxDialog -Message $errorMessage -WindowTitle "Error Occurred Running New-NuGetPackage Script" -Buttons OK -Icon Error
		}
	}
	break
}

# Function to return the path to backup the NuSpec file to if needed.
function Get-NuSpecBackupFilePath { return "$NuSpecFilePath.backup" }

# PowerShell v2.0 compatible version of [string]::IsNullOrWhitespace.
function Test-StringIsNullOrWhitespace([string] $string)
{
    if ($string -ne $null) { $string = $string.Trim() }
    return [string]::IsNullOrEmpty($string)
}

# Function to update the $NuSpecFilePath (.nuspec file) with the appropriate information before using it to create the NuGet package.
function Update-NuSpecFile
{
	Write-Verbose "Starting process to update the nuspec file '$NuSpecFilePath'..."

    # If we don't have a NuSpec file to update, throw an error that something went wrong.
    if (!(Test-Path $NuSpecFilePath))
    {
        throw "The Update-NuSpecFile function was called with an invalid NuSpecFilePath; this should not happen. There must be a bug in this script."
    }

	# Validate that the NuSpec file is a valid xml file.
	try
	{
		$nuSpecXml = New-Object System.Xml.XmlDocument
		$nuSpecXml.Load($NuSpecFilePath)	# Will throw an exception if it is unable to load the xml properly.
		$nuSpecXml = $null					# Release the memory.
	}
	catch
	{
		throw ("An error occurred loading the nuspec xml file '{0}': {1}" -f $NuSpecFilePath, $_.Exception.Message)
	}

    # Get the NuSpec file contents and Last Write Time before we make any changes to it, so we can determine if we did in fact make changes to it later (and undo the checkout from TFS if we didn't).
    $script:nuSpecFileContentsBeforeCheckout = [System.IO.File]::ReadAllText($NuSpecFilePath)
	$script:nuSpecLastWriteTimeBeforeCheckout = [System.IO.File]::GetLastWriteTime($NuSpecFilePath)

	# Try and check the file out of TFS.
    $script:nuSpecFileWasAlreadyCheckedOut = Tfs-IsItemCheckedOut -Path $NuSpecFilePath
	if ($script:nuSpecFileWasAlreadyCheckedOut -eq $false) { Tfs-Checkout -Path $NuSpecFilePath }
	
	# If we shouldn't update to the .nuspec file permanently, create a backup that we can restore from after.
	if ($DoNotUpdateNuSpecFile)
	{
		Copy-Item -Path $NuSpecFilePath -Destination (Get-NuSpecBackupFilePath) -Force
	}

	# Get the current version number from the .nuspec file.
	$currentVersionNumber = Get-NuSpecVersionNumber -NuSpecFilePath $NuSpecFilePath

	# If an explicit Version Number was not provided, prompt for it.
	if (Test-StringIsNullOrWhitespace $VersionNumber)
	{
		# If we shouldn't prompt for a version number, just use the existing one from the NuSpec file (if it exists).
		if ($NoPromptForVersionNumber)
		{
			$VersionNumber = $currentVersionNumber
		}
		# Else prompt the user for the version number to use.
		else
		{
			$promptMessage = 'Enter the NuGet package version number to use (x.x[.x.x] or $version$ if packing a project file)'
			
			# If we should prompt directly from PowerShell.
			if ($UsePowerShellPrompts)
			{
				$VersionNumber = Read-Host "$promptMessage. Current value in the .nuspec file is:`n$currentVersionNumber`n"
			}
			# Else use a nice GUI prompt.
			else
			{
				$VersionNumber = Read-InputBoxDialog -Message "$promptMessage`:" -WindowTitle "NuGet Package Version Number" -DefaultText $currentVersionNumber
			}
		}
		
		# The script's parameter validation does not seem to be enforced (probably because this is inside a function), so re-enforce it here.
		$rxVersionNumberValidation = [regex] '(?i)(^(\d+(\.\d+){1,3})$)|(^(\d+\.\d+\.\d+-[a-zA-Z0-9\-\.\+]+)$)|(^(\$version\$)$)|(^$)'	# This validation is duplicated in the Update-NuSpecFile function, so update it in both places. This regex does not represent Sematic Versioning, but the versioning that NuGet.exe allows.

		# If the user cancelled the prompt or did not provide a valid version number, exit the script.
		if ((Test-StringIsNullOrWhitespace $VersionNumber) -or !$rxVersionNumberValidation.IsMatch($VersionNumber))
		{
			throw "A valid version number to use for the NuGet package was not provided, so exiting script. The version number provided was '$VersionNumber', which does not conform to the Semantic Versioning guidelines specified at http://semver.org."
		}
	}
	
	# Insert the given version number into the .nuspec file, if it is different.
	if ($currentVersionNumber -ne $VersionNumber)
	{
		Set-NuSpecVersionNumber -NuSpecFilePath $NuSpecFilePath -NewVersionNumber $VersionNumber
	}
	
	# Get the current release notes from the .nuspec file.
	$currentReleaseNotes = Get-NuSpecReleaseNotes -NuSpecFilePath $NuSpecFilePath
	
	# If the Release Notes were not provided, prompt for them.
	if (Test-StringIsNullOrWhitespace $ReleaseNotes)
	{		
		# If we shouldn't prompt for the release notes, just use the existing ones from the NuSpec file (if it exists).
		if ($NoPromptForReleaseNotes)
		{
			$ReleaseNotes = $currentReleaseNotes
		}
		# Else prompt the user for the Release Notes to add to the .nuspec file.
		else
		{
			$promptMessage = "Please enter the release notes to include in the new NuGet package"
			
			# If we should prompt directly from PowerShell.
			if ($UsePowerShellPrompts)
			{
				$ReleaseNotes = Read-Host "$promptMessage. Current value in the .nuspec file is:`n$currentReleaseNotes`n"
			}
			# Else use a nice GUI prompt.
			else
			{
				$ReleaseNotes = Read-MultiLineInputBoxDialog -Message "$promptMessage`:" -WindowTitle "Enter Release Notes For New Package" -DefaultText $currentReleaseNotes
			}
			
			# If the user cancelled the release notes prompt, exit the script.
			if ($ReleaseNotes -eq $null)
			{ 
				throw "User cancelled the Release Notes prompt, so exiting script."
			}
		}		
	}

	# Insert the given Release Notes into the .nuspec file if some were provided, and they are different than the current ones.
	if ($currentReleaseNotes -ne $ReleaseNotes)
	{
		Set-NuSpecReleaseNotes -NuSpecFilePath $NuSpecFilePath -NewReleaseNotes $ReleaseNotes
	}
	
	Write-Verbose "Finished process to update the nuspec file '$NuSpecFilePath'."
}

function Get-NuSpecVersionNumber([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string] $NuSpecFilePath)
{	
	# Read in the file contents and return the version element's value.
    $fileContents = New-Object System.Xml.XmlDocument
    $fileContents.Load($NuSpecFilePath)
	return Get-XmlElementsTextValue -XmlDocument $fileContents -ElementPath "package.metadata.version"
}

function Set-NuSpecVersionNumber([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string] $NuSpecFilePath, [parameter(Position=2,Mandatory=$true)][string] $NewVersionNumber)
{	
	# Read in the file contents, update the version element's value, and save the file.
	$fileContents = New-Object System.Xml.XmlDocument
    $fileContents.Load($NuSpecFilePath)
	Set-XmlElementsTextValue -XmlDocument $fileContents -ElementPath "package.metadata.version" -TextValue $NewVersionNumber
	$fileContents.Save($NuSpecFilePath)
}

function Get-NuSpecReleaseNotes([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string] $NuSpecFilePath)
{	
	# Read in the file contents and return the version element's value.
	$fileContents = New-Object System.Xml.XmlDocument
    $fileContents.Load($NuSpecFilePath)
	return Get-XmlElementsTextValue -XmlDocument $fileContents -ElementPath "package.metadata.releaseNotes"
}

function Set-NuSpecReleaseNotes([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string] $NuSpecFilePath, [parameter(Position=2)][string] $NewReleaseNotes)
{
	# Read in the file contents, update the version element's value, and save the file.
	$fileContents = New-Object System.Xml.XmlDocument
    $fileContents.Load($NuSpecFilePath)
	Set-XmlElementsTextValue -XmlDocument $fileContents -ElementPath "package.metadata.releaseNotes" -TextValue $NewReleaseNotes
	$fileContents.Save($NuSpecFilePath)
}

function Get-XmlNamespaceManager([xml]$XmlDocument, [string]$NamespaceURI = "")
{
    # If a Namespace URI was not given, use the Xml document's default namespace.
	if ([string]::IsNullOrEmpty($NamespaceURI)) { $NamespaceURI = $XmlDocument.DocumentElement.NamespaceURI }	
	
	# In order for SelectSingleNode() to actually work, we need to use the fully qualified node path along with an Xml Namespace Manager, so set them up.
	[System.Xml.XmlNamespaceManager]$xmlNsManager = New-Object System.Xml.XmlNamespaceManager($XmlDocument.NameTable)
	$xmlNsManager.AddNamespace("ns", $NamespaceURI)
    return ,$xmlNsManager		# Need to put the comma before the variable name so that PowerShell doesn't convert it into an Object[].
}

function Get-FullyQualifiedXmlNodePath([string]$NodePath, [string]$NodeSeparatorCharacter = '.')
{
    return "/ns:$($NodePath.Replace($($NodeSeparatorCharacter), '/ns:'))"
}

function Get-XmlNode([xml]$XmlDocument, [string]$NodePath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	$xmlNsManager = Get-XmlNamespaceManager -XmlDocument $XmlDocument -NamespaceURI $NamespaceURI
	[string]$fullyQualifiedNodePath = Get-FullyQualifiedXmlNodePath -NodePath $NodePath -NodeSeparatorCharacter $NodeSeparatorCharacter
	
	# Try and get the node, then return it. Returns $null if the node was not found.
	$node = $XmlDocument.SelectSingleNode($fullyQualifiedNodePath, $xmlNsManager)
	return $node
}

function Get-XmlNodes([xml]$XmlDocument, [string]$NodePath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	$xmlNsManager = Get-XmlNamespaceManager -XmlDocument $XmlDocument -NamespaceURI $NamespaceURI
	[string]$fullyQualifiedNodePath = Get-FullyQualifiedXmlNodePath -NodePath $NodePath -NodeSeparatorCharacter $NodeSeparatorCharacter

	# Try and get the nodes, then return them. Returns $null if no nodes were found.
	$nodes = $XmlDocument.SelectNodes($fullyQualifiedNodePath, $xmlNsManager)
	return $nodes
}

function Get-XmlElementsTextValue([xml]$XmlDocument, [string]$ElementPath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	# Try and get the node.	
	$node = Get-XmlNode -XmlDocument $XmlDocument -NodePath $ElementPath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter
	
	# If the node already exists, return its value, otherwise return null.
	if ($node) { return $node.InnerText } else { return $null }
}

function Set-XmlElementsTextValue([xml]$XmlDocument, [string]$ElementPath, [string]$TextValue, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	# Try and get the node.	
	$node = Get-XmlNode -XmlDocument $XmlDocument -NodePath $ElementPath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter
	
	# If the node already exists, update its value.
	if ($node)
	{ 
		$node.InnerText = $TextValue
	}
	# Else the node doesn't exist yet, so create it with the given value.
	else
	{
		# Create the new element with the given value.
		$elementName = $ElementPath.Substring($ElementPath.LastIndexOf($NodeSeparatorCharacter) + 1)
 		$element = $XmlDocument.CreateElement($elementName, $XmlDocument.DocumentElement.NamespaceURI)		
		$textNode = $XmlDocument.CreateTextNode($TextValue)
		$element.AppendChild($textNode) > $null
		
		# Try and get the parent node.
		$parentNodePath = $ElementPath.Substring(0, $ElementPath.LastIndexOf($NodeSeparatorCharacter))
		$parentNode = Get-XmlNode -XmlDocument $XmlDocument -NodePath $parentNodePath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter
		
		if ($parentNode)
		{
			$parentNode.AppendChild($element) > $null
		}
		else
		{
			throw "$parentNodePath does not exist in the xml."
		}
	}
}

# Show an Open File Dialog and return the file selected by the user.
function Read-OpenFileDialog([string]$WindowTitle, [string]$InitialDirectory, [string]$Filter = "All files (*.*)|*.*", [switch]$AllowMultiSelect)
{  
	Add-Type -AssemblyName System.Windows.Forms
	$openFileDialog = New-Object System.Windows.Forms.OpenFileDialog
	$openFileDialog.Title = $WindowTitle
	if (!(Test-StringIsNullOrWhitespace $InitialDirectory)) { $openFileDialog.InitialDirectory = $InitialDirectory }
	$openFileDialog.Filter = $Filter
	if ($AllowMultiSelect) { $openFileDialog.MultiSelect = $true }
	$openFileDialog.ShowHelp = $true	# Without this line the ShowDialog() function may hang depending on system configuration and running from console vs. ISE.
	$openFileDialog.ShowDialog() > $null
	if ($AllowMultiSelect) { return $openFileDialog.Filenames } else { return $openFileDialog.Filename }
}

# Show message box popup and return the button clicked by the user.
function Read-MessageBoxDialog([string]$Message, [string]$WindowTitle, [System.Windows.Forms.MessageBoxButtons]$Buttons = [System.Windows.Forms.MessageBoxButtons]::OK, [System.Windows.Forms.MessageBoxIcon]$Icon = [System.Windows.Forms.MessageBoxIcon]::None)
{
	Add-Type -AssemblyName System.Windows.Forms
	return [System.Windows.Forms.MessageBox]::Show($Message, $WindowTitle, $Buttons, $Icon)
}

# Show input box popup and return the value entered by the user.
function Read-InputBoxDialog([string]$Message, [string]$WindowTitle, [string]$DefaultText)
{
	Add-Type -AssemblyName Microsoft.VisualBasic
	return [Microsoft.VisualBasic.Interaction]::InputBox($Message, $WindowTitle, $DefaultText)
}

function Read-MultiLineInputBoxDialog([string]$Message, [string]$WindowTitle, [string]$DefaultText)
{
<#
    .SYNOPSIS
    Prompts the user with a multi-line input box and returns the text they enter, or null if they cancelled the prompt.
     
    .DESCRIPTION
    Prompts the user with a multi-line input box and returns the text they enter, or null if they cancelled the prompt.
     
    .PARAMETER Message
    The message to display to the user explaining what text we are asking them to enter.
     
    .PARAMETER WindowTitle
    The text to display on the prompt window's title.
     
    .PARAMETER DefaultText
    The default text to show in the input box.
     
    .EXAMPLE
    $userText = Read-MultiLineInputDialog "Input some text please:" "Get User's Input"
     
    Shows how to create a simple prompt to get mutli-line input from a user.
     
    .EXAMPLE
    # Setup the default multi-line address to fill the input box with.
    $defaultAddress = @'
    John Doe
    123 St.
    Some Town, SK, Canada
    A1B 2C3
    '@
     
    $address = Read-MultiLineInputDialog "Please enter your full address, including name, street, city, and postal code:" "Get User's Address" $defaultAddress
    if ($address -eq $null)
    {
        Write-Error "You pressed the Cancel button on the multi-line input box."
    }
     
    Prompts the user for their address and stores it in a variable, pre-filling the input box with a default multi-line address.
    If the user pressed the Cancel button an error is written to the console.
     
    .EXAMPLE
    $inputText = Read-MultiLineInputDialog -Message "If you have a really long message you can break it apart`nover two lines with the powershell newline character:" -WindowTitle "Window Title" -DefaultText "Default text for the input box."
     
    Shows how to break the second parameter (Message) up onto two lines using the powershell newline character (`n).
    If you break the message up into more than two lines the extra lines will be hidden behind or show ontop of the TextBox.
     
    .NOTES
    Name: Show-MultiLineInputDialog
    Author: Daniel Schroeder (originally based on the code shown at http://technet.microsoft.com/en-us/library/ff730941.aspx)
    Version: 1.0
#>
    Add-Type -AssemblyName System.Drawing
    Add-Type -AssemblyName System.Windows.Forms
     
    # Create the Label.
    $label = New-Object System.Windows.Forms.Label
    $label.Location = New-Object System.Drawing.Size(10,10)
    $label.Size = New-Object System.Drawing.Size(280,20)
    $label.AutoSize = $true
    $label.Text = $Message
     
    # Create the TextBox used to capture the user's text.
    $textBox = New-Object System.Windows.Forms.TextBox
    $textBox.Location = New-Object System.Drawing.Size(10,40)
    $textBox.Size = New-Object System.Drawing.Size(575,200)
    $textBox.AcceptsReturn = $true
    $textBox.AcceptsTab = $false
    $textBox.Multiline = $true
    $textBox.ScrollBars = 'Both'
    $textBox.Text = $DefaultText
     
    # Create the OK button.
    $okButton = New-Object System.Windows.Forms.Button
    $okButton.Location = New-Object System.Drawing.Size(415,250)
    $okButton.Size = New-Object System.Drawing.Size(75,25)
    $okButton.Text = "OK"
    $okButton.Add_Click({ $form.Tag = $textBox.Text; $form.Close() })
     
    # Create the Cancel button.
    $cancelButton = New-Object System.Windows.Forms.Button
    $cancelButton.Location = New-Object System.Drawing.Size(510,250)
    $cancelButton.Size = New-Object System.Drawing.Size(75,25)
    $cancelButton.Text = "Cancel"
    $cancelButton.Add_Click({ $form.Tag = $null; $form.Close() })
     
    # Create the form.
    $form = New-Object System.Windows.Forms.Form
    $form.Text = $WindowTitle
    $form.Size = New-Object System.Drawing.Size(610,320)
    $form.FormBorderStyle = 'FixedSingle'
    $form.StartPosition = "CenterScreen"
    $form.AutoSizeMode = 'GrowAndShrink'
    $form.Topmost = $True
    $form.AcceptButton = $okButton
    $form.CancelButton = $cancelButton
    $form.ShowInTaskbar = $true
     
    # Add all of the controls to the form.
    $form.Controls.Add($label)
    $form.Controls.Add($textBox)
    $form.Controls.Add($okButton)
    $form.Controls.Add($cancelButton)
     
    # Initialize and show the form.
    $form.Add_Shown({$form.Activate()})
    $form.ShowDialog() > $null   # Trash the text of the button that was clicked.
     
    # Return the text that the user entered.
    return $form.Tag
}

function Get-TfExecutablePath
{	
	# Get the latest visual studio IDE path.
	$vsIdePath = "" 
	$vsCommonToolsPaths = @($env:VS140COMNTOOLS,$env:VS120COMNTOOLS,$env:VS110COMNTOOLS,$env:VS100COMNTOOLS)
	$vsCommonToolsPaths = @($VsCommonToolsPaths | Where-Object {$_ -ne $null})
		
	# Loop through each version from largest to smallest.
	foreach ($vsCommonToolsPath in $vsCommonToolsPaths)
	{
		if ($vsCommonToolsPath -ne $null)
		{
			$vsIdePath = "${vsCommonToolsPath}..\IDE\"
			break
		}
	}

	# Get the path to tf.exe, and return an empty string if the file does not exist.
	$tfPath = "${vsIdePath}tf.exe"
    if (!(Test-Path -Path $tfPath)) 
    {
        Write-Verbose "Unable to find Visual Studio Common Tool Path, which is used to locate TF.exe."
        return ""
    }

    # Return the absolute path to tf.exe.
    $tfPath = Resolve-Path $tfPath
	return $tfPath
}

function Tfs-Checkout
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0, HelpMessage="The local path to the file or folder to checkout from TFS source control.")]
		[string]$Path,
		
		[switch]$Recursive
	)
	
	$tfPath = Get-TfExecutablePath

    # If we couldn't find TF.exe, just return without doing anything.
    if (Test-StringIsNullOrWhitespace $tfPath) 
    {
        Write-Verbose "Unable to locate TF.exe, so will skip attempting to check '$Path' out of TFS source control." 
        return 
    }
	
	# Construct the checkout command to run.
	$tfCheckoutCommand = "& ""$tfPath"" checkout /lock:none ""$Path"""
	if ($Recursive) { $tfCheckoutCommand += " /recursive" }
	
	# Check the file out of TFS, eating any output and errors.
	Write-Verbose "About to run command '$tfCheckoutCommand'."
	Invoke-Expression -Command $tfCheckoutCommand 2>&1 > $null
}

function Tfs-IsItemCheckedOut
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0, HelpMessage="The local path to the file or folder to checkout from TFS source control.")]
		[string]$Path,
		
		[switch]$Recursive
	)
	
	$tfPath = Get-TfExecutablePath

    # If we couldn't find TF.exe, just return without doing anything.
    if (Test-StringIsNullOrWhitespace $tfPath) 
    {
        Write-Verbose "Unable to locate TF.exe, so will skip attempting to check if '$Path' is checked out of TFS source control." 
        return $null
    }
	
	# Construct the status command to run.
	$tfStatusCommand = "& ""$tfPath"" status ""$Path"""
	if ($Recursive) { $tfStatusCommand += " /recursive" }
	
	# Check the file out of TFS, capturing the output and errors.
	Write-Verbose "About to run command '$tfStatusCommand'."
	$status = (Invoke-Expression -Command $tfStatusCommand 2>&1)

    # Get the escaped path of the file or directory to search the status output for.
    $escapedPath = $Path.Replace('\', '\\')

    # Examine the returned text to return if the given Path is checked out or not.
    if ((Test-StringIsNullOrWhitespace $status) -or ($status -imatch $TF_EXE_NO_WORKING_FOLDER_MAPPING_ERROR_MESSAGE)) { return $null }	# An error was returned, so likely TFS is not used for this item.
    elseif ($status -imatch $TF_EXE_NO_PENDING_CHANGES_MESSAGE) { return $false }	# The item was found in TFS, but is not checked out.
    elseif ($status -imatch $escapedPath -and $status -imatch $TF_EXE_KEYWORD_IN_PENDING_CHANGES_MESSAGE) { return $true }	# If the file path and "change(s)" are in the message then it means the path is checked out.
    else { return $false }	# Else we're not sure, so return that it is not checked out.
}

function Tfs-Undo
{
    [CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0, HelpMessage="The local path to the file or folder to undo from TFS source control.")]
		[string]$Path,
		
		[switch]$Recursive
	)
	
	$tfPath = Get-TfExecutablePath

    # If we couldn't find TF.exe, just return without doing anything.
    if (Test-StringIsNullOrWhitespace $tfPath) 
    {
        Write-Verbose "Unable to locate TF.exe, so will skip attempting to undo '$Path' from TFS source control." 
        return 
    }
	
	# Construct the undo command to run.
	$tfCheckoutCommand = "& ""$tfPath"" undo ""$Path"" /noprompt"
	if ($Recursive) { $tfCheckoutCommand += " /recursive" }
	
	# Check the file out of TFS, eating any output and errors.
	Write-Verbose "About to run command '$tfCheckoutCommand'."
	Invoke-Expression -Command $tfCheckoutCommand 2>&1 > $null
}

function Get-ProjectsAssociatedNuSpecFilePath([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string]$ProjectFilePath)
{
	# Construct what the project's nuspec file path would be if it has one (i.e. a [Project File Name].nupsec file in the same directory as the project file).
	$projectsNuSpecFilePath = Join-Path ([System.IO.Path]::GetDirectoryName($ProjectFilePath)) ([System.IO.Path]::GetFileNameWithoutExtension($ProjectFilePath))
	$projectsNuSpecFilePath += ".nuspec"
	
	# If this Project has a .nuspec that will be used to package with.
	if (Test-Path $projectsNuSpecFilePath -PathType Leaf)
	{
		return $projectsNuSpecFilePath
	}
	return $null
}

function Get-NuSpecsAssociatedProjectFilePath([parameter(Position=1,Mandatory=$true)][ValidateScript({Test-Path $_ -PathType Leaf})][string]$NuSpecFilePath)
{
	# Construct what the nuspec's associated project file path would be if it has one (i.e. a [NuSpec File Name].[project extension] file in the same directory as the .nuspec file).
	$nuSpecsProjectFilePath = Join-Path ([System.IO.Path]::GetDirectoryName($NuSpecFilePath)) ([System.IO.Path]::GetFileNameWithoutExtension($NuSpecFilePath))
	
	# Loop through each possible project extension type to see if it exists in the
	foreach ($extension in $VALID_NUGET_PROJECT_TYPE_EXTENSIONS_ARRAY)
	{
		# If this .nuspec file has an associated Project that can be used to pack with, return the project's file path.
		$nuSpecsProjectFilePath += $extension
		if (Test-Path $nuSpecsProjectFilePath -PathType Leaf)
		{
			return $nuSpecsProjectFilePath
		}
	}
	return $null
}


#==========================================================
# Perform the script tasks.
#==========================================================

# Define some variables that we need to access within both the Try and Finally blocks of the script.
$script:nuSpecFileWasAlreadyCheckedOut = $false
$script:nuSpecFileContentsBeforeCheckout = $null
$script:nuSpecLastWriteTimeBeforeCheckout = $null

# Display the time that this script started running.
$scriptStartTime = Get-Date
Write-Verbose "New-NuGetPackage script started running at $($scriptStartTime.TimeOfDay.ToString())."

# Display the version of PowerShell being used to run the script, as this can help solve some problems that are hard to reproduce on other machines.
Write-Verbose "Using PowerShell Version: $($PSVersionTable.PSVersion.ToString())."

try
{
	# If we should not show any prompts, disable them all.
	if ($NoPrompt -or $NoPromptExceptOnError)
	{
		if ($NoPrompt) { $NoPromptForInputOnError = $true }
		$NoPromptForPushPackageToNuGetGallery = $true
		$NoPromptForReleaseNotes = $true
		$NoPromptForVersionNumber = $true
	}
	
	# If a path to a NuSpec, Project, or Package file to use was not provided, look for one in the same directory as this script or prompt for one.
	if ((Test-StringIsNullOrWhitespace $NuSpecFilePath) -and (Test-StringIsNullOrWhitespace $ProjectFilePath) -and (Test-StringIsNullOrWhitespace $PackageFilePath))
	{
		# Get all of the .nuspec files in the script's directory.
		$nuSpecFiles = Get-ChildItem "$THIS_SCRIPTS_DIRECTORY_PATH\*" -Include "*.nuspec" -Name
		
		# Get all of the project files in the script's directory.
		$projectFiles = Get-ChildItem "$THIS_SCRIPTS_DIRECTORY_PATH\*" -Include $VALID_NUGET_PROJECT_TYPE_EXTENSIONS_WITH_WILDCARD_ARRAY -Name

        # Get all of the NuGet package files in this script's directory.
        $packageFiles = Get-ChildItem "$THIS_SCRIPTS_DIRECTORY_PATH\*" -Include "*.nupkg" -Name
	
		# Get the number of files found.
		$numberOfNuSpecFilesFound = @($nuSpecFiles).Length
		$numberOfProjectFilesFound = @($projectFiles).Length
        $numberOfPackageFilesFound = @($packageFiles).Length
	
		# If we only found one project file and no package files, see if we should use the project file.
		if (($numberOfProjectFilesFound -eq 1) -and ($numberOfPackageFilesFound -eq 0))
		{
			$projectPath = Join-Path $THIS_SCRIPTS_DIRECTORY_PATH ($projectFiles | Select-Object -First 1)
			$projectsNuSpecFilePath = Get-ProjectsAssociatedNuSpecFilePath -ProjectFilePath $projectPath
			
			# If we didn't find any .nuspec files, then use this project file.
			if ($numberOfNuSpecFilesFound -eq 0)
			{
				$ProjectFilePath = $projectPath
			}
			# Else if we found one .nuspec file, see if we should use this project file.
			elseif ($numberOfNuSpecFilesFound -eq 1)
			{
				# If the .nuspec file belongs to this project file, use this project file.
				$nuSpecFilePathInThisScriptsDirectory = Join-Path $THIS_SCRIPTS_DIRECTORY_PATH ($nuSpecFiles | Select-Object -First 1)
				if ((!(Test-StringIsNullOrWhitespace $projectsNuSpecFilePath)) -and ($projectsNuSpecFilePath -eq $nuSpecFilePathInThisScriptsDirectory))
				{
					$ProjectFilePath = $projectPath
				}
			}
		}
		# Else if we only found one .nuspec file and no project or package files, use the .nuspec file.
		elseif (($numberOfNuSpecFilesFound -eq 1) -and ($numberOfProjectFilesFound -eq 0) -and ($numberOfPackageFilesFound -eq 0))
		{
			$NuSpecFilePath = Join-Path $THIS_SCRIPTS_DIRECTORY_PATH ($nuSpecFiles | Select-Object -First 1)
		}
        # Else if we only found one package file and no .nuspec or project files, use the package file.
        elseif (($numberOfPackageFilesFound -eq 1) -and ($numberOfNuSpecFilesFound -eq 0) -and ($numberOfProjectFilesFound -eq 0))
        {
            $PackageFilePath = Join-Path $THIS_SCRIPTS_DIRECTORY_PATH ($packageFiles | Select-Object -First 1)
        }
		
		# If we didn't find a clear .nuspec, project, or package file to use, prompt for one.
		if ((Test-StringIsNullOrWhitespace $NuSpecFilePath) -and (Test-StringIsNullOrWhitespace $ProjectFilePath) -and (Test-StringIsNullOrWhitespace $PackageFilePath))
		{
			# If we should prompt directly from PowerShell.
			if ($UsePowerShellPrompts)
			{
				# Construct the prompt message with all of the supported project extensions.
				# $promptmessage should end up looking like: "Enter the path to the .nuspec or project file (.csproj, .vbproj, .fsproj) to pack, or the package file (.nupkg) to push"
				$promptMessage = "Enter the path to the .nuspec or project file ("
				foreach ($extension in $VALID_NUGET_PROJECT_TYPE_EXTENSIONS_ARRAY)
				{
					$promptMessage += "$extension, "
				}
				$promptMessage = $promptMessage.Substring(0, $promptMessage.Length - 2)	# Trim off the last character, as it will be a ", ".
				$promptMessage += ") to pack, or .nupkg file to push"
				
				$filePathToUse = Read-Host $promptMessage
				$filePathToUse = $filePathToUse.Trim('"')
			}
			# Else use a nice GUI prompt.
			else
			{
				# Construct the strings to use in the OpenFileDialog filter to allow all of the supported project file types.
				# $filter should end up looking like: "NuSpec, package, and project files (*.nuspec, *.nupkg, *.csproj, *.vbproj, *.fsproj)|*.nuspec;*.nupkg;*.csproj;*.vbproj;*.fsproj"
				$filterMessage = "NuSpec and project files (*.nuspec, "
				$filterTypes = "*.nuspec;*.nupkg;"
				foreach ($extension in $VALID_NUGET_PROJECT_TYPE_EXTENSIONS_ARRAY) 
				{
					$filterMessage += "*$extension, "
					$filterTypes += "*$extension;"
				}
				$filterMessage = $filterMessage.Substring(0, $filterMessage.Length - 2)		# Trim off the last 2 characters, as they will be a ", ".
				$filterMessage += ")"
				$filterTypes = $filterTypes.Substring(0, $filterTypes.Length - 1)			# Trim off the last character, as it will be a ";".
				$filter = "$filterMessage|$filterTypes"
			
				$filePathToUse = Read-OpenFileDialog -WindowTitle "Select the .nuspec or project file to pack, or the package file (.nupkg) to push..." -InitialDirectory $THIS_SCRIPTS_DIRECTORY_PATH -Filter $filter
			}
			
			# If the user cancelled the file dialog, throw an error since we don't have a .nuspec file to use.
			if (Test-StringIsNullOrWhitespace $filePathToUse)
			{
				throw "No .nuspec, project, or package file was specified. You must specify a valid file to use."
			}

			# If a .nuspec file was specified, double check that we should use it.
			if ([System.IO.Path]::GetExtension($filePathToUse) -eq ".nuspec")
			{
				# If this .nuspec file is associated with a project file, prompt to see if they want to pack the project instead (as that is preferred).
				$projectPath = Get-NuSpecsAssociatedProjectFilePath -NuSpecFilePath $filePathToUse
				if (!(Test-StringIsNullOrWhitespace $projectPath))
				{
                    # If we are not allowed to prompt the user, just assume we should only use the .nuspec file.
                    if ($NoPrompt)
                    {
                        $answer = "No"
                    }
                    # Else prompt the user if they want to pack the project file instead.
                    else
                    {
					    $promptMessage = "The selected .nuspec file appears to be associated with the project file:`n`n$projectPath`n`nIt is generally preferred to pack the project file, and the .nuspec file will automatically get picked up.`nDo you want to pack the project file instead?"
				
					    # If we should prompt directly from PowerShell.
					    if ($UsePowerShellPrompts)
					    {
						    $promptMessage += " (Yes|No|Cancel)"
						    $answer = Read-Host $promptMessage
					    }
					    # Else use a nice GUI prompt.
					    else
					    {
						    $answer = Read-MessageBoxDialog -Message $promptMessage -WindowTitle "Pack using the Project file instead?" -Buttons YesNoCancel -Icon Question
					    }
                    }
					
					# If the user wants to use the Project file, use it.
					if (($answer -is [string] -and $answer.StartsWith("Y", [System.StringComparison]::InvariantCultureIgnoreCase)) -or $answer -eq [System.Windows.Forms.DialogResult]::Yes)
					{
						$ProjectFilePath = $projectPath
					}
					# Else if the user wants to use the .nuspec file, use it.
					elseif (($answer -is [string] -and $answer.StartsWith("N", [System.StringComparison]::InvariantCultureIgnoreCase)) -or $answer -eq [System.Windows.Forms.DialogResult]::No)
					{
						$NuSpecFilePath = $filePathToUse
					}
					# Else the user cancelled the prompt, so exit the script.
					else
					{
						throw "User cancelled the .nuspec or project file prompt, so exiting script."
					}
				}
				# Else this .nuspec file is not associated with a project file, so use the .nuspec file.
				else
				{
					$NuSpecFilePath = $filePathToUse
				}
			}
            # Else if a package file was specified.
            elseif ([System.IO.Path]::GetExtension($filePathToUse) -eq ".nupkg")
            {
                $PackageFilePath = $filePathToUse
            }
			# Else a .nuspec or package file was not specified, so assume it is a project file.
			else
			{
				$ProjectFilePath = $filePathToUse
			}
		}
	}
	
	# Make sure we have the absolute file paths.
	if (!(Test-StringIsNullOrWhitespace $NuSpecFilePath)) { $NuSpecFilePath = Resolve-Path $NuSpecFilePath }
	if (!(Test-StringIsNullOrWhitespace $ProjectFilePath)) { $ProjectFilePath = Resolve-Path $ProjectFilePath }
	if (!(Test-StringIsNullOrWhitespace $PackageFilePath)) { $PackageFilePath = Resolve-Path $PackageFilePath }

    # If a path to the NuGet executable was not provided, try and find it.
    if (Test-StringIsNullOrWhitespace $NuGetExecutableFilePath)
    {
        # If the NuGet executable is in the same directory as this script, use it.
        $nuGetExecutablePathInThisDirectory = Join-Path $THIS_SCRIPTS_DIRECTORY_PATH "NuGet.exe"
        if (Test-Path $nuGetExecutablePathInThisDirectory)
        {
            $NuGetExecutableFilePath = $nuGetExecutablePathInThisDirectory
        }
        # Else we don't know where the executable is, so assume it has been added to the PATH.
        else
        {
            $NuGetExecutableFilePath = "NuGet.exe"
        }
    }
	
	# If we should try and update the NuGet executable.
    if ($UpdateNuGetExecutable)
    {
		# If we have the path to the NuGet executable, try and check it out of TFS before having it update itself.
		if (Test-Path $NuGetExecutableFilePath)
		{
			# Try and check the NuGet executable out of TFS if needed.
	        $nuGetExecutableWasAlreadyCheckedOut = Tfs-IsItemCheckedOut -Path $NuGetExecutableFilePath
	        if ($nuGetExecutableWasAlreadyCheckedOut -eq $false) { Tfs-Checkout -Path $NuGetExecutableFilePath }
		}
		
		# Create the command to use to update NuGet.exe.
	    $updateCommand = "& ""$NuGetExecutableFilePath"" update -self"

		# Have the NuGet executable try and auto-update itself.
	    Write-Verbose "About to run Update command '$updateCommand'."
	    $updateOutput = (Invoke-Expression -Command $updateCommand | Out-String).Trim()
		
		# Write the output of the above command to the Verbose stream.
		Write-Verbose $updateOutput
		
		# If we have the path to the NuGet executable, we checked it out of TFS, and it did not auto-update itself, then undo the changes from TFS.
		if ((Test-Path $NuGetExecutableFilePath) -and ($nuGetExecutableWasAlreadyCheckedOut -eq $false) -and !$updateOutput.EndsWith($NUGET_EXE_SUCCESSFULLY_UPDATED_TO_NEW_VERSION.Trim()))
		{
			Tfs-Undo -Path $NuGetExecutableFilePath
		}
    }
	
	# Get and display the version of NuGet.exe that will be used. If NuGet.exe is not found an exception will be thrown automatically.
	# Create the command to use to get the Nuget Help info.
    $helpCommand = "& ""$NuGetExecutableFilePath"""

	# Get the NuGet.exe Help output.
    Write-Verbose "About to run Help command '$helpCommand'."
    $helpOutput = (Invoke-Expression -Command $helpCommand | Out-String).Trim()	
	
	# If no Help output was retrieved, the NuGet.exe likely returned an error.
	if (Test-StringIsNullOrWhitespace $helpOutput)
	{
		# Get the error information returned by NuGet.exe, and throw an error that we could not run NuGet.exe as expected.
		$helpError = (Invoke-Expression -Command $helpCommand 2>&1 | Out-String).Trim()	
		throw "NuGet information could not be retrieved by running '$NuGetExecutableFilePath'.`r`n`r`nRunning '$NuGetExecutableFilePath' returns the following information:`r`n`r`n$helpError"
	}
	
	# Display the version of the NuGet.exe. This information is the first line of the NuGet Help output.
	$nuGetVersionString = ($helpOutput -split "`r`n")[0]
	Write-Verbose "Using $($nuGetVersionString)."
	
	# Declare the backup directory to create the NuGet Package in, as not all code paths will set it (i.e. when pushing an existing package), but we check it later.
	$defaultDirectoryPathToPutNuGetPackageIn = $null

    # If we were not given a package file, then we need to pack something.
    if (Test-StringIsNullOrWhitespace $PackageFilePath)
    {
	    # If we were given a Project to package.
	    if (!(Test-StringIsNullOrWhitespace $ProjectFilePath))
	    {
		    # Get the project's .nuspec file path, if it has a .nuspec file.
		    $projectNuSpecFilePath = Get-ProjectsAssociatedNuSpecFilePath -ProjectFilePath $ProjectFilePath
	
		    # If this Project has a .nuspec that will be used to package with.
		    if (!(Test-StringIsNullOrWhitespace $projectNuSpecFilePath))
		    {
			    # Update .nuspec file based on user input.
			    $NuSpecFilePath = $projectNuSpecFilePath
			    Update-NuSpecFile
		    }
		    # Else we aren't using a .nuspec file, so if a Version Number was given in the script parameters but not the pack parameters, add it to the pack parameters.
		    elseif (!(Test-StringIsNullOrWhitespace $VersionNumber) -and $PackOptions -notmatch '-Version')
		    {
			    $PackOptions += " -Version ""$VersionNumber"""
		    }
		
		    # Save the directory that the project file is in as the directory to create the package in.
		    $defaultDirectoryPathToPutNuGetPackageIn = [System.IO.Path]::GetDirectoryName($ProjectFilePath)
		
		    # Record that we want to pack using the project file, not a NuSpec file.
		    $fileToPack = $ProjectFilePath
	    }
	    # Else we are supposed to package using just a NuSpec.
	    else
	    {	
		    # Update .nuspec file based on user input.
		    Update-NuSpecFile
		
		    # Save the directory that the .nuspec file is in as the directory to create the package in.
		    $defaultDirectoryPathToPutNuGetPackageIn = [System.IO.Path]::GetDirectoryName($NuSpecFilePath)
		
		    # Record that we want to pack using the NuSpec file, not a project file.
		    $fileToPack = $NuSpecFilePath
	    }
	
	    # Make sure our backup Output Directory is an absolute path.
	    if (![System.IO.Path]::IsPathRooted($defaultDirectoryPathToPutNuGetPackageIn))
	    {
		    $defaultDirectoryPathToPutNuGetPackageIn = Resolve-Path $directoryToPackFrom
	    }

		# When an Output Directory is not explicitly provided, we want to put generated packages into their own directory.
        $defaultDirectoryPathToPutNuGetPackageIn = Join-Path $defaultDirectoryPathToPutNuGetPackageIn $DEFAULT_DIRECTORY_TO_PUT_NUGET_PACKAGES_IN
	
	    # If the user did not specify an Output Directory.
	    if ($PackOptions -notmatch '-OutputDirectory')
	    {
            # Insert our default Output Directory into the Additional Pack Options.
            Write-Verbose "Specifying to use the default Output Directory '$defaultDirectoryPathToPutNuGetPackageIn'."
		    $PackOptions += " -OutputDirectory ""$defaultDirectoryPathToPutNuGetPackageIn"""

            # Make sure the Output Directory we are adding exists.
            if (!(Test-Path -Path $defaultDirectoryPathToPutNuGetPackageIn))
            {
                New-Item -Path $defaultDirectoryPathToPutNuGetPackageIn -ItemType Directory > $null
            }
	    }

	    # Create the command to use to create the package.
	    $packCommand = "& ""$NuGetExecutableFilePath"" pack ""$fileToPack"" $PackOptions"
		$packCommand = $packCommand -ireplace ';', '`;'		# Escape any semicolons so they are not interpreted as the start of a new command.

		# Create the package.
	    Write-Verbose "About to run Pack command '$packCommand'."
	    $packOutput = (Invoke-Expression -Command $packCommand | Out-String).Trim()
	
		# Write the output of the above command to the Verbose stream.
		Write-Verbose $packOutput
	
	    # Get the path the NuGet Package was created to, and write it to the output stream.
	    $match = $NUGET_EXE_SUCCESSFULLY_CREATED_PACKAGE_MESSAGE_REGEX.Match($packOutput)
	    if ($match.Success)
	    {
		    $nuGetPackageFilePath = $match.Groups["FilePath"].Value
			
			# Have this cmdlet return the path that the new NuGet Package was created to.
			# This should be the only code that uses Write-Output, as it is the only thing that should be returned by the cmdlet.
			Write-Output $nuGetPackageFilePath
	    }
	    else
	    {
		    throw "Could not determine where NuGet Package was created to. This typically means that an error occurred while NuGet.exe was packing it. Look for errors from NuGet.exe above (in the console window), or in the following NuGet.exe output. You can also try running this command with the -Verbose switch for more information:{0}{1}" -f [Environment]::NewLine, $packOutput
	    }
	}
    # Else we were given a Package file to push.
    else
    {
        # Save the Package file path to push.
        $nuGetPackageFilePath = $PackageFilePath
    }

    # Get the Source to push the package to.
    # If the user explicitly provided the Source to push the package to, get it.
	$rxSourceToPushPackageTo = [regex] "(?i)((-Source|-src)\s+(?<Source>.*?)(\s+|$))"
	$match = $rxSourceToPushPackageTo.Match($PushOptions)
	if ($match.Success)
	{
        $sourceToPushPackageTo = $match.Groups["Source"].Value
            
        # Strip off any quotes around the address.
        $sourceToPushPackageTo = $sourceToPushPackageTo.Trim([char[]]@("'", '"'))
	}
    # Else they did not provide an explicit source to push to.
	else
	{
		# So assume they are pushing to the typical default source.
        $sourceToPushPackageTo = $DEFAULT_NUGET_SOURCE_TO_PUSH_TO
	}

	# If the switch to push the package to the gallery was not provided and we are allowed to prompt, prompt the user if they want to push the package.
	if (!$PushPackageToNuGetGallery -and !$NoPromptForPushPackageToNuGetGallery)
	{
		$promptMessage = "Do you want to push this package:`n'$nuGetPackageFilePath'`nto the NuGet Gallery '$sourceToPushPackageTo'?"
		
		# If we should prompt directly from PowerShell.
		if ($UsePowerShellPrompts)
		{
			$promptMessage += " (Yes|No)"
			$answer = Read-Host $promptMessage
		}
		# Else use a nice GUI prompt.
		else
		{
			$answer = Read-MessageBoxDialog -Message $promptMessage -WindowTitle "Push Package To Gallery?" -Buttons YesNo -Icon Question
		}
		
		# If the user wants to push the new package, record it.
		if (($answer -is [string] -and $answer.StartsWith("Y", [System.StringComparison]::InvariantCultureIgnoreCase)) -or $answer -eq [System.Windows.Forms.DialogResult]::Yes)
		{
			$PushPackageToNuGetGallery = $true
		}
	}
	
	# If we should push the Nuget package to the gallery.
	if ($PushPackageToNuGetGallery)
	{
        # If the user has not provided an API key.
        $UserProvidedApiKeyUsingPrompt = $false
        if ($PushOptions -notmatch '-ApiKey')
        {
            # Get the NuGet.config file contents as Xml.
            $nuGetConfigXml = New-Object System.Xml.XmlDocument
            $nuGetConfigXml.Load($NUGET_CONFIG_FILE_PATH)

            # If the user does not have an API key saved on this PC for the Source to push to, and prompts are allowed, prompt them for one.
            if (((Get-XmlNodes -XmlDocument $nuGetConfigXml -NodePath "configuration.apikeys.add" | Where-Object { $_.key -eq $sourceToPushPackageTo }) -eq $null) -and !$NoPrompt)
            {
                $promptMessage = "It appears that you do not have an API key saved on this PC for the source to push the package to '$sourceToPushPackageTo'.`n`nYou must provide an API key to push this package to the NuGet Gallery.`n`nPlease enter your API key"
		
		        # If we should prompt directly from PowerShell.
		        if ($UsePowerShellPrompts)
		        {
			        $apiKey = Read-Host $promptMessage
		        }
		        # Else use a nice GUI prompt.
		        else
		        {
			        $apiKey = Read-InputBoxDialog -Message "$promptMessage`:" -WindowTitle "Enter Your API Key"
		        }
		
		        # If the user supplied an Api Key.
                if (!(Test-StringIsNullOrWhitespace $apiKey))
                {
                    # Add the given Api Key to the Push Options.
                    $PushOptions += " -ApiKey $apiKey"

                    # Record that the user provided the Api Key via a prompt.
                    $UserProvidedApiKeyUsingPrompt = $true
                }
            }
        }

		# Create the command to use to push the package to the gallery.
	    $pushCommand = "& ""$NuGetExecutableFilePath"" push ""$nuGetPackageFilePath"" $PushOptions"
		$pushCommand = $pushCommand -ireplace ';', '`;'		# Escape any semicolons so they are not interpreted as the start of a new command.

        # Push the package to the gallery.
		Write-Verbose "About to run Push command '$pushCommand'."
		$pushOutput = (Invoke-Expression -Command $pushCommand | Out-String).Trim()
		
		# Write the output of the above command to the Verbose stream.
		Write-Verbose $pushOutput

		# If an error occurred while pushing the package, throw and error. Else it was pushed successfully.
		if (!$pushOutput.EndsWith($NUGET_EXE_SUCCESSFULLY_PUSHED_PACKAGE_MESSAGE.Trim()))
        {
            throw "Could not determine if package was pushed to gallery successfully. Perhaps an error occurred while pushing it. Look for errors from NuGet.exe above (in the console window), or in the following NuGet.exe output. You can also try running this command with the -Verbose switch for more information:{0}{1}" -f [Environment]::NewLine, $pushOutput
        }

        # If the package should be deleted.
        if ($DeletePackageAfterPush -and (Test-Path $nuGetPackageFilePath))
        {
            # Delete the package.
            Write-Verbose "Deleting NuGet Package '$nuGetPackageFilePath'."
            Remove-Item -Path $nuGetPackageFilePath -Force

            # If the package was output to the default directory, and the directory is now empty, delete the default directory too since we would have created it above.
            if (!(Test-StringIsNullOrWhitespace $defaultDirectoryPathToPutNuGetPackageIn) -and (Test-Path -Path $defaultDirectoryPathToPutNuGetPackageIn))
            {
                [int]$numberOfFilesInDefaultOutputDirectory = ((Get-ChildItem -Path $defaultDirectoryPathToPutNuGetPackageIn -Force) | Measure-Object).Count
                if ((Split-Path -Path $nuGetPackageFilePath -Parent) -eq $defaultDirectoryPathToPutNuGetPackageIn -and $numberOfFilesInDefaultOutputDirectory -eq 0)
                {
                    Write-Verbose "Deleting empty default NuGet package directory '$defaultDirectoryPathToPutNuGetPackageIn'."
                    Remove-Item -Path $defaultDirectoryPathToPutNuGetPackageIn -Force
                }
            }
        }

        # If the user provided the Api Key via a prompt from this script, prompt them for if they want to save the given API key on this PC.
        if ($UserProvidedApiKeyUsingPrompt)
        {
	        # If we are not allowed to prompt the user, just assume they don't want to save the key on this PC.
            if ($NoPrompt)
            {
                $answer = "No"
            }
            # Else prompt the user if they want to save the given API key on this PC.
            else
            {
				$promptMessage = "Do you want to save the API key you provided on this PC so that you don't have to enter it again next time?"
			
				# If we should prompt directly from PowerShell.
				if ($UsePowerShellPrompts)
				{
					$promptMessage += " (Yes|No)"
					$answer = Read-Host $promptMessage
				}
				# Else use a nice GUI prompt.
				else
				{
					$answer = Read-MessageBoxDialog -Message $promptMessage -WindowTitle "Save API Key On This PC?" -Buttons YesNo -Icon Question
				}
            }
			
			# If the user wants to save the API key.
			if (($answer -is [string] -and $answer.StartsWith("Y", [System.StringComparison]::InvariantCultureIgnoreCase)) -or $answer -eq [System.Windows.Forms.DialogResult]::Yes)
			{
				# Create the command to use to save the Api key on this PC.
	            $setApiKeyCommand = "& ""$NuGetExecutableFilePath"" setApiKey ""$apiKey"" -Source ""$sourceToPushPackageTo"""
				$setApiKeyCommand = $setApiKeyCommand -ireplace ';', '`;'		# Escape any semicolons so they are not interpreted as the start of a new command.

				# Save the Api key on this PC.
	            Write-Verbose "About to run command '$setApiKeyCommand'."
	            $setApiKeyOutput = (Invoke-Expression -Command $setApiKeyCommand | Out-String).Trim()
				
				# Write the output of the above command to the Verbose stream.
				Write-Verbose $setApiKeyOutput
				
				# Determine if the API Key was saved successfully, and throw an error if it wasn't.
                $expectedSuccessfulNuGetSetApiKeyOutput = ($NUGET_EXE_SUCCESSFULLY_SAVED_API_KEY_MESSAGE -f $apiKey, $sourceToPushPackageTo)	# "The API Key '$apiKey' was saved for '$sourceToPushPackageTo'."
                if ($setApiKeyOutput -ne $expectedSuccessfulNuGetSetApiKeyOutput.Trim())
                {
                    throw "Could not determine if the API key was saved successfully. Perhaps an error occurred while saving it. Look for errors from NuGet.exe above (in the console window), or in the following NuGet.exe output. You can also try running this command with the -Verbose switch for more information:{0}{1}" -f [Environment]::NewLine, $packOutput
                }
			}
        }
	}
}
finally
{
    Write-Verbose "Performing any required New-NuGetPackage script cleanup..."

	# If we have a NuSpec file path.
	if (!(Test-StringIsNullOrWhitespace $NuSpecFilePath))
	{
		# If we should revert any changes we made to the NuSpec file.
		if ($DoNotUpdateNuSpecFile)
		{
			# If we created a backup of the NuSpec file before updating it, restore the backed up version.
			$backupNuSpecFilePath = Get-NuSpecBackupFilePath
			if (Test-Path $backupNuSpecFilePath -PathType Leaf)
			{
				Copy-Item -Path $backupNuSpecFilePath -Destination $NuSpecFilePath -Force
				Remove-Item -Path $backupNuSpecFilePath -Force
			}
		}

		# If we checked the NuSpec file out from TFS.
		if ((Test-Path $NuSpecFilePath) -and ($script:nuSpecFileWasAlreadyCheckedOut -eq $false))
		{
			# If the NuSpec file should not be updated, or the contents have not been changed.
			$newNuSpecFileContents = [System.IO.File]::ReadAllText($NuSpecFilePath)
			if ($DoNotUpdateNuSpecFile -or ($script:nuSpecFileContentsBeforeCheckout -eq $newNuSpecFileContents))
			{
				# Try and undo our checkout from TFS.
				Tfs-Undo -Path $NuSpecFilePath
				
				# Also reset the file's LastWriteTime so that MSBuild does not always rebuild the project because it thinks the .nuspec file was modified after the project's .pdb file.
				# If we recorded the NuSpec file's last write time, then reset it.
				if ($script:nuSpecLastWriteTimeBeforeCheckout -ne $null)
				{
					# We first have to make sure the file is writable before trying to set the LastWriteTime, and then restore the Read-Only attribute if it was set before.
					$nuspecFileInfo = New-Object System.IO.FileInfo($NuSpecFilePath)
					$nuspecFileIsReadOnly = $nuspecFileInfo.IsReadOnly
					$nuspecFileInfo.IsReadOnly = $false
					[System.IO.File]::SetLastWriteTime($NuSpecFilePath, $script:nuSpecLastWriteTimeBeforeCheckout)
					if ($nuspecFileIsReadOnly) { $nuspecFileInfo.IsReadOnly = $true }
				}
			}
		}
	}
}

# Display the time that this script finished running, and how long it took to run.
$scriptFinishTime = Get-Date
$scriptElapsedTimeInSeconds = ($scriptFinishTime - $scriptStartTime).TotalSeconds.ToString()
Write-Verbose "New-NuGetPackage script finished running at $($scriptFinishTime.TimeOfDay.ToString()). Completed in $scriptElapsedTimeInSeconds seconds."
