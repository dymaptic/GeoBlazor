try
{
    $Build = npm run debugBuild 2>&1
    Write-Output $Build
    $HasError = ($Build -like "*Error*")
    Write-Output "-----"
    if ($HasError -ne $null)
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