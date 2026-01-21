#!/usr/bin/env dotnet

// GeoBlazorBuild - Primary build script for GeoBlazor and GeoBlazor Pro
// Usage: dotnet GeoBlazorBuild.dll [options] or ./GeoBlazorBuild.exe [options]
//   -pro                               Build GeoBlazor Pro as well as Core (default is false)
//   -pub, --publish-version            Truncate the build version to 3 digits for NuGet (default is false)
//   -obf, --obfuscate                  Obfuscate the Pro license validation logic (default is false)
//   -docs, --generate-docs             Generate documentation files for the docs site (default is false)
//   -xml, --generate-xml               Generate the XML comments for intellisense (default is false)
//   -pkg, --package                    Create NuGet packages (default is false)
//   -bl, --binlog                      Generate MSBuild binary log files (default is false)
//   -v, --version <string>             Specify a custom version number, or "current" (default is to auto-increment)
//   -c, --configuration <string>       Build configuration (default is 'Release')
//   -vc, --validator-config <string>   Validator build configuration (default is 'Release')
//   -su, --server-url <string>         License server URL (default is 'https://licensing.dymaptic.com')
//   -retries <int>                     Number of times to retry the build on failure (default is 5)
//   -h, --help                         Display this help message

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

// Paths
// Get the script cs file path, that way we can run this script from either the CS file or the Executable
string scriptsDir = GetScriptsDirectory();
string toolsDir = Path.GetFullPath(Path.Combine(scriptsDir, "..", "build-tools"));
// Build folder is at GeoBlazor/build/, Core root is GeoBlazor/
string coreRepoRoot = Path.GetFullPath(Path.Combine(toolsDir, ".."));
string proRepoRoot = Path.GetFullPath(Path.Combine(coreRepoRoot, ".."));

string corePropsPath = Path.Combine(coreRepoRoot, "Directory.Build.props");
string coreProjectPath = Path.Combine(coreRepoRoot, "src", "dymaptic.GeoBlazor.Core");
string proPropsPath = Path.Combine(proRepoRoot, "Directory.Build.props");
string proProjectPath = Path.Combine(proRepoRoot, "src", "dymaptic.GeoBlazor.Pro");
string validatorProjectPath = Path.Combine(proRepoRoot, "src", "dymaptic.GeoBlazor.Pro.Validator");

DateTime scriptStartTime = DateTime.Now;

// Parse command line arguments
bool pro = false;
bool publishVersion = false;
bool obfuscate = false;
bool generateDocs = false;
bool generateXmlComments = false;
bool package = false;
bool binlog = false;
bool help = false;
string? customVersion = null;
string configuration = "Release";
string validatorConfig = "Release";
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
        case "-v":
        case "--version":
            if (i + 1 < args.Length)
            {
                string version = args[++i];
                if (version.Trim('"') == "current")
                {
                    XDocument coreProps = XDocument.Load(corePropsPath);
                    string? currentCoreVersion = coreProps.Root?.Element("PropertyGroup")?.Element("CoreVersion")?.Value;
                    customVersion = currentCoreVersion;
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
            if (i + 1 < args.Length && int.TryParse(args[++i], out int retries))
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
    Console.WriteLine("  -pub, --publish-version            Truncate the build version to 3 digits for NuGet (default is false)");
    Console.WriteLine("  -obf, --obfuscate                  Obfuscate the Pro license validation logic (default is false)");
    Console.WriteLine("  -docs, --generate-docs             Generate documentation files for the docs site (default is false)");
    Console.WriteLine("  -xml, --generate-xml               Generate the XML comments for intellisense (default is false)");
    Console.WriteLine("  -pkg, --package                    Create NuGet packages (default is false)");
    Console.WriteLine("  -bl, --binlog                      Generate MSBuild binary log files (default is false)");
    Console.WriteLine("  -v, --version <string>             Specify a custom version number (default is to auto-increment)");
    Console.WriteLine("  -c, --configuration <string>       Build configuration (default is 'Release')");
    Console.WriteLine("  -vc, --validator-config <string>   Validator build configuration (default is 'Release')");
    Console.WriteLine("  -su, --server-url <string>         License server URL (default is 'https://licensing.dymaptic.com')");
    Console.WriteLine("  -retries <int>                     Number of times to retry the build on failure (default is 5)");
    Console.WriteLine("  -h, --help                         Display this help message");
    return 0;
}

// If generating docs, also generate XML comments
if (generateDocs)
{
    generateXmlComments = true;
}

Console.WriteLine("Starting GeoBlazor Build Script");
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

string binlogFlag = binlog ? "-bl" : "";

int step = 1;
DateTime stepStartTime = DateTime.Now;

// Step 1: ensure other build scripts are up to date:
WriteStepHeader(step, "Updating build scripts to latest versions...");
Console.WriteLine($"Running {scriptsDir}/ScriptBuilder.cs to update build scripts in {toolsDir}");
await RunDotnetCommandWithOutputAsync(scriptsDir, "run", "ScriptBuilder.cs", "--exclude", "GeoBlazorBuild.cs");
WriteStepCompleted(step, stepStartTime);
step++;

string otherConfiguration = configuration.Equals("Release", StringComparison.OrdinalIgnoreCase) ? "Debug" : "Release";

// Lock file paths
string coreLockFilePath = Path.Combine(coreProjectPath, $"esBuild.{otherConfiguration}.lock");
string proLockFilePath = Path.Combine(proProjectPath, $"esProBuild.{otherConfiguration}.lock");

// Check for existing locks from other configuration
if (File.Exists(coreLockFilePath) || File.Exists(proLockFilePath))
{
    Console.WriteLine("Another instance of the esBuild scripts are already running, please wait.");
    while (File.Exists(coreLockFilePath) || File.Exists(proLockFilePath))
    {
        Thread.Sleep(1000);
        Console.Write(".");
        if (scriptStartTime.AddMinutes(1) < DateTime.Now)
        {
            if (File.Exists(coreLockFilePath))
            {
                Console.WriteLine($"\nLock file {coreLockFilePath} still exists after 1 minute, removing stale lock.");
                File.Delete(coreLockFilePath);
            }
            if (File.Exists(proLockFilePath))
            {
                Console.WriteLine($"\nLock file {proLockFilePath} still exists after 1 minute, removing stale lock.");
                File.Delete(proLockFilePath);
            }
        }
    }
    Console.WriteLine("Lock released, continuing...");
}

// Create lock files for current configuration
string currentCoreLockFilePath = Path.Combine(coreProjectPath, $"esBuild.{configuration}.lock");
string currentProLockFilePath = Path.Combine(proProjectPath, $"esProBuild.{configuration}.lock");

try
{
    // Set environment variable
    Environment.SetEnvironmentVariable("PipelineBuild", "true");

    string version = customVersion ?? "";
    bool customVersionSet = !string.IsNullOrEmpty(customVersion);

    // Step 2: Clean old build artifacts
    stepStartTime = DateTime.Now;
    WriteStepHeader(step, "Cleaning old build artifacts");

    await RunDotnetCommand(coreProjectPath, "clean", 
        $"\"{Path.Combine(coreProjectPath, "dymaptic.GeoBlazor.Core.csproj")}\"", "/p:PipelineBuild=true");
    DeleteDirectoryIfExists(Path.Combine(coreProjectPath, "bin"));
    DeleteDirectoryIfExists(Path.Combine(coreProjectPath, "obj"));
    DeleteDirectoryContentsIfExists(Path.Combine(coreProjectPath, "wwwroot", "js"));
    DeleteDirectoryIfExists(Path.Combine(coreProjectPath, "node_modules"), usePowerShell: true);

    if (pro)
    {
        await RunDotnetCommand(proProjectPath, "clean", 
            $"\"{Path.Combine(proProjectPath, "dymaptic.GeoBlazor.Pro.csproj")}\"", "/p:PipelineBuild=true");
        DeleteDirectoryIfExists(Path.Combine(proProjectPath, "bin"));
        DeleteDirectoryIfExists(Path.Combine(proProjectPath, "obj"));
        DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "obf"));
        DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "build", "resources"));
        DeleteDirectoryContentsIfExists(Path.Combine(proProjectPath, "wwwroot", "js"));
        DeleteDirectoryIfExists(Path.Combine(proProjectPath, "node_modules"), usePowerShell: true);

        if (Directory.Exists(validatorProjectPath))
        {
            await RunDotnetCommand(validatorProjectPath, "clean", 
                $"\"{Path.Combine(validatorProjectPath, "dymaptic.GeoBlazor.Pro.V.csproj")}\"");
            DeleteDirectoryIfExists(Path.Combine(validatorProjectPath, "bin"));
            DeleteDirectoryIfExists(Path.Combine(validatorProjectPath, "obj"));
            DeleteDirectoryContentsIfExists(Path.Combine(validatorProjectPath, "obf"));
        }
    }
    WriteStepCompleted(step, stepStartTime);
    step++;

    // Step 3: Update library versions (if no custom version specified)
    if (!customVersionSet)
    {
        stepStartTime = DateTime.Now;
        WriteStepHeader(step, "Updating Library Versions");

        XDocument coreProps = XDocument.Load(corePropsPath);
        string? currentCoreVersion = coreProps.Root?.Element("PropertyGroup")?.Element("CoreVersion")?.Value;

        string newCoreVersion = await BumpVersionAsync(coreRepoRoot, publishVersion, false);

        if (pro)
        {
            XDocument proProps = XDocument.Load(proPropsPath);
            string? currentProVersion = proProps.Root?.Element("PropertyGroup")?.Element("ProVersion")?.Value;

            version = await BumpVersionAsync(proRepoRoot, publishVersion, true);

            // Compare versions and use the higher one
            if (CompareVersions(newCoreVersion, version) > 0 &&
                CompareVersions(currentCoreVersion ?? "0.0.0", currentProVersion ?? "0.0.0") > 0)
            {
                version = newCoreVersion;
            }
            else if (CompareVersions(newCoreVersion, version) < 0)
            {
                Console.WriteLine($"Core version ({newCoreVersion}) and Pro version ({version}) do not match after bumping. Please ensure both versions are the same in Directory.Build.props.");
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

        WriteStepCompleted(step, stepStartTime);
        step++;
    }

    // Check for another lock for the current configuration
    if (File.Exists(currentCoreLockFilePath) &&
        File.GetLastWriteTimeUtc(currentCoreLockFilePath) < DateTime.UtcNow.AddSeconds(-5))
    {
        Console.WriteLine("Another instance of the esBuild script is already running, please wait.");
        while (File.Exists(currentCoreLockFilePath))
        {
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Console.WriteLine("Lock released, continuing...");
    }

    // Step 4: Build Core JavaScript
    stepStartTime = DateTime.Now;
    WriteStepHeader(step, "Building Core JavaScript");

    int esBuildResult = await RunDotnetScriptAsync(toolsDir, "ESBuild.dll", $"-c {configuration}");
    if (esBuildResult != 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: ESBuild.dll failed with exit code {esBuildResult}. Exiting.");
        Console.ResetColor();
        return 1;
    }

    // Verify JavaScript files were created
    string coreJsPath = Path.Combine(coreProjectPath, "wwwroot", "js");
    if (!Directory.Exists(coreJsPath) || Directory.GetFiles(coreJsPath, "*.js").Length == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"WARNING: Core JavaScript files not found at {coreJsPath}, waiting...");
        Console.ResetColor();
        Thread.Sleep(2000);
        if (!Directory.Exists(coreJsPath) || Directory.GetFiles(coreJsPath, "*.js").Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Core JavaScript files still not found after waiting. Exiting.");
            Console.ResetColor();
            return 1;
        }
    }

    WriteStepCompleted(step, stepStartTime);
    step++;

    // Step 5: Restore .NET packages for Core
    stepStartTime = DateTime.Now;
    WriteStepHeader(step, "Restoring .NET Packages");

    await RunDotnetCommand(coreProjectPath, "restore", "/p:PipelineBuild=true");

    WriteStepCompleted(step, stepStartTime);
    step++;

    // Step 6: Build Core Project and NuGet Package
    stepStartTime = DateTime.Now;
    WriteStepHeader(step, "Building Core Project and NuGet Package");

    string[] coreBuildArgs = 
    [
        $"dymaptic.GeoBlazor.Core.csproj", 
        $"--no-restore",
        "-c",
        configuration,
        $"/p:PipelineBuild=true",
        $"/p:GenerateDocs={generateDocs.ToString().ToLower()}",
        $"/p:GenerateXmlComments={generateXmlComments.ToString().ToLower()}",
        $"/p:CoreVersion={version}",
        $"/p:GeneratePackage={package.ToString().ToLower()}",
        binlogFlag
    ];

    Console.WriteLine($"Executing 'dotnet build {string.Join(" ", coreBuildArgs)}'");

    bool coreHasError = false;
    for (int i = 1; i <= buildRetries; i++)
    {
        try
        {
            (int exitCode, List<string> output) = await RunDotnetCommandWithOutputAsync(coreProjectPath, "build", coreBuildArgs);

            if (exitCode != 0)
            {
                Console.WriteLine($"ERROR: Core Build command failed with exit code {exitCode}. Exiting.");
                coreHasError = true;
            }
            else
            {
                coreHasError = output.Any(line =>
                    Regex.IsMatch(line, @"[1-9][0-9]* [Ee]rror(s)?") ||
                    line.Contains("Build FAILED"));
                if (!coreHasError)
                {
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            coreHasError = true;
            Console.WriteLine($"Build attempt {i} of {buildRetries} failed with exception: {ex.Message}");
        }

        Console.WriteLine($"Build attempt {i} of {buildRetries} failed.");
        if (i < buildRetries)
        {
            Console.WriteLine("Waiting 2 seconds before retrying...");
            Thread.Sleep(2000);
        }
    }

    if (coreHasError)
    {
        return 1;
    }

    if (package)
    {
        // Copy generated NuGet package to repo root
        string coreBinPath = Path.Combine(coreProjectPath, "bin", configuration);
        if (Directory.Exists(coreBinPath))
        {
            var coreNupkg = Directory.GetFiles(coreBinPath, "*.nupkg", SearchOption.AllDirectories)
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();
            if (coreNupkg != null)
            {
                File.Copy(coreNupkg.FullName, Path.Combine(coreRepoRoot, coreNupkg.Name), true);
                Console.WriteLine($"Copied {coreNupkg.Name} to {coreRepoRoot}");
            }
        }
    }

    WriteStepCompleted(step, stepStartTime);
    step++;

    // Pro-specific steps
    if (pro)
    {
        // Step 7: Restore Pro .NET packages
        stepStartTime = DateTime.Now;
        WriteStepHeader(step, "Restoring .NET Packages");

        await RunDotnetCommand(proProjectPath, "restore", "/p:PipelineBuild=true");

        WriteStepCompleted(step, stepStartTime);
        step++;

        bool optOutFromObfuscation = !obfuscate;

        // Step 8: Build Validator (if exists)
        if (Directory.Exists(validatorProjectPath))
        {
            stepStartTime = DateTime.Now;
            WriteStepHeader(step, $"Building Validator project in configuration {validatorConfig}");

            // Set the ServerUrls in the Validator project
            serverUrl = serverUrl.TrimEnd('/');
            Console.WriteLine($"Setting License Server Url to {serverUrl}");

            string devBuildValidatorPath = Path.Combine(validatorProjectPath, "DevBuildValidator.cs");
            string publishTaskValidatorPath = Path.Combine(validatorProjectPath, "PublishTaskValidator.cs");

            // Update DevBuildValidator.cs
            string devValidatorContent = File.ReadAllText(devBuildValidatorPath);
            devValidatorContent = Regex.Replace(
                devValidatorContent,
                @"public string SU \{ get; set; \} = null!;",
                $"public string SU {{ get; set; }} = \"{serverUrl}/api/validate/v4\";");
            File.WriteAllText(devBuildValidatorPath, devValidatorContent);
            Thread.Sleep(500);

            // Verify the update
            devValidatorContent = File.ReadAllText(devBuildValidatorPath);
            if (!devValidatorContent.Contains($"public string SU {{ get; set; }} = \"{serverUrl}/api/validate/v4\";"))
            {
                throw new Exception("Failed to set ServerUrl in DevBuildValidator.cs");
            }

            // Update PublishTaskValidator.cs
            string publishValidatorContent = File.ReadAllText(publishTaskValidatorPath);
            publishValidatorContent = Regex.Replace(
                publishValidatorContent,
                @"public string SU \{ get; set; \} = null!;",
                $"public string SU {{ get; set; }} = \"{serverUrl}/api/validate/v4/publish\";");
            File.WriteAllText(publishTaskValidatorPath, publishValidatorContent);
            Thread.Sleep(500);

            // Verify the update
            publishValidatorContent = File.ReadAllText(publishTaskValidatorPath);
            if (!publishValidatorContent.Contains($"public string SU {{ get; set; }} = \"{serverUrl}/api/validate/v4/publish\";"))
            {
                throw new Exception("Failed to set ServerUrl in PublishTaskValidator.cs");
            }

            // Build validator
            string[] validatorBuildArgs =
            [
                "dymaptic.GeoBlazor.Pro.V.csproj",
                $"/p:OptOutFromObfuscation={optOutFromObfuscation.ToString().ToLower()}",
                $"/p:ProVersion={version}",
                "-c",
                validatorConfig,
                binlogFlag
            ];

            (int validatorExitCode, List<string> validatorOutput) = await RunDotnetCommandWithOutputAsync(validatorProjectPath, "build", validatorBuildArgs);

            // Restore the ServerUrls in the Validator project
            devValidatorContent = File.ReadAllText(devBuildValidatorPath);
            devValidatorContent = Regex.Replace(
                devValidatorContent,
                @"public string SU \{ get; set; \} = "".*"";",
                "public string SU { get; set; } = null!;");
            File.WriteAllText(devBuildValidatorPath, devValidatorContent);

            publishValidatorContent = File.ReadAllText(publishTaskValidatorPath);
            publishValidatorContent = Regex.Replace(
                publishValidatorContent,
                @"public string SU \{ get; set; \} = "".*"";",
                "public string SU { get; set; } = null!;");
            File.WriteAllText(publishTaskValidatorPath, publishValidatorContent);

            bool validatorHasError = validatorOutput.Any(line =>
                Regex.IsMatch(line, @"[1-9][0-9]* [Ee]rror(s)?") ||
                line.Contains("Build FAILED"));
            if (validatorHasError)
            {
                return 1;
            }

            WriteStepCompleted(step, stepStartTime);
            step++;
        }

        // Check for Pro lock
        if (File.Exists(currentProLockFilePath) &&
            File.GetLastWriteTimeUtc(currentProLockFilePath) < DateTime.UtcNow.AddSeconds(-5))
        {
            Console.WriteLine("Another instance of the esBuild scripts are already running, please wait.");
            while (File.Exists(currentProLockFilePath))
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("Lock released, continuing...");
        }

        // Step 9: Build Pro JavaScript
        stepStartTime = DateTime.Now;
        WriteStepHeader(step, "Building Pro JavaScript");

        int esProBuildResult = await RunDotnetScriptAsync(toolsDir, "ESBuild.dll", $"-c {configuration} --pro");
        if (esProBuildResult != 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: esProBuild failed with exit code {esProBuildResult}. Exiting.");
            Console.ResetColor();
            return 1;
        }

        // Verify Pro JavaScript files were created
        string proJsPath = Path.Combine(proProjectPath, "wwwroot", "js");
        if (!Directory.Exists(proJsPath) || Directory.GetFiles(proJsPath, "*.js").Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"WARNING: Pro JavaScript files not found at {proJsPath}, waiting...");
            Console.ResetColor();
            Thread.Sleep(2000);
            if (!Directory.Exists(proJsPath) || Directory.GetFiles(proJsPath, "*.js").Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Pro JavaScript files still not found after waiting. Exiting.");
                Console.ResetColor();
                return 1;
            }
        }

        WriteStepCompleted(step, stepStartTime);
        step++;

        // Step 10: Build Pro project and package
        stepStartTime = DateTime.Now;
        WriteStepHeader(step, "Building Pro project and package");

        string[] proBuildArgs =
        [
            $"dymaptic.GeoBlazor.Pro.csproj",
            "--no-restore",
            $"-c",
            configuration,
            $"/p:PipelineBuild=true",
            $"/p:GenerateDocs={generateDocs.ToString().ToLower()}",
            $"/p:GenerateXmlComments={generateXmlComments.ToString().ToLower()}",
            $"/p:CoreVersion={version}",
            $"/p:ProVersion={version}",
            $"/p:OptOutFromObfuscation={optOutFromObfuscation.ToString().ToLower()}",
            $"/p:GeneratePackage={package.ToString().ToLower()}",
            binlogFlag
        ];

        Console.WriteLine($"Executing 'dotnet {string.Join(" ", proBuildArgs)}'");

        bool proHasError = false;
        for (int i = 1; i <= buildRetries; i++)
        {
            try
            {
                (int exitCode, List<string> output) = await RunDotnetCommandWithOutputAsync(proProjectPath, "build", proBuildArgs);

                if (exitCode != 0)
                {
                    Console.WriteLine($"ERROR: Pro Build command failed with exit code {exitCode}. Exiting.");
                    proHasError = true;
                }
                else
                {
                    proHasError = output.Any(line =>
                        Regex.IsMatch(line, @"[1-9][0-9]* [Ee]rror(s)?") ||
                        line.Contains("Build FAILED"));
                    if (!proHasError)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                proHasError = true;
                Console.WriteLine($"Build attempt {i} of {buildRetries} failed with exception: {ex.Message}");
            }

            Console.WriteLine($"Build attempt {i} of {buildRetries} failed.");
            if (i < buildRetries)
            {
                Console.WriteLine("Waiting 2 seconds before retrying...");
                Thread.Sleep(2000);
            }
        }

        if (proHasError)
        {
            return 1;
        }

        if (package)
        {
            // Copy generated NuGet package to Core repo root
            string proBinPath = Path.Combine(proProjectPath, "bin", configuration);
            if (Directory.Exists(proBinPath))
            {
                var proNupkg = Directory.GetFiles(proBinPath, "*.nupkg", SearchOption.AllDirectories)
                    .Select(f => new FileInfo(f))
                    .OrderByDescending(f => f.LastWriteTime)
                    .FirstOrDefault();
                if (proNupkg != null)
                {
                    File.Copy(proNupkg.FullName, Path.Combine(coreRepoRoot, proNupkg.Name), true);
                    Console.WriteLine($"Copied {proNupkg.Name} to {coreRepoRoot}");
                }
            }
        }

        WriteStepCompleted(step, stepStartTime);
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

    // Remove lock files
    if (File.Exists(currentCoreLockFilePath))
    {
        File.Delete(currentCoreLockFilePath);
    }
    if (File.Exists(currentProLockFilePath))
    {
        File.Delete(currentProLockFilePath);
    }

    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"Total script execution time: {totalTime}.");
    Console.ResetColor();
    Console.WriteLine();
}

// Helper methods

static string GetScriptsDirectory([CallerFilePath] string? callerFilePath = null)
{
    // When running as a pre-compiled DLL, [CallerFilePath] contains the compile-time path
    // which is invalid at runtime (especially in Docker containers).
    // Detect this by checking if the file exists at the caller path.
    if (!string.IsNullOrEmpty(callerFilePath) && File.Exists(callerFilePath))
    {
        return Path.GetDirectoryName(callerFilePath)!;
    }

    // Running as a DLL - use AppContext.BaseDirectory which points to the DLL location
    // The DLL is in build-tools/, and scripts are in build-scripts/ (sibling directory)
    string dllDirectory = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
    return Path.Combine(Path.GetDirectoryName(dllDirectory)!, "build-scripts");
}

static void WriteStepHeader(int step, string description)
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.DarkMagenta;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"{step}. {description}");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine();
}

static void WriteStepCompleted(int step, DateTime stepStartTime)
{
    TimeSpan elapsed = DateTime.Now - stepStartTime;
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write($"Step {step} completed in {elapsed}.");
    Console.ResetColor();
    Console.WriteLine();
}

static void DeleteDirectoryIfExists(string path, bool usePowerShell = false)
{
    if (!Directory.Exists(path))
    {
        return;
    }

    try
    {
        if (usePowerShell)
        {
            // Use PowerShell 7 for cross-platform deletion - handles long paths on Windows
            string escapedPath = path.Replace("'", "''");
            var psi = new ProcessStartInfo
            {
                FileName = "pwsh",
                Arguments = $"-NoProfile -Command \"Remove-Item -LiteralPath '{escapedPath}' -Recurse -Force -ErrorAction Stop\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true
            };
            using var process = Process.Start(psi);
            process?.WaitForExit(60000); // 60 second timeout for large node_modules

            // Verify deletion
            if (Directory.Exists(path))
            {
                Console.WriteLine($"WARNING: Failed to delete {path} with PowerShell, trying .NET fallback...");
                Directory.Delete(path, true);
            }
        }
        else
        {
            Directory.Delete(path, true);
        }

        // Verify and wait for filesystem to settle
        int retries = 10;
        while (Directory.Exists(path) && retries > 0)
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

static async Task RunDotnetCommand(string workingDirectory, string command, params string[] args)
{
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}",
        WorkingDirectory = workingDirectory,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using var process = Process.Start(psi);
    if (process != null)
    {
        await process.WaitForExitAsync();
    }
}

static async Task<(int ExitCode, List<string> Output)> RunDotnetCommandWithOutputAsync(string workingDirectory,
    string command, params string[] args)
{
    var output = new List<string>();

    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"{command} {string.Join(" ", args.Where(a => !string.IsNullOrWhiteSpace(a)))}",
        WorkingDirectory = workingDirectory,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using var process = Process.Start(psi);
    if (process == null)
    {
        return (1, ["Failed to start dotnet"]);
    }

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
            output.Add(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
            output.Add(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return (process.ExitCode, output);
}

static async Task<int> RunDotnetScriptAsync(string workingDirectory, string scriptName, string args)
{
    var psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = $"{scriptName} {args}",
        WorkingDirectory = workingDirectory,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using var process = Process.Start(psi);
    if (process == null)
    {
        return 1;
    }

    process.OutputDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (_, e) =>
    {
        if (e.Data != null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync();

    return process.ExitCode;
}

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
    var match = Regex.Match(currentVersion, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?-?(beta)?-?(\d*)?");
    if (!match.Success)
    {
        throw new Exception($"Could not parse version: {currentVersion}");
    }

    int majorVersion = int.Parse(match.Groups[1].Value);
    int minorVersion = int.Parse(match.Groups[2].Value);
    int patchVersion = int.Parse(match.Groups[3].Value);
    int buildVersion = match.Groups[4].Success && !string.IsNullOrEmpty(match.Groups[4].Value)
        ? int.Parse(match.Groups[4].Value) : 0;
    bool isBeta = match.Groups[5].Success && !string.IsNullOrEmpty(match.Groups[5].Value);
    int betaVersion = match.Groups[6].Success && !string.IsNullOrEmpty(match.Groups[6].Value)
        ? int.Parse(match.Groups[6].Value) : 0;

    string newVersion;

    if (publish)
    {
        if (isBeta)
        {
            throw new Exception("Cannot publish a beta version. Please update the version in Directory.Build.props to a release version.");
        }

        // Check the latest version on NuGet.org
        string packageName = isPro ? "dymaptic.geoblazor.pro" : "dymaptic.geoblazor.core";
        string nugetUrl = $"https://azuresearch-usnc.nuget.org/query?q={packageName}&prerelease=false";

        using var httpClient = new HttpClient();
        string response = await httpClient.GetStringAsync(nugetUrl);
        using var doc = JsonDocument.Parse(response);

        string? latestVersion = null;
        if (doc.RootElement.TryGetProperty("data", out var data) && data.GetArrayLength() > 0)
        {
            // Find the highest version
            latestVersion = data.EnumerateArray()
                .Select(d => d.GetProperty("version").GetString())
                .Where(v => v != null)
                .OrderByDescending(v => Version.TryParse(v!.Split('-')[0], out var ver) ? ver : new Version(0, 0, 0))
                .FirstOrDefault();
        }

        if (string.IsNullOrEmpty(latestVersion))
        {
            throw new Exception("Could not determine latest version from NuGet API.");
        }

        var nugetMatch = Regex.Match(latestVersion, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?(-beta-)?(\d*)?");
        int nugetMajor = int.Parse(nugetMatch.Groups[1].Value);
        int nugetMinor = int.Parse(nugetMatch.Groups[2].Value);
        int nugetPatch = int.Parse(nugetMatch.Groups[3].Value);

        if (nugetMajor > majorVersion ||
            (nugetMajor == majorVersion && nugetMinor > minorVersion) ||
            (nugetMajor == majorVersion && nugetMinor == minorVersion && nugetPatch > patchVersion))
        {
            throw new Exception("Version in NuGet is greater than local version. Please update the version in Directory.Build.props to match the latest version on Nuget.org.");
        }

        if (nugetMajor == majorVersion && nugetMinor == minorVersion && nugetPatch == patchVersion)
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

static int CompareVersions(string version1, string version2)
{
    // Simple version comparison - extract numeric parts
    var v1Match = Regex.Match(version1, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?");
    var v2Match = Regex.Match(version2, @"(\d+)\.(\d+)\.(\d+)\.?(\d*)?");

    if (!v1Match.Success || !v2Match.Success)
    {
        return string.Compare(version1, version2, StringComparison.Ordinal);
    }

    int major1 = int.Parse(v1Match.Groups[1].Value);
    int minor1 = int.Parse(v1Match.Groups[2].Value);
    int patch1 = int.Parse(v1Match.Groups[3].Value);
    int build1 = v1Match.Groups[4].Success && !string.IsNullOrEmpty(v1Match.Groups[4].Value)
        ? int.Parse(v1Match.Groups[4].Value) : 0;

    int major2 = int.Parse(v2Match.Groups[1].Value);
    int minor2 = int.Parse(v2Match.Groups[2].Value);
    int patch2 = int.Parse(v2Match.Groups[3].Value);
    int build2 = v2Match.Groups[4].Success && !string.IsNullOrEmpty(v2Match.Groups[4].Value)
        ? int.Parse(v2Match.Groups[4].Value) : 0;

    if (major1 != major2) return major1.CompareTo(major2);
    if (minor1 != minor2) return minor1.CompareTo(minor2);
    if (patch1 != patch2) return patch1.CompareTo(patch2);
    return build1.CompareTo(build2);
}
