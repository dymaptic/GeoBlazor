#!/usr/bin/env dotnet

#:package Polly.Core@8.6.5
#:project ../utilities/Utilities.csproj

// GeoBlazorBuild - Primary build script for GeoBlazor and GeoBlazor Pro
// Usage: dotnet GeoBlazorBuild.dll [options] or ./GeoBlazorBuild.exe [options]
//   -pro                               Build GeoBlazor Pro as well as Core (default is false)
//   -po,  --pro-only                   Build only GeoBlazor Pro, skipping Core (implies -pro, default is false)
//   -pub, --publish-version            Truncate the build version to 3 digits for NuGet (default is false)
//   -obf, --obfuscate                  Obfuscate the Pro license validation logic (default is false)
//   -docs, --generate-docs             Generate documentation files for the docs site (default is false)
//   -xml, --generate-xml               Generate the XML comments for intellisense (default is false)
//   -pkg, --package                    Create NuGet packages (default is false)
//   -bl, --binlog                      Generate MSBuild binary log files (default is false)
//   -v, --version <string>             Specify a custom version number, or "current" (default is to auto-increment)
//   -c, --configuration <string>       Build configuration (default is 'Release')
//   -vc, --validator-config <string>   Validator build configuration (default is 'Release')
//   -nc, --no-clean                    Skip the clean step (default is false)
//   -su, --server-url <string>         License server URL (default is 'https://licensing.dymaptic.com')
//   -retries <int>                     Number of times to retry the build on failure (default is 5)
//   -fast, --fast                      Incremental dev build: skip clean, version bump, obfuscation, docs, xml, package; defaults to Debug
//   -h, --help                         Display this help message

using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Utilities;


// Paths
// Get the script cs file path, that way we can run this script from either the CS file or the Executable
string scriptsDir = PathFinder.GetScriptsDirectory();

// Scripts folder is at GeoBlazor/build-tools/build-scripts/, Core root is GeoBlazor/
string coreRepoRoot = Path.GetFullPath(Path.Combine(scriptsDir, "..", ".."));
string proRepoRoot = Path.GetFullPath(Path.Combine(coreRepoRoot, ".."));

string corePropsPath = Path.Combine(coreRepoRoot, "Directory.Build.props");
string coreProjectPath = Path.Combine(coreRepoRoot, "src", "dymaptic.GeoBlazor.Core");
string proPropsPath = Path.Combine(proRepoRoot, "Directory.Build.props");
string proProjectPath = Path.Combine(proRepoRoot, "src", "dymaptic.GeoBlazor.Pro");
string validatorProjectPath = Path.Combine(proRepoRoot, "src", "dymaptic.GeoBlazor.Pro.Validator");

DateTime scriptStartTime = DateTime.Now;

// Reuse a warm MSBuild server node across the sequential dotnet invocations below.
Environment.SetEnvironmentVariable("MSBUILDUSESERVER", "1");
Environment.SetEnvironmentVariable("DOTNET_CLI_USE_MSBUILD_SERVER", "1");

// Parse command line arguments
bool pro = false;
bool core = true; // Core builds by default, Pro is opt-in
bool publishVersion = false;
bool obfuscate = false;
bool generateDocs = false;
bool generateXmlComments = false;
bool package = false;
bool binlog = false;
bool help = false;
bool clean = true;
bool fast = false;
bool configExplicitlySet = false;
string? customVersion = null;
string configuration = Environment.GetEnvironmentVariable("Configuration") ?? "Release";
string validatorConfig = Environment.GetEnvironmentVariable("ValidatorConfiguration") ?? "Release";
string serverUrl = "https://licensing.dymaptic.com";
int buildRetries = 5;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();

    switch (arg)
    {
        case "-pro":
        case "--pro":
            pro = true;

            break;
        case "-po":
        case "--pro-only":
            pro = true;
            core = false;

            break;
        case "-pub":
        case "--publish-version":
            publishVersion = true;

            break;
        case "-obf":
        case "--obfuscate":
            obfuscate = true;

            break;
        case "-docs":
        case "--generate-docs":
            generateDocs = true;

            break;
        case "-xml":
        case "--generate-xml":
            generateXmlComments = true;

            break;
        case "-pkg":
        case "--package":
            package = true;

            break;
        case "-bl":
        case "--binlog":
            binlog = true;

            break;
        case "-h":
        case "--help":
            help = true;

            break;
        case "-nc":
        case "--no-clean":
            clean = false;

            break;
        case "-fast":
        case "--fast":
            fast = true;

            break;
        case "-v":
        case "--version":
            if (i + 1 < args.Length)
            {
                string version = args[++i];

                if (version.Trim('"') == "current")
                {
                    customVersion = ReadCurrentVersion(corePropsPath, "CoreVersion");
                }
                else
                {
                    customVersion = version.Trim('"');
                }
            }

            break;
        case "-c":
        case "--configuration":
            if (i + 1 < args.Length)
            {
                configuration = args[++i];
                configExplicitlySet = true;
            }

            break;
        case "-vc":
        case "--validator-config":
            if (i + 1 < args.Length)
            {
                validatorConfig = args[++i];
            }

            break;
        case "-su":
        case "--server-url":
            if (i + 1 < args.Length)
            {
                serverUrl = args[++i];
            }

            break;
        case "-retries":
        case "--retries":
            if ((i + 1 < args.Length) && int.TryParse(args[++i], out int retries))
            {
                buildRetries = retries;
            }

            break;
    }
}

if (help)
{
    Console.WriteLine("GeoBlazor Build Script");
    Console.WriteLine();
    Console.WriteLine("Parameters:");
    Console.WriteLine("  -pro                               Build GeoBlazor Pro as well as Core (default is false)");

    Console.WriteLine(
        "  -po,  --pro-only                   Build only GeoBlazor Pro, skipping Core (implies -pro, default is false)");

    Console.WriteLine(
        "  -pub, --publish-version            Truncate the build version to 3 digits for NuGet (default is false)");

    Console.WriteLine(
        "  -obf, --obfuscate                  Obfuscate the Pro license validation logic (default is false)");

    Console.WriteLine(
        "  -docs, --generate-docs             Generate documentation files for the docs site (default is false)");

    Console.WriteLine(
        "  -xml, --generate-xml               Generate the XML comments for intellisense (default is false)");
    Console.WriteLine("  -pkg, --package                    Create NuGet packages (default is false)");
    Console.WriteLine("  -bl, --binlog                      Generate MSBuild binary log files (default is false)");

    Console.WriteLine(
        "  -v, --version <string>             Specify a custom version number (default is to auto-increment)");
    Console.WriteLine("  -c, --configuration <string>       Build configuration (default is 'Release')");
    Console.WriteLine("  -nc, --no-clean                    Skip the clean step (default is false)");
    Console.WriteLine("  -vc, --validator-config <string>   Validator build configuration (default is 'Release')");

    Console.WriteLine(
        "  -su, --server-url <string>         License server URL (default is 'https://licensing.dymaptic.com')");

    Console.WriteLine(
        "  -retries <int>                     Number of times to retry the build on failure (default is 5)");

    Console.WriteLine(
        "  -fast, --fast                      Incremental dev build: skip clean, version bump, obfuscation, docs, xml, package; defaults to Debug");
    Console.WriteLine("  -h, --help                         Display this help message");

    return 0;
}

// Fast (incremental dev) mode: flip the anti-incremental release defaults.
if (fast)
{
    // Clean and version-bump (a global MSBuild evaluation input) both defeat incrementality.
    clean = false;

    if (!configExplicitlySet)
    {
        configuration = "Debug";
    }

    // Warn then ignore any release-only heavy steps passed alongside -fast.
    if (obfuscate || generateDocs || generateXmlComments || package)
    {
        Console.WriteLine(
            "WARNING: -fast ignores -obf, -docs, -xml, and -pkg (release-only steps).");
    }

    obfuscate = false;
    generateDocs = false;
    generateXmlComments = false;
    package = false;
}

CancellationTokenSource cts = new();

// Handle Ctrl+C by killing the child process
Console.CancelKeyPress += async (_, e) =>
{
    e.Cancel = true; // Prevent immediate termination of this script
    Console.WriteLine("Cancellation requested, waiting for current operations to complete...");
    await cts.CancelAsync();
    Environment.Exit(1);
};

Console.WriteLine("Starting GeoBlazor Build Script");
Console.WriteLine($"Fast (incremental dev) Build: {fast}");
Console.WriteLine($"Pro Build: {pro}");
Console.WriteLine($"Set NuGet Publish Version Build: {publishVersion}");
Console.WriteLine($"Obfuscate Pro Build: {obfuscate}");
Console.WriteLine($"Generate Documentation Files: {generateDocs}");
Console.WriteLine($"Generate XML Documentation: {generateXmlComments}");
Console.WriteLine($"Build Package: {package}");
Console.WriteLine($"Version: {customVersion ?? "(auto)"}");
Console.WriteLine($"Configuration: {configuration}");
Console.WriteLine($"Validator Configuration: {validatorConfig}");
Console.WriteLine($"License Server URL: {serverUrl}");
Console.WriteLine($"Build Retries: {buildRetries}");
Console.WriteLine($"Generating MSBuild Binary Logs: {binlog}");

int step = 1;
DateTime stepStartTime = DateTime.Now;

try
{
    string version = customVersion ?? "";
    bool customVersionSet = !string.IsNullOrEmpty(customVersion);

    // Fast mode reads the current version without bumping (writing props breaks incrementality).
    if (fast && !customVersionSet)
    {
        version = pro
            ? ReadCurrentVersion(proPropsPath, "ProVersion")
            : ReadCurrentVersion(corePropsPath, "CoreVersion");
    }

    // STEP: Stop the Analyzers running in your IDE, so the build can continue
    GbCli.WriteStepHeader(step, "Preparing Build Environment. Stopping IDE Analyzers.");
    ProcessKiller.KillByProcessOrFileName("dymaptic.GeoBlazor.Core.Analyzers.dll");

    GbCli.WriteStepCompleted(step, stepStartTime);
    step++;
    stepStartTime = DateTime.Now;


    if (clean)
    {
        // STEP: Clean old build artifacts
        GbCli.WriteStepHeader(step, "Cleaning old build artifacts");

        List<Task> cleanTasks = [];

        cleanTasks.Add(ProcessRunner.RunDotnetCommand(coreProjectPath, "clean", null, cts.Token,
            $"\"{Path.Combine(coreProjectPath, "dymaptic.GeoBlazor.Core.csproj")}\""));
        cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(coreProjectPath, "bin"))));
        cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(coreProjectPath, "obj"))));
        cleanTasks.Add(Task.Run(() => DeleteDirectoryContentsIfExists(Path.Combine(coreProjectPath, "wwwroot", "js"))));
        cleanTasks.Add(Task.Run(() => DeleteFileIfExists(Path.Combine(coreProjectPath, "esBuild.lock"))));

        if (pro)
        {
            cleanTasks.Add(ProcessRunner.RunDotnetCommand(proProjectPath, "clean", null, cts.Token,
                $"\"{Path.Combine(proProjectPath, "dymaptic.GeoBlazor.Pro.csproj")}\""));
            cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(proProjectPath, "bin"))));
            cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(proProjectPath, "obj"))));
            cleanTasks.Add(Task.Run(() => DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "obf"))));

            cleanTasks.Add(Task.Run(() =>
                DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "build", "resources"))));

            cleanTasks.Add(
                Task.Run(() => DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "wwwroot", "js"))));
            cleanTasks.Add(Task.Run(() => DeleteFileIfExists(Path.Combine(proProjectPath, "esBuild.lock"))));

            if (Directory.Exists(validatorProjectPath))
            {
                cleanTasks.Add(ProcessRunner.RunDotnetCommand(validatorProjectPath, "clean", null, cts.Token,
                    $"\"{Path.Combine(validatorProjectPath, "dymaptic.GeoBlazor.Pro.V.csproj")}\""));
                cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(validatorProjectPath, "bin"))));
                cleanTasks.Add(Task.Run(() => DeleteDirectoryIfExists(Path.Combine(validatorProjectPath, "obj"))));

                cleanTasks.Add(
                    Task.Run(() => DeleteDirectoryContentsIfExists(Path.Combine(validatorProjectPath, "obf"))));
            }
        }

        await Task.WhenAll(cleanTasks);

        GbCli.WriteStepCompleted(step, stepStartTime);
        step++;
    }

    // STEP: Update library versions (if no custom version specified; skipped in fast mode)
    if (!customVersionSet && !fast)
    {
        stepStartTime = DateTime.Now;
        GbCli.WriteStepHeader(step, "Updating Library Versions");

        XDocument coreProps = XDocument.Load(corePropsPath);
        string? currentCoreVersion = coreProps.Root?.Element("PropertyGroup")?.Element("CoreVersion")?.Value;

        string newCoreVersion = await BumpVersionAsync(coreRepoRoot, publishVersion, false);

        if (pro)
        {
            XDocument proProps = XDocument.Load(proPropsPath);
            string? currentProVersion = proProps.Root?.Element("PropertyGroup")?.Element("ProVersion")?.Value;

            version = await BumpVersionAsync(proRepoRoot, publishVersion, true);

            // Compare versions and use the higher one
            if ((CompareVersions(newCoreVersion, version) > 0) &&
                (CompareVersions(currentCoreVersion ?? "0.0.0", currentProVersion ?? "0.0.0") > 0))
            {
                version = newCoreVersion;
            }
            else if (CompareVersions(newCoreVersion, version) < 0)
            {
                Console.WriteLine($"Core version ({newCoreVersion}) and Pro version ({version
                }) do not match after bumping. Please ensure both versions are the same in Directory.Build.props.");
            }

            if (currentProVersion == version)
            {
                Console.WriteLine($"Pro Version is already set to {version}, no update needed.");
            }
            else
            {
                Console.WriteLine($"Updating Pro Version from {currentProVersion} to {version}");
                proProps.Root?.Element("PropertyGroup")?.SetElementValue("ProVersion", version);
                proProps.Save(proPropsPath);
            }
        }
        else
        {
            version = newCoreVersion;
        }

        if (currentCoreVersion == version)
        {
            Console.WriteLine($"Core Version is already set to {version}, no update needed.");
        }
        else
        {
            Console.WriteLine($"Updating Core Version from {currentCoreVersion} to {version}");
            coreProps.Root?.Element("PropertyGroup")?.SetElementValue("CoreVersion", version);
            coreProps.Save(corePropsPath);
        }

        GbCli.WriteStepCompleted(step, stepStartTime);
        step++;
    }

    // Core-specific steps
    if (core)
    {
        // STEP: Restore .NET packages for Core
        stepStartTime = DateTime.Now;
        GbCli.WriteStepHeader(step, "Restoring GeoBlazor Core .NET Packages");

        await ProcessRunner.RunDotnetCommand(coreProjectPath, "restore", null, cts.Token);

        GbCli.WriteStepCompleted(step, stepStartTime);
        step++;

        // STEP: Build Core Project and NuGet Package
        stepStartTime = DateTime.Now;
        GbCli.WriteStepHeader(step, package ? "Building Core Project and NuGet Package" : "Building Core Project");

        List<string> coreBuildArgs =
        [
            "dymaptic.GeoBlazor.Core.csproj",
            "--no-restore",
            "-c",
            configuration,
            $"/p:GenerateDocs={generateDocs.ToString().ToLower()}",
            $"/p:GenerateXmlComments={generateXmlComments.ToString().ToLower()}",
            $"/p:CoreVersion={version}",
            $"/p:GeneratePackage={package.ToString().ToLower()}",
            "/p:ShowScriptDialogs=false"
        ];

        if (binlog)
        {
            coreBuildArgs.Add($"-bl:\"{Path.Combine(coreRepoRoot, $"core_build_{configuration.ToLower()}.binlog")}\"");
        }

        Console.WriteLine($"Executing 'dotnet build {string.Join(" ", coreBuildArgs)}'");

        await ProcessRunner.RunDotnetCommand(coreProjectPath, "build", null, cts.Token, coreBuildArgs);

        // Verify JavaScript files were created
        string coreJsPath = Path.Combine(coreProjectPath, "wwwroot", "js");

        if (!Directory.Exists(coreJsPath) || (Directory.GetFiles(coreJsPath, "*.js").Length == 0))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Core JavaScript files still not found after waiting. Exiting.");
            Console.ResetColor();

            return 1;
        }

        if (package)
        {
            // Copy generated NuGet package to repo root
            DeleteFilesIfExists(coreRepoRoot, "dymaptic.GeoBlazor.Core.*.nupkg");
            string coreBinPath = Path.Combine(coreProjectPath, "bin", configuration);

            if (Directory.Exists(coreBinPath))
            {
                FileInfo? coreNupkg = Directory.GetFiles(coreBinPath, "*.nupkg", SearchOption.AllDirectories)
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.LastWriteTime)
                    .FirstOrDefault();

                if (coreNupkg is null)
                {
                    throw new FileNotFoundException("NuGet package not found in Core bin directory.");
                }

                File.Copy(coreNupkg.FullName, Path.Combine(coreRepoRoot, coreNupkg.Name), true);
                Console.WriteLine($"Copied {coreNupkg.Name} to {coreRepoRoot}");
            }
        }

        GbCli.WriteStepCompleted(step, stepStartTime);
        step++;
    }

    // Pro-specific steps
    if (pro)
    {
        // Refresh the ESBuild lock file to prevent the TriggerESBuild MSBuild target
        // from re-running Core ESBuild during Pro build steps. If the lock file becomes
        // stale (>5 minutes old), MSBuild would re-trigger ESBuild which wipes and
        // regenerates JS files with new content hashes, causing static web asset manifest
        // mismatches (the manifest still references the old hashes from the Core build).
        string esBuildLockPath = Path.Combine(coreProjectPath, "esBuild.lock");
        File.WriteAllText(esBuildLockPath, DateTime.Now.ToString("o"));
        Console.WriteLine("Refreshed ESBuild lock file to prevent re-trigger during Pro build.");

        // STEP: Restore Pro .NET packages
        stepStartTime = DateTime.Now;
        GbCli.WriteStepHeader(step, "Restoring GeoBlazor Pro .NET Packages");

        await ProcessRunner.RunDotnetCommand(proProjectPath, "restore", null, cts.Token);

        GbCli.WriteStepCompleted(step, stepStartTime);
        step++;

        bool optOutFromObfuscation = !obfuscate;

        // The Pro build has no project reference to the Validator; it consumes the Validator's
        // build output (copied to Pro's build/resources by CopyValidationOutput). In fast mode we
        // only skip the Validator build when that expected output already exists on disk, so a cold
        // Pro build still produces it and is never silently broken.
        string proValidatorOutput =
            Path.Combine(proProjectPath, "build", "resources", "dymaptic.GeoBlazor.Pro.V.dll");
        bool skipValidator = int.Parse(version[0].ToString()) < 5 
            || (fast && File.Exists(proValidatorOutput));

        if (skipValidator)
        {
            stepStartTime = DateTime.Now;

            GbCli.WriteStepHeader(step,
                "Skipping Validator build (fast mode, existing output found)");

            GbCli.WriteStepCompleted(step, stepStartTime);
            step++;
        }
        else
        {
            // STEP: Build Validator
            stepStartTime = DateTime.Now;
            GbCli.WriteStepHeader(step, $"Building Validator project in configuration {validatorConfig}");

            // Set the ServerUrls in the Validator project
            serverUrl = serverUrl.TrimEnd('/');
            Console.WriteLine($"Setting License Server Url to {serverUrl}");

            string BuildValidatorPath = Path.Combine(validatorProjectPath, "BuildValidator.cs");

            // Update BuildValidator.cs
            string devValidatorContent = File.ReadAllText(BuildValidatorPath);

            string nullServerUrlLine = $"public string SU {{ get; set; }} = null!;";
            string populatedServerUrlLine = $"public string SU {{ get; set; }} = \"{serverUrl}\";";

            devValidatorContent = Regex.Replace(devValidatorContent, nullServerUrlLine, populatedServerUrlLine);
            File.WriteAllText(BuildValidatorPath, devValidatorContent);
            Thread.Sleep(500);

            // Verify the update
            devValidatorContent = File.ReadAllText(BuildValidatorPath);

            if (!devValidatorContent.Contains(populatedServerUrlLine))
            {
                throw new Exception("Failed to set ServerUrl in BuildValidator.cs");
            }

            // Build validator
            List<string> validatorBuildArgs =
            [
                "dymaptic.GeoBlazor.Pro.V.csproj",
                $"/p:OptOutFromObfuscation={optOutFromObfuscation.ToString().ToLower()}",
                $"/p:ProVersion={version}",
                "-c",
                validatorConfig,
                "/p:ShowScriptDialogs=false"
            ];

            if (binlog)
            {
                validatorBuildArgs.Add($"-bl:\"{
                    Path.Combine(coreRepoRoot, $"validator_build_{validatorConfig.ToLower()}.binlog")}\"");
            }

            try
            {
                await ProcessRunner.RunDotnetCommand(validatorProjectPath, "build", null, cts.Token, validatorBuildArgs);
            }
            finally
            {
                // Restore the ServerUrls in the Validator project even if the build fails
                devValidatorContent = File.ReadAllText(BuildValidatorPath);

                devValidatorContent = Regex.Replace(devValidatorContent, populatedServerUrlLine, nullServerUrlLine);
                File.WriteAllText(BuildValidatorPath, devValidatorContent);
            }

            GbCli.WriteStepCompleted(step, stepStartTime);
            step++;
        }

        // STEP: Build Pro project and package
        stepStartTime = DateTime.Now;

        // Refresh lock file again after validator build (which can take significant time)
        File.WriteAllText(esBuildLockPath, DateTime.Now.ToString("o"));

        GbCli.WriteStepHeader(step,
            package ? "Building GeoBlazor Pro Project and NuGet Package" : "Building GeoBlazor Pro Project");

        List<string> proBuildArgs =
        [
            "dymaptic.GeoBlazor.Pro.csproj",
            "--no-restore",
            "-c",
            configuration,
            $"/p:GenerateDocs={generateDocs.ToString().ToLower()}",
            $"/p:GenerateXmlComments={generateXmlComments.ToString().ToLower()}",
            $"/p:CoreVersion={version}",
            $"/p:ProVersion={version}",
            $"/p:OptOutFromObfuscation={optOutFromObfuscation.ToString().ToLower()}",
            $"/p:GeneratePackage={package.ToString().ToLower()}",
            "/p:ShowScriptDialogs=false",
            "/p:SkipLocalBuildLicenseValidation=true" // LicenseValidation step is for local build testing
        ];

        if (binlog)
        {
            proBuildArgs.Add($"-bl:\"{Path.Combine(coreRepoRoot, $"pro_build_{configuration.ToLower()}.binlog")}\"");
        }

        Console.WriteLine($"Executing 'dotnet {string.Join(" ", proBuildArgs)}'");

        await ProcessRunner.RunDotnetCommand(proProjectPath, "build", null, cts.Token, proBuildArgs);

        // Verify Pro JavaScript files were created
        string proJsPath = Path.Combine(proProjectPath, "wwwroot", "js");

        if (!Directory.Exists(proJsPath) || (Directory.GetFiles(proJsPath, "*.js").Length == 0))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Pro JavaScript files still not found after waiting. Exiting.");
            Console.ResetColor();

            return 1;
        }

        if (package)
        {
            // Copy generated NuGet package to Core repo root
            DeleteFilesIfExists(coreRepoRoot, "dymaptic.GeoBlazor.Pro.*.nupkg");
            string proBinPath = Path.Combine(proProjectPath, "bin", configuration);

            if (Directory.Exists(proBinPath))
            {
                FileInfo? proNupkg = Directory.GetFiles(proBinPath, "*.nupkg", SearchOption.AllDirectories)
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.LastWriteTime)
                    .FirstOrDefault();

                if (proNupkg is null)
                {
                    throw new FileNotFoundException("NuGet package not found in Pro bin directory.");
                }

                File.Copy(proNupkg.FullName, Path.Combine(coreRepoRoot, proNupkg.Name), true);
                Console.WriteLine($"Copied {proNupkg.Name} to {coreRepoRoot}");
            }
        }

        GbCli.WriteStepCompleted(step, stepStartTime);
    }

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");

    return 1;
}
finally
{
    TimeSpan totalTime = DateTime.Now - scriptStartTime;

    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"Total script execution time: {totalTime}.");
    Console.ResetColor();
    Console.WriteLine();
}

/// <summary>
/// Deletes matching files from a directory if it exists.
/// </summary>
static void DeleteFilesIfExists(string directory, string searchPattern)
{
    if (!Directory.Exists(directory))
    {
        return;
    }

    foreach (string path in Directory.GetFiles(directory, searchPattern, SearchOption.TopDirectoryOnly))
    {
        DeleteFileIfExists(path);
    }
}

/// <summary>
/// Deletes a file if it exists.
/// </summary>
static void DeleteFileIfExists(string path)
{
    if (File.Exists(path))
    {
        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"WARNING: Failed to delete {path}: {ex.Message}");
        }
    }
}

/// <summary>
/// Deletes a directory and all its contents if it exists.
/// </summary>
/// <param name="path">The directory path to delete.</param>
/// <param name="usePowerShell">
/// If true, uses PowerShell 7 for deletion which handles long paths on Windows.
/// Useful for node_modules directories.
/// </param>
static void DeleteDirectoryIfExists(string path)
{
    if (!Directory.Exists(path))
    {
        return;
    }

    try
    {
        Directory.Delete(path, true);

        // Verify and wait for filesystem to settle
        int retries = 10;

        while (Directory.Exists(path) && (retries > 0))
        {
            Thread.Sleep(100);
            retries--;
        }

        if (Directory.Exists(path))
        {
            Console.WriteLine($"WARNING: Directory {path} still exists after deletion attempt");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"WARNING: Failed to delete {path}: {ex.Message}");
    }
}

/// <summary>
/// Deletes all files within a directory recursively, but keeps the directory structure.
/// </summary>
/// <param name="path">The directory whose contents should be deleted.</param>
static void DeleteDirectoryContentsIfExists(string path)
{
    if (Directory.Exists(path))
    {
        try
        {
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                File.Delete(file);
            }
        }
        catch
        {
            // Files may be locked - continue
        }
    }
}

/// <summary>
/// Increments the version number in Directory.Build.props.
/// For publish builds, checks NuGet for the latest version and increments appropriately.
/// For non-publish builds, simply increments the build number.
/// </summary>
/// <param name="repoRoot">The repository root containing Directory.Build.props.</param>
/// <param name="publish">If true, prepares a release version (3-digit, checks NuGet).</param>
/// <param name="isPro">If true, updates ProVersion; otherwise updates CoreVersion.</param>
/// <returns>The new version string.</returns>
static async Task<string> BumpVersionAsync(string repoRoot, bool publish, bool isPro)
{
    string directoryBuildPropsPath = Path.Combine(repoRoot, "Directory.Build.props");
    XDocument propsContent = XDocument.Load(directoryBuildPropsPath);

    string? currentVersion = isPro
        ? propsContent.Root?.Element("PropertyGroup")?.Element("ProVersion")?.Value
        : propsContent.Root?.Element("PropertyGroup")?.Element("CoreVersion")?.Value;

    if (string.IsNullOrEmpty(currentVersion))
    {
        throw new Exception($"Could not read {(isPro ? "Pro" : "Core")}Version from Directory.Build.props");
    }

    // Parse version: major.minor.patch.build-beta-betaVersion
    Match match = Regex.Match(currentVersion, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?-?(beta)?-?(\d*)?");

    if (!match.Success)
    {
        throw new Exception($"Could not parse version: {currentVersion}");
    }

    int majorVersion = int.Parse(match.Groups[1].Value);
    int minorVersion = int.Parse(match.Groups[2].Value);
    int patchVersion = int.Parse(match.Groups[3].Value);

    int buildVersion = match.Groups[4].Success && !string.IsNullOrEmpty(match.Groups[4].Value)
        ? int.Parse(match.Groups[4].Value)
        : 0;
    bool isBeta = match.Groups[5].Success && !string.IsNullOrEmpty(match.Groups[5].Value);

    int betaVersion = match.Groups[6].Success && !string.IsNullOrEmpty(match.Groups[6].Value)
        ? int.Parse(match.Groups[6].Value)
        : 0;

    string newVersion;

    if (publish)
    {
        if (isBeta)
        {
            throw new Exception(
                "Cannot publish a beta version. Please update the version in Directory.Build.props to a release version.");
        }

        // Check the latest version on NuGet.org
        string packageName = isPro ? "dymaptic.geoblazor.pro" : "dymaptic.geoblazor.core";
        string nugetUrl = $"https://azuresearch-usnc.nuget.org/query?q={packageName}&prerelease=false";

        using HttpClient httpClient = new();
        string response = await httpClient.GetStringAsync(nugetUrl);
        using JsonDocument doc = JsonDocument.Parse(response);

        string? latestVersion = null;

        if (doc.RootElement.TryGetProperty("data", out JsonElement data) && (data.GetArrayLength() > 0))
        {
            // Find the highest version
            latestVersion = data.EnumerateArray()
                .Select(d => d.GetProperty("version").GetString())
                .Where(v => v != null)
                .OrderByDescending(v =>
                    Version.TryParse(v!.Split('-')[0], out Version? ver) ? ver : new Version(0, 0, 0))
                .FirstOrDefault();
        }

        if (string.IsNullOrEmpty(latestVersion))
        {
            throw new Exception("Could not determine latest version from NuGet API.");
        }

        Match nugetMatch = Regex.Match(latestVersion, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?(-beta-)?(\d*)?");
        int nugetMajor = int.Parse(nugetMatch.Groups[1].Value);
        int nugetMinor = int.Parse(nugetMatch.Groups[2].Value);
        int nugetPatch = int.Parse(nugetMatch.Groups[3].Value);

        if ((nugetMajor > majorVersion) ||
            ((nugetMajor == majorVersion) && (nugetMinor > minorVersion)) ||
            ((nugetMajor == majorVersion) && (nugetMinor == minorVersion) && (nugetPatch > patchVersion)))
        {
            throw new Exception(
                "Version in NuGet is greater than local version. Please update the version in Directory.Build.props to match the latest version on Nuget.org.");
        }

        if ((nugetMajor == majorVersion) && (nugetMinor == minorVersion) && (nugetPatch == patchVersion))
        {
            // Increment the patch version for release
            newVersion = $"{majorVersion}.{minorVersion}.{patchVersion + 1}";
        }
        else
        {
            // Version is already higher than NuGet, just remove build number
            newVersion = $"{majorVersion}.{minorVersion}.{patchVersion}";
        }
    }
    else
    {
        // For non-release builds, increment the build number
        if (isBeta)
        {
            newVersion = $"{majorVersion}.{minorVersion}.{patchVersion}.{buildVersion}-beta-{betaVersion + 1}";
        }
        else
        {
            newVersion = $"{majorVersion}.{minorVersion}.{patchVersion}.{buildVersion + 1}";
        }
    }

    return newVersion;
}

/// <summary>
/// Reads the current version element from a Directory.Build.props file without modifying it.
/// </summary>
static string ReadCurrentVersion(string propsPath, string elementName)
{
    XDocument props = XDocument.Load(propsPath);

    return props.Root?.Element("PropertyGroup")?.Element(elementName)?.Value ?? "";
}

/// <summary>
/// Compares two semantic version strings.
/// </summary>
/// <param name="version1">The first version string (e.g., "4.33.1.5").</param>
/// <param name="version2">The second version string.</param>
/// <returns>
/// Less than 0 if version1 is less than version2;
/// 0 if they are equal;
/// Greater than 0 if version1 is greater than version2.
/// </returns>
static int CompareVersions(string version1, string version2)
{
    // Simple version comparison - extract numeric parts
    Match v1Match = Regex.Match(version1, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?");
    Match v2Match = Regex.Match(version2, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?");

    if (!v1Match.Success || !v2Match.Success)
    {
        return string.Compare(version1, version2, StringComparison.Ordinal);
    }

    int major1 = int.Parse(v1Match.Groups[1].Value);
    int minor1 = int.Parse(v1Match.Groups[2].Value);
    int patch1 = int.Parse(v1Match.Groups[3].Value);

    int build1 = v1Match.Groups[4].Success && !string.IsNullOrEmpty(v1Match.Groups[4].Value)
        ? int.Parse(v1Match.Groups[4].Value)
        : 0;

    int major2 = int.Parse(v2Match.Groups[1].Value);
    int minor2 = int.Parse(v2Match.Groups[2].Value);
    int patch2 = int.Parse(v2Match.Groups[3].Value);

    int build2 = v2Match.Groups[4].Success && !string.IsNullOrEmpty(v2Match.Groups[4].Value)
        ? int.Parse(v2Match.Groups[4].Value)
        : 0;

    if (major1 != major2)
    {
        return major1.CompareTo(major2);
    }

    if (minor1 != minor2)
    {
        return minor1.CompareTo(minor2);
    }

    if (patch1 != patch2)
    {
        return patch1.CompareTo(patch2);
    }

    return build1.CompareTo(build2);
}