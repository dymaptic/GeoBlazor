param([switch]$publish, [string]$test)
# example: .\bumpVersion.ps1 -test 1.2.3 ---- would test the version bump from 1.2.3 to 1.2.4
# example: .\bumpVersion.ps1 -publish ---- compares against nuget, increments the 3rd number by one

## Read Directory.Build.Props to get the version number and increment it
$DirectoryBuildPropsPath = Join-Path -Path $PSScriptRoot "./Directory.Build.props"
[xml]$coreProps = [xml](Get-Content $DirectoryBuildPropsPath)
$CoreVersion = $coreProps.Project.PropertyGroup.CoreVersion

if ($null -ne $test -and $test -ne ""){
    $CoreVersion = $test
}

Write-Output "Current Repository Version: $CoreVersion"

$CoreVersion -match '(\d+)\.(\d+)\.(\d+)\.?(\d*)?-?(beta)?-?(\d*)?'
$majorVersion = [int]$matches[1]
$minorVersion = [int]$matches[2]
$patchVersion = [int]$matches[3]
$buildVersion = if ($matches.Count -gt 4) { [int]$matches[4] } else { 0 }
$isBeta = if ($matches.Count -gt 5) { $null -ne $matches[5] } else { $false }
$betaVersion = if ($matches.Count -gt 6) { [int]$matches[6] } else { 0 }

if ($publish)
{
    if ($isBeta)
    {
        throw "Cannot publish a beta version. Please update the version in Directory.Build.props to a release version."
    }

    ## Check the latest version on Nuget.org using web API
    $nugetUrl = "https://azuresearch-usnc.nuget.org/query?q=dymaptic.geoblazor.core&prerelease=false"
    $response = Invoke-RestMethod -Uri $nugetUrl -Method Get
    $latestVersion = $null
    if ($response.data.Count -gt 0) {
        # Find the highest version (should be first, but sort just in case)
        $latestVersion = ($response.data | Sort-Object { [version]$_.version } -Descending)[0].version
    }
    if ($null -eq $latestVersion) {
        throw "Could not determine latest version from NuGet API."
    }
    $latestVersion -match '(\d+)\.(\d+)\.(\d+)\.?(\d*)?(-beta-)?(\d*)?'
    $nugetMajorVersion = [int]$matches[1]
    $nugetMinorVersion = [int]$matches[2]
    $nugetPatchVersion = [int]$matches[3]
    $nugetBuildVersion = if ($matches.Count -gt 4) { [int]$matches[4] } else { 0 }
    Write-Output "Latest Version on Nuget.org: $nugetMajorVersion.$nugetMinorVersion.$nugetPatchVersion.$nugetBuildVersion"
    
    if ($nugetMajorVersion -gt $majorVersion `
        -or ($nugetMajorVersion -eq $majorVersion -and $nugetMinorVersion -gt $minorVersion) `
        -or ($nugetMajorVersion -eq $majorVersion -and $nugetMinorVersion -eq $minorVersion -and $nugetPatchVersion -gt $patchVersion))
    {
        throw "Version in Nuget is greater than local version. Please update the version in Directory.Build.props to match the latest version on Nuget.org."
    }
    
    if ($nugetMajorVersion -eq $majorVersion -and $nugetMinorVersion -eq $minorVersion -and $nugetPatchVersion -eq $patchVersion)
    {
        # Increment the patch version for release
        $CoreVersion = "$majorVersion.$minorVersion.$($patchVersion + 1)"
    }
    else
    {
        # Chop off the build version, we don't need to publish that, but the version is already higher than nuget.
        $CoreVersion = "$majorVersion.$minorVersion.$patchVersion"
    }
}
else
{
    # For non-release builds, increment the build number
    if ($isBeta)
    {
        # Increment the beta version
        $CoreVersion = "$majorVersion.$minorVersion.$patchVersion.$buildVersion-beta-$($betaVersion + 1)"
    }
    else
    {
        # Increment the build version for local tracking
        $CoreVersion = "$majorVersion.$minorVersion.$patchVersion.$([int]$buildVersion + 1)"
    }
}

Write-Host "Updating CoreVersion to $CoreVersion"
if ($null -eq $test -or $test -eq "") {
    # Set the version number in Directory.Build.props
    $coreProps.Project.PropertyGroup.CoreVersion = $CoreVersion
    $coreProps.Save($DirectoryBuildPropsPath)
}