# This is the primary build script for GeoBlazor and GeoBlazor Pro.
param(
    [switch]$Pro,
    [switch][Alias("pub")]$PublishVersion,
    [switch][Alias("obf")]$Obfuscate,
    [switch][Alias("docs")]$GenerateDocs,
    [switch][Alias("pkg")]$Package,
    [switch][Alias("bl")]$Binlog,
    [string][Alias("v")]$Version,
    [string][Alias("c")]$Configuration = "Release", 
    [string][Alias("vc")]$ValidatorConfig = "Release",
    [string][Alias("su")]$ServerUrl = "https://licensing.dymaptic.com",
    [int][Alias("retries")]$BuildRetries = 5)

Write-Host "Starting GeoBlazor Build Script"
Write-Host "Pro Build: $Pro"
Write-Host "Set Nuget Publish Version Build: $PublishVersion"
Write-Host "Obfuscate Pro Build: $Obfuscate"
Write-Host "Generate XML Documentation: $GenerateDocs"
Write-Host "Build Package: $($Package -eq $true)"
Write-Host "Version: $Version"
Write-Host "Configuration: $Configuration"
Write-Host "Validator Configuration: $ValidatorConfig"
Write-Host "License Server URL: $ServerUrl"
    
$scriptStartTime = Get-Date

$CoreRepoRoot = $PSScriptRoot
$ProRepoRoot = (Join-Path -Path $PSScriptRoot "..")
$BinlogFlag = $Binlog ? ' -bl' : ''

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
    if (Test-Path (Join-Path $CoreProjectPath "wwwroot/js")) {
        Get-ChildItem -Path (Join-Path $CoreProjectPath "wwwroot/js") -Recurse -Force | Remove-Item -Recurse -Force
    }
    
    if ($Pro -eq $true) {
        dotnet clean (Join-Path $ProProjectPath dymaptic.GeoBlazor.Pro.csproj) /p:PipelineBuild=true
        Get-ChildItem -Path (Join-Path $ProProjectPath "bin") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "obj") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "obf") -Recurse -Force | Remove-Item -Recurse -Force
        Get-ChildItem -Path (Join-Path $ProProjectPath "build/resources") -Recurse -Force | Remove-Item -Recurse -Force
        if (Test-Path (Join-Path $ProProjectPath "wwwroot/js")) {
            Get-ChildItem -Path (Join-Path $ProProjectPath "wwwroot/js") -Recurse -Force | Remove-Item -Recurse -Force
        }
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

        [xml]$CoreProps = [xml](Get-Content $CorePropsPath)
        $CurrentCoreVersion = $CoreProps.Project.PropertyGroup.CoreVersion

        if ($PublishVersion) {
            $NewCoreVersion = ./bumpVersion.ps1 -publish
        } else {
            $NewCoreVersion = ./bumpVersion.ps1
        }

        if ($Pro -eq $true) {
            if ($PublishVersion) {
                $Version = ./bumpVersion.ps1 -publish -pro
            } else {
                $Version = ./bumpVersion.ps1 -pro
            }

            if ($NewCoreVersion -gt $Version) {
                $Version = $NewCoreVersion
            } elseif ($NewCoreVersion -lt $Version) {
                "Core version ($NewCoreVersion) and Pro version ($Version) do not match after bumping. Please ensure both versions are the same in Directory.Build.props."
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
        } else {
            $Version = $NewCoreVersion
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

    # double-escape line breaks
    $CoreBuild = "dotnet build dymaptic.GeoBlazor.Core.csproj --no-restore /p:PipelineBuild=true ``
                /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:CoreVersion=$Version -c $Configuration ``
                /p:GeneratePackage=$($Package.ToString().ToLower()) $BinlogFlag 2>&1"
    Write-Host "Executing '$CoreBuild'"

    # sometimes the build fails due to a Microsoft bug, retry a few times
    for ($i = 1; $i -lt $BuildRetries; $i++) {
        try
        {
            Invoke-Expression $CoreBuild | Tee-Object -Variable Build
            if ($LASTEXITCODE -ne 0) {
                Write-Host "ERROR: Core Build command failed with exit code $LASTEXITCODE. Exiting."
                $HasError = true
                break
            }
            $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
            if ($HasError -eq $false)
            {
                break
            }
        }
        catch
        {
            $HasError = $true
            Write-Host "Build attempt $i of $BuildRetries failed with exception: $_"
        }

        Write-Host "Build attempt $i of $BuildRetries failed."
        if ($i -lt $BuildRetries -1)
        {
            Write-Host "Waiting 2 seconds before retrying..."
            Start-Sleep -Seconds 2
        }
    }

    if ($HasError -eq $true)
    {
        exit 1
    }

    if ($Package -eq $true) {
        # Copy generated NuGet package to script root
        $CoreNupkg = Get-ChildItem -Path "bin/$Configuration" -Filter "*.nupkg" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
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
        Set-Location $ProProjectPath

        $StepStartTime = Get-Date
        Write-Host ""
        Write-Host "$Step. Restoring .NET Packages" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""
        dotnet restore /p:PipelineBuild=true
        Write-Host "Step $Step completed in $( (Get-Date) - $StepStartTime )." -BackgroundColor Yellow -ForegroundColor Black -NoNewline
        Write-Host ""

        $Step++
        
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
        Set-Content 'DevBuildValidator.cs' -Value $ValidatorContent -NoNewline -Force -Encoding UTF8
        if ($IsMacOS) {
            & sync
        }
        Start-Sleep -Milliseconds 500
        $ValidatorContent = Get-Content 'DevBuildValidator.cs' -Raw;
        if ($ValidatorContent -notmatch [regex]::Escape("public string SU { get; set; } = `"$ServerUrl/api/validate/v4`";")) {
            throw "Failed to set ServerUrl in DevBuildValidator.cs"
        }
        $ValidatorContent = Get-Content 'PublishTaskValidator.cs' -Raw;
        $ValidatorContent = $ValidatorContent -replace 'public string SU \{ get; set; \} = null!;', "public string SU { get; set; } = `"$ServerUrl/api/validate/v4/publish`";"
        Set-Content 'PublishTaskValidator.cs' -Value $ValidatorContent -NoNewline -Force -Encoding UTF8
        if ($IsMacOS) {
            & sync
        }
        Start-Sleep -Milliseconds 500
        $ValidatorContent = Get-Content 'PublishTaskValidator.cs' -Raw;
        if ($ValidatorContent -notmatch [regex]::Escape("public string SU { get; set; } = `"$ServerUrl/api/validate/v4/publish`";")) {
            throw "Failed to set ServerUrl in PublishTaskValidator.cs"
        }
        
        $OptOutFromObfuscation = $Obfuscate -eq $false
        
        dotnet build dymaptic.GeoBlazor.Pro.V.csproj /p:OptOutFromObfuscation=$($OptOutFromObfuscation.ToString().ToLower()) `
            /p:ProVersion=$Version -c $ValidatorConfig $BinlogFlag 2>&1 | Tee-Object -Variable Build
        
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
        Write-Host "$Step. Building Pro project and package" -BackgroundColor DarkMagenta -ForegroundColor White -NoNewline
        Write-Host ""
        Write-Host ""

        # double-escape line breaks
        $ProBuild = "dotnet build dymaptic.GeoBlazor.Pro.csproj --no-dependencies --no-restore ``
                            /p:GenerateDocs=$($GenerateDocs.ToString().ToLower()) /p:PipelineBuild=true  /p:CoreVersion=$Version ``
                            /p:ProVersion=$Version /p:OptOutFromObfuscation=$($OptOutFromObfuscation.ToString().ToLower()) -c ``
                            $Configuration /p:GeneratePackage=$($Package.ToString().ToLower()) $BinlogFlag 2>&1"
        Write-Host "Executing '$ProBuild'"

        # sometimes the build fails due to a Microsoft bug, retry a few times
        for ($i = 1; $i -lt $BuildRetries; $i++) {
            try
            {
                Invoke-Expression $ProBuild | Tee-Object -Variable Build
                if ($LASTEXITCODE -ne 0) {
                    Write-Host "ERROR: Pro Build command failed with exit code $LASTEXITCODE. Exiting."
                    $HasError = true
                    break
                }
                $HasError = ($Build -match "[1-9][0-9]* [Ee]rror(s)" -or $Build -match "Build FAILED")
                if ($HasError -eq $false)
                {
                    break
                }
            }
            catch
            {
                $HasError = $true
                Write-Host "Build attempt $i of $BuildRetries failed with exception: $_"
            }
            
            Write-Host "Build attempt $i of $BuildRetries failed."
            if ($i -lt $BuildRetries -1)
            {
                Write-Host "Waiting 2 seconds before retrying..."
                Start-Sleep -Seconds 2
            }
        }
        
        if ($HasError -eq $true)
        {
            exit 1
        }
        
        if ($Package -eq $true) {
            # Copy generated NuGet package to script root
            $ProNupkg = Get-ChildItem -Path "bin/$Configuration" -Filter "*.nupkg" -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
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
