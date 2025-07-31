param([string][Alias("c")]$Configuration = "Debug")

## Delete old assets - from prior to 4.2.x
## Eventually we can remove this, but it will make switching branches simpler
$AssetsPath = Join-Path -Path $PSScriptRoot "wwwroot/assets"
if (Test-Path $AssetsPath)
{
    Write-Output "Deleting old assets at $AssetsPath"
    Remove-Item -Path $AssetsPath -Recurse -Force -ErrorAction Stop
}

try
{
    $Install = npm install 2>&1
    Write-Output $Install
    $HasError = ($Install -like "*Error*")
    $HasWarning = ($Install -like "*Warning*")
    Write-Output "-----"
    if ($HasError -ne $null -or $HasWarning -ne $null)
    {
        Write-Output "NPM Install failed"
        exit 1
    }
    
    if ($Configuration.ToLowerInvariant() -eq "release")
    {
        $Build = npm run releaseBuild 2>&1
        Write-Output $Build
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    else
    {
        $Build = npm run debugBuild 2>&1
        Write-Output $Build
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            exit 1
        }
    }
    Write-Output "NPM Build Complete"
    exit 0
}
catch
{
    Write-Output $_
    exit 1
}