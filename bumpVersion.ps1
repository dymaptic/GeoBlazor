# Increments and returns the next version number based on the current version in Directory.Build.props
# If -publish is specified, checks against nuget.org and increments the patch version if needed
# If -test is specified, uses that version instead of reading from Directory.Build.props (for testing purposes)
# If neither is specified, increments the build number (or beta number if it's a beta version)
# example: .\bumpVersion.ps1 -test 1.2.3 ---- would test the version bump from 1.2.3 to 1.2.4
# example: .\bumpVersion.ps1 -publish ---- compares against nuget, increments the 3rd number by one
param([switch]$Pro, [switch][Alias("pub")]$Publish, [string]$Test)

## Read Directory.Build.Props to get the version number and increment it
$RepoRoot = $Pro ? (Join-Path $PSScriptRoot "..") : ($PSScriptRoot)

$DirectoryBuildPropsPath = Join-Path -Path $RepoRoot "Directory.Build.props"
[xml]$PropsContent = [xml](Get-Content $DirectoryBuildPropsPath)
$CurrentVersion = $Pro ? $PropsContent.Project.PropertyGroup.ProVersion : $PropsContent.Project.PropertyGroup.CoreVersion

if ($null -ne $Test -and $Test -ne ""){
    $CurrentVersion = $Test
}

$null = $CurrentVersion -match '(\d+)\.(\d+)\.(\d+)\.?(\d*)?-?(beta)?-?(\d*)?'
$MajorVersion = [int]$matches[1]
$MinorVersion = [int]$matches[2]
$PatchVersion = [int]$matches[3]
$BuildVersion = if ($matches.Count -gt 4) { [int]$matches[4] } else { 0 }
$IsBeta = if ($matches.Count -gt 5) { $null -ne $matches[5] } else { $false }
$BetaVersion = if ($matches.Count -gt 6) { [int]$matches[6] } else { 0 }
$NewVersion = ""

if ($Publish)
{
    if ($IsBeta)
    {
        throw "Cannot publish a beta version. Please update the version in Directory.Build.props to a release version."
    }
    
    ## Check the latest version on Nuget.org using web API
    $NuGetUrl = $Pro `
        ? "https://azuresearch-usnc.nuget.org/query?q=dymaptic.geoblazor.pro&prerelease=false" `
        : "https://azuresearch-usnc.nuget.org/query?q=dymaptic.geoblazor.core&prerelease=false" 
    $Response = Invoke-RestMethod -Uri $NuGetUrl -Method Get
    $LatestVersion = $null
    if ($Response.data.Count -gt 0) {
        # Find the highest version (should be first, but sort just in case)
        $LatestVersion = ($Response.data | Sort-Object { [version]$_.version } -Descending)[0].version
    }
    if ($null -eq $LatestVersion) {
        throw "Could not determine latest version from NuGet API."
    }
    $null = $LatestVersion -match '(\d+)\.(\d+)\.(\d+)\.?(\d*)?(-beta-)?(\d*)?'
    $NuGetMajorVersion = [int]$matches[1]
    $NuGetMinorVersion = [int]$matches[2]
    $NuGetPatchVersion = [int]$matches[3]
    $NuGetBuildVersion = if ($matches.Count -gt 4) { [int]$matches[4] } else { 0 }
    
    if ($NuGetMajorVersion -gt $MajorVersion `
        -or ($NuGetMajorVersion -eq $MajorVersion -and $NuGetMinorVersion -gt $MinorVersion) `
        -or ($NuGetMajorVersion -eq $MajorVersion -and $NuGetMinorVersion -eq $MinorVersion -and $NuGetPatchVersion -gt $PatchVersion))
    {
        throw "Version in Nuget is greater than local version. Please update the version in Directory.Build.props to match the latest version on Nuget.org."
    }
    
    if ($NuGetMajorVersion -eq $MajorVersion -and $NuGetMinorVersion -eq $MinorVersion -and $NuGetPatchVersion -eq $PatchVersion)
    {
        # Increment the patch version for release
        $NewVersion = "$MajorVersion.$MinorVersion.$($PatchVersion + 1)"
    }
    else
    {
        # Chop off the build version, we don't need to publish that, but the version is already higher than nuget.
        $NewVersion = "$MajorVersion.$MinorVersion.$PatchVersion"
    }
}
else
{
    # For non-release builds, increment the build number
    if ($IsBeta)
    {
        # Increment the beta version
        $NewVersion = "$MajorVersion.$MinorVersion.$PatchVersion.$BuildVersion-beta-$($BetaVersion + 1)"
    }
    else
    {
        # Increment the build version for local tracking
        $NewVersion = "$MajorVersion.$MinorVersion.$PatchVersion.$([int]$BuildVersion + 1)"
    }
}

return $NewVersion