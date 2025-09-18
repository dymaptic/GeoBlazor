# This is the primary build script for GeoBlazor and GeoBlazor Pro.
param(
    [switch]$Pro,
    [switch][Alias("pub")]$Publish,
    [switch][Alias("obf")]$Obfuscate,
    [switch][Alias("docs")]$GenerateDocs,
    [string][Alias("c")]$Configuration = "Release", 
    [string][Alias("v")]$Version,
    [string][Alias("vc")]$ValidatorConfig = "Release",
    [string][Alias("su")]$ServerUrl = "https://licensing.dymaptic.com")

$scriptStartTime = Get-Date

$CoreRepoRoot = $PSScriptRoot
$ProRepoRoot = (Join-Path -Path $PSScriptRoot "..")
$ProProps

try {
    ## Paths
    $CorePropsPath = Join-Path -Path $CoreRepoRoot "Directory.Build.props"
    $CoreProjectPath = Join-Path -Path $CoreRepoRoot "src/dymaptic.GeoBlazor.Core"
    $ProPropsPath = Join-Path -Path $ProRepoRoot "Directory.Build.props"
    $ProProjectPath = Join-Path -Path $ProRepoRoot "src/dymaptic.GeoBlazor.Pro"
    $ValidatorProjectPath = Join-Path -Path $ProRepoRoot "src/dymaptic.GeoBlazor.Pro.Validator"
    $AssetsPath = Join-Path -Path $CoreProjectPath "wwwroot/assets"
    
    $OtherConfiguration = if ($Configuration.ToLowerInvariant() -eq "release") { "Debug" } else { "Release" }
    
    # Set up locks
    $CoreLockFilePath = Join-Path -Path $CoreProjectPath "esBuild.$OtherConfiguration.lock"
    $ProLockFilePath = Join-Path -Path $ProProjectPath "esProBuild.$OtherConfiguration.lock"
    $Locked = $null -ne (Get-Item -Path $CoreLockFilePath -EA 0) -or $null -ne (Get-Item -Path $ProLockFilePath -EA 0)
    
    if ($Locked) {
        # wait for the lock to be released
        Write-Host "Another instance of the esBuild scripts are already running, please wait."
        while (Test-Path $CoreLockFilePath -or Test-Path $ProLockFilePath) {
            Start-Sleep -Seconds 1
            Write-Host -NoNewline "."
        }
        Write-Host "Lock released, continuing..."
    }
    
    ## Create lock files to prevent multiple instances of the script from running at the same time
    New-Item -Path $CoreLockFilePath
    New-Item -Path $ProLockFilePath
    
    # Set Environment Variables
    $env:PipelineBuild = "true"
    
    $Step = 1

    ## Clean out old build artifacts
    $StepStartTime = Get-Date
    Write-Host ""
    Write-Host "$Step. Cleaning old build artifacts" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
    Write-Host ""
    Write-Host ""
    dotnet clean (Join-Path $CoreProjectPath dymaptic.GeoBlazor.Core.csproj) /p:PipelineBuild=true
    Get-ChildItem -Path (Join-Path $CoreProjectPath "bin") -Recurse -Force | Remove-Item -Recurse -Force
    Get-ChildItem -Path (Join-Path $CoreProjectPath "obj") -Recurse -Force | Remove-Item -Recurse -Force
    Get-ChildItem -Path (Join-Path $CoreProjectPath "wwwroot/js") -Recurse -Force | Remove-Item -Recurse -Force
    if ($Pro -eq $true) {
        dotnet clean (Join-Path $ProProjectPath dymaptic.GeoBlazor.Pro.csproj) /p:PipelineBuild=true
        Get-ChildItem -Path (Join-Path $ProProjectPath "bin") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "obj") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "obf") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "build/resources") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "wwwroot/js") -Recurse -Force | Remove-Item -Recurse -Force
        dotnet clean (Join-Path $ValidatorProjectPath dymaptic.GeoBlazor.Pro.V.csproj)
        Get-ChildItem -Path (Join-Path $ValidatorProjectPath "bin") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ValidatorProjectPath "obj") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ValidatorProjectPath "obf") -Recurse -Force | Remove-Item -Recurse -Force
    }
    Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
    Write-Host ""

    $Step++

    ## Delete old assets - from prior to 4.2.x
    if (Test-Path $AssetsPath) {
        $StepStartTime = Get-Date
        Write-Host ""
        Write-Host "$Step. Deleting old assets at $AssetsPath" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        Get-ChildItem -Path $AssetsPath -Recurse | Remove-Item -Recurse -Force
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""

        $Step++
    }
    
    $CustomVersionSet = $null -ne $Version -and $Version -ne ""

    if ($CustomVersionSet -ne $true) {
        $StepStartTime = Get-Date
        Set-Location $CoreRepoRoot

        ## Set the version number in Directory.Build.props
        Write-Host ""
        Write-Host "$Step. Updating Library Versions" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""

        if ($Pro -eq $true) {
            if ($Publish) {
                $Version = ./bumpVersion.ps1 -publish -pro
            } else {
                $Version = ./bumpVersion.ps1 -pro
            }

            [xml]$ProProps = [xml](Get-Content $ProPropsPath)
            $CurrentProVersion = $ProProps.Project.PropertyGroup.ProVersion
            if ($CurrentProVersion -eq $Version) {
                Write-Host "Pro Version is already set to $Version, no update needed."
            }
            else
            {
                Write-Host "Updating Pro Version from $CurrentProVersion to $Version"
                $ProProps.Project.PropertyGroup.ProVersion = $Version
                $ProProps.Save($ProPropsPath)
            }
        }

        [xml]$CoreProps = [xml](Get-Content $CorePropsPath)
        $CurrentCoreVersion = $CoreProps.Project.PropertyGroup.CoreVersion

        if ($Publish) {
            $NewCoreVersion = ./bumpVersion.ps1 -publish
        } else {
            $NewCoreVersion = ./bumpVersion.ps1
        }
        
        if ($Pro -eq $true -and $NewCoreVersion -ne $Version) {
            throw "Core version ($NewCoreVersion) and Pro version ($Version) do not match after bumping. Please ensure both versions are the same in Directory.Build.props."
        }
        
        if ($CurrentCoreVersion -eq $Version) {
            Write-Host "Core Version is already set to $Version, no update needed."
        }
        else {
            Write-Host "Updating Core Version from $CurrentCoreVersion to $Version"
            $CoreProps.Project.PropertyGroup.CoreVersion = $Version
            $CoreProps.Save($CorePropsPath)
        }
        
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""

        $Step++
    }

    Set-Location $CoreProjectPath

    $StepStartTime = Get-Date

    $CoreLockFilePath = Join-Path -Path $CoreProjectPath "esBuild.$Configuration.lock"

    $Locked = $null -ne (Get-Item -Path $CoreLockFilePath -EA 0)

    if ($Locked) {
        # wait for the lock to be released
        Write-Host "Another instance of the esBuild script is already running, please wait."
        while (Test-Path $CoreLockFilePath) {
            Start-Sleep -Seconds 1
            Write-Host -NoNewline "."
        }
        Write-Host "Lock released, continuing..."
    }

    Write-Host ""
    Write-Host "$Step. Building Core JavaScript" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
    Write-Host ""
    Write-Host ""
    ./esBuild.ps1 -c $Configuration
    Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
    Write-Host ""

    $Step++

    $StepStartTime = Get-Date
    Write-Host ""
    Write-Host "$Step. Restoring .Net Packages" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
    Write-Host ""
    Write-Host ""
    dotnet restore /p:PipelineBuild=true
    Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
    Write-Host ""

    $Step++

    $StepStartTime = Get-Date
    Write-Host ""
    Write-Host "$Step. Building Core Project and NuGet Package" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
    Write-Host ""
    Write-Host ""
    dotnet build dymaptic.GeoBlazor.Core.csproj --no-restore /p:PipelineBuild=true `
            /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:CoreVersion=$Version -c $Configuration 2>&1 `
            | Tee-Object -Variable Build
    $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
    if ($HasError -eq $true) {
        if ($Build.Contains("No file exists for the asset") -or $Build.Contains("File not found")) {
            # this is a Microsoft bug, try again
            dotnet build dymaptic.GeoBlazor.Core.csproj --no-restore /p:PipelineBuild=true `
                    /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:CoreVersion=$Version -c $Configuration 2>&1 `
                    | Tee-Object -Variable Build
            $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
            if ($HasError -eq $true) {
                exit 1
            }
        }
        else {
            exit 1
        }
    }

    if ($Configuration.ToLowerInvariant() -eq "release") {
        # Copy generated NuGet package to script root
        $CoreNupkg = Get-ChildItem -Path "bin/Release" -Filter "*.nupkg" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
        if ($CoreNupkg) {
            Copy-Item -Path $CoreNupkg.FullName -Destination $CoreRepoRoot -Force
            Write-Host "Copied $($CoreNupkg.Name) to $CoreRepoRoot"
            if ($Pro -eq $true) {
                Copy-Item -Path $CoreNupkg.FullName -Destination $ProRepoRoot -Force
                Write-Host "Copied $($CoreNupkg.Name) to $ProRepoRoot"
            }
        }
    }

    Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
    Write-Host ""

    $Step++

    if ($Pro -eq $true) {
        ## Build the Validator MSBuild task
        $StepStartTime = Get-Date
        Set-Location $ValidatorProjectPath
        Write-Host ""
        Write-Host "$Step. Building Validator project in configuration $ValidatorConfig" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        
        # Set the ServerUrls in the Validator project
        $ServerUrl = $ServerUrl.TrimEnd('/')
        Write-Host "Setting License Server Url to $ServerUrl"
        $ValidatorContent = Get-Content 'DevBuildValidator.cs' -Raw;
        $ValidatorContent = $ValidatorContent -replace 'public string SU \{ get; set; \} = null!;', "public string SU { get; set; } = `"$ServerUrl/api/validate/v4`";"
        Set-Content 'DevBuildValidator.cs' -Value $ValidatorContent -NoNewline
        $ValidatorContent = Get-Content 'PublishTaskValidator.cs' -Raw;
        $ValidatorContent = $ValidatorContent -replace 'public string SU \{ get; set; \} = null!;', "public string SU { get; set; } = `"$ServerUrl/api/validate/v4/publish`";"
        Set-Content 'PublishTaskValidator.cs' -Value $ValidatorContent -NoNewline
        
        dotnet build dymaptic.GeoBlazor.Pro.V.csproj /p:OptOutFromObfuscation=$($Obfuscate.ToString().ToLower()) `
            /p:ProVersion=$Version -c $ValidatorConfig 2>&1 | Tee-Object -Variable Build
        
        # Restore the ServerUrls in the Validator project
        $ValidatorContent = Get-Content 'DevBuildValidator.cs' -Raw;
        $ValidatorContent = $ValidatorContent -replace 'public string SU \{ get; set; \} = ".*";', 'public string SU { get; set; } = null!;'
        Set-Content 'DevBuildValidator.cs' -Value $ValidatorContent -NoNewline
        $ValidatorContent = Get-Content 'PublishTaskValidator.cs' -Raw;
        $ValidatorContent = $ValidatorContent -replace 'public string SU \{ get; set; \} = ".*";', 'public string SU { get; set; } = null!;'
        Set-Content 'PublishTaskValidator.cs' -Value $ValidatorContent -NoNewline
        $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
        if ($HasError -eq $true) {
            exit 1
        }
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""

        $Step++

        Set-Location $ProProjectPath

        $StepStartTime = Get-Date

        $ProLockFilePath = Join-Path -Path $ProProjectPath "esProBuild.$Configuration.lock"
        $Locked = $null -ne (Get-Item -Path $ProLockFilePath -EA 0)

        if ($Locked) {
            # wait for the lock to be released
            Write-Host "Another instance of the esBuild scripts are already running, please wait."
            while (Test-Path $ProLockFilePath) {
                Start-Sleep -Seconds 1
                Write-Host -NoNewline "."
            }
            Write-Host "Lock released, continuing..."
        }
        
        Write-Host ""
        Write-Host "$Step. Building Pro JavaScript" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        ./esProBuild.ps1 -c $Configuration
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""

        $Step++

        $StepStartTime = Get-Date
        Write-Host ""
        Write-Host "$Step. Restoring .NET Packages" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        dotnet restore /p:PipelineBuild=true
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""
        
        $Step++

        $StepStartTime = Get-Date
        Write-Host ""
        Write-Host "$Step. Building Pro project and package" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        dotnet build dymaptic.GeoBlazor.Pro.csproj --no-dependencies --no-restore `
            /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:PipelineBuild=true  /p:CoreVersion=$Version `
            /p:ProVersion=$Version /p:OptOutFromObfuscation=$($Obfuscate.ToString().ToLower()) -c `
            $Configuration 2>&1 | Tee-Object -Variable Build
        $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
        if ($HasError -eq $true) {
            if ($Build.Contains("No file exists for the asset") -or $Build.Contains("File not found")) {
                # this is a Microsoft bug, try again
                dotnet build dymaptic.GeoBlazor.Pro.csproj --no-dependencies --no-restore `
                    /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:PipelineBuild=true  /p:CoreVersion=$Version `
                    /p:ProVersion=$Version /p:OptOutFromObfuscation=$($Obfuscate.ToString().ToLower()) -c `
                    $Configuration 2>&1 | Tee-Object -Variable Build
                $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
                if ($HasError -eq $true) {
                    exit 1
                }
            }
            else {
                exit 1
            }
        }
        
        if ($Configuration.ToLowerInvariant() -eq "release") {
            # Copy generated NuGet package to script root
            $ProNupkg = Get-ChildItem -Path "bin/Release" -Filter "*.nupkg" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
            if ($ProNupkg) {
                Copy-Item -Path $ProNupkg.FullName -Destination $ProRepoRoot -Force
                Write-Host "Copied $($ProNupkg.Name) to $ProRepoRoot"
            }
        }
        
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""
    }
}
catch {
    Write-Host "An error occurred: $_"
    exit 1
}
finally {
    $totalTime = (Get-Date) - $scriptStartTime
    # Remove lock files
    if (Test-Path $CoreLockFilePath) {
        Remove-Item -Path $CoreLockFilePath -Force
    }
    if (Test-Path $ProLockFilePath) {
        Remove-Item -Path $ProLockFilePath -Force
    }
    Write-Host ""
    Write-Host "Total script execution time: $totalTime." -BackgroundColor DarkBlue -ForegroundColor White
    Set-Location $PSScriptRoot
}
