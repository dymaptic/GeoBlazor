try
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
    Write-Output "NPM Build Complete"
}
catch
{
    Write-Output $_
    pause
}