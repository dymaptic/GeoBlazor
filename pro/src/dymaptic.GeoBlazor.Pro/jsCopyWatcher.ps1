# Build the absolute path based on the script's directory
$folderPath = Join-Path $PSScriptRoot "..\..\..\src\dymaptic.GeoBlazor.Core\Scripts"

# (Optional) Resolve the full path (for debugging/logging)
$folderPath = (Resolve-Path $folderPath).Path

# Create a file system watcher
$watcher = New-Object System.IO.FileSystemWatcher
$watcher.Path = $folderPath
$watcher.Filter = "*.ts"
$watcher.IncludeSubdirectories = $true
$watcher.EnableRaisingEvents = $true

# Define a variable to track the time of the last script run
$global:LastRunTime = Get-Date

$action = {
    $folderPath = Join-Path $PSScriptRoot "..\..\..\src\dymaptic.GeoBlazor.Core\Scripts"
    $outputDir = "./Scripts"
    
    $currentTime = Get-Date
    # Only run if more than 1 second has passed since the last run
    if (($currentTime - $global:LastRunTime).TotalSeconds -lt 10) {
        return
    }
    $global:LastRunTime = $currentTime

    Write-Host "Change detected in $($Event.SourceEventArgs.FullPath). Running scripts..."

    Write-Host "Copying GeoBlazor Core Scripts from $folderPath to $outputDir"
    Copy-Item -Path $folderPath -Destination $outputDir -Recurse -Force
    Write-Host "-----"
    Write-Host "Copying Complete"
    Write-Host "-----"

    $Build = npm run debugBuild 2>&1
    Write-Output $Build
    Write-Host "-----"
    Write-Host "NPM Build Complete"
    Write-Host "-----"
    Write-Host "Listening for next change..."
}

# Register the event handlers
Register-ObjectEvent $watcher "Changed" -Action $action
Register-ObjectEvent $watcher "Created" -Action $action
Register-ObjectEvent $watcher "Deleted" -Action $action
Register-ObjectEvent $watcher "Renamed" -Action $action

# Keep the script running until Ctrl-C is pressed
Write-Host "Watching for changes in $folderPath. Press Ctrl-C to stop."
while ($true) {
    Start-Sleep -Seconds 1
}
