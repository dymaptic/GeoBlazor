try
{
    $Install = npm install 2>&1
    Write-Output $Install
    Write-Output "-----"
    $HasError = ($Install -like "*Error*")
    if ($HasError -ne $null)
    {
        pause
    }
    
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