param([switch]$release)

try
{
    if ($release -eq $true)
    {
        $Build = npm run releaseBuild 2>&1
        Write-Output $Build
        $HasError = ($Build -like "*Error*")
        $HasWarning = ($Build -like "*Warning*")
        Write-Output "-----"
        if ($HasError -ne $null -or $HasWarning -ne $null)
        {
            pause
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
            pause
        }
    }
    Write-Output "NPM Build Complete"
}
catch
{
    Write-Output $_
    pause
}