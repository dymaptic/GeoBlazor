#!/usr/bin/env dotnet

// Script Builder - Compiles C# build scripts to DLLs
// ====================================================
// Builds all C# file-based apps in the build-scripts directory using 'dotnet build'.
// Outputs compiled DLLs to the ../build-tools/ directory for faster execution.
//
// This tool is used to pre-compile the build scripts so they can be run as DLLs
// rather than interpreted C# files, significantly improving startup time.
//
// Usage:
//   dotnet ScriptBuilder.cs                              Build all scripts
//   dotnet ScriptBuilder.cs Script1.cs Script2.cs        Build only specified scripts
//   dotnet ScriptBuilder.cs --exclude Script1.cs         Build all except specified scripts
//
// Options:
//   --exclude       When specified, the listed scripts will be skipped instead of included
//   --force, -f     Force rebuild of all scripts regardless of changes
//   --clean, -c     Clean before building
//   --linux, -l     Build for Linux platform
//   --mac,   -m     Build for macOS platform
//   --win,   -w     Build for Windows platform
//   --allPlatforms  Build for all platforms
//   --help, -h      Show this help message
//
// Output:
//   Compiled DLLs are placed in GeoBlazor/build-tools/ directory
//
// Note: ScriptBuilder.cs itself is always skipped to avoid self-compilation issues.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

bool excludeMode = false;
HashSet<string> scriptsToProcess = new();
string coreScriptsDir = GetCoreScriptsDirectory();
string coreDir = Path.GetFullPath(Path.Combine(coreScriptsDir, "..", ".."));
string proDir = Path.GetFullPath(Path.Combine(coreDir, ".."));
string proScriptsDir = Path.GetFullPath(Path.Combine(proDir, "build-tools", "build-scripts"));

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.WriteLine("Starting ScriptBuilder...");
Trace.WriteLine($"Core scripts directory: {coreScriptsDir}");
Trace.WriteLine($"Pro scripts directory: {proScriptsDir}");

string[] coreScripts = Directory.GetFiles(coreScriptsDir, "*.cs");
string[] proScripts = Directory.Exists(proScriptsDir) ? Directory.GetFiles(proScriptsDir, "*.cs") : [];

bool force = false;
bool cleanBeforeBuild = false;
bool allPlatforms = false;
string os = OperatingSystem.IsWindows()
    ? "win" 
    : OperatingSystem.IsMacOS()
        ? "osx" 
        : "linux";
string arch = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();
string runtime = $"{os}-{arch}";

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i];

    switch (arg.ToLowerInvariant())
    {
        case "--clean":
        case "-c":
            cleanBeforeBuild = true;
            break;
        case "--exclude":
            excludeMode = true;
            break;
        case "--force":
        case "-f":
            force = true;
            break;
        case "--linux":
        case "-l":
            runtime = "linux-x64";
            break;
        case "--mac":
        case "-m":
            runtime = "osx-arm64";
            break;
        case "--win":
        case "-w":
            runtime = "win-x64";
            break;
        case "--allplatforms":
            allPlatforms = true;
            break;
        case "--help":
        case "-h":
            Console.WriteLine("Usage: dotnet ScriptBuilder.cs [options] [script1.cs script2.cs ...]");
            Console.WriteLine("Options:");
            Console.WriteLine("  --exclude        Exclude listed scripts instead of including them");
            Console.WriteLine("  --force, -f      Force rebuild of all scripts");
            Console.WriteLine("  --clean, -c      Clean before building");
            Console.WriteLine("  --linux, -l      Build for Linux platform");
            Console.WriteLine("  --mac,   -m      Build for macOS platform");
            Console.WriteLine("  --win,   -w      Build for Windows platform");
            Console.WriteLine("  --allPlatforms   Build for all platforms");
            Console.WriteLine("  --help, -h       Show this help message");
            return 0;
        default:
            scriptsToProcess.Add(arg);
            break;
    }
}

string currentBranch = GetCurrentGitBranch(coreDir);
List<string> platforms = allPlatforms ? ["linux-x64", "osx-arm64", "win-x64"] : [runtime];

int result = -1;

string utilitiesDir = Path.GetFullPath(Path.Combine(coreScriptsDir, "..", "utilities"));
string[] utilitiesProjectFiles = Directory.GetFiles(utilitiesDir, "*.csproj", SearchOption.AllDirectories);
HashSet<string> updatedUtilities = [];

using CancellationTokenSource cts = new();

foreach (string platform in platforms)
{
    try
    {
        string outDir = Path.GetFullPath(Path.Combine(coreDir, "build-tools", platform));
        Trace.WriteLine($"Output directory: {outDir}");
        Directory.CreateDirectory(outDir);

        string recordFile = Path.Combine(outDir, ".csbuild-record.json");
        (long timeStamp, string oldBranch) = GetLastBuildRecord(recordFile);
        bool branchChanged = oldBranch != currentBranch;

        // Build Utilities first since other scripts may depend on them
        foreach (string utilityProj in utilitiesProjectFiles)
        {
            string projectName = Path.GetFileNameWithoutExtension(utilityProj);
            if (force || branchChanged || CheckIfNeedsBuild(timeStamp, utilityProj, outDir, utilitiesDir))
            {
                // restore first
                Trace.WriteLine($"Cleaning {projectName}...");
                result = await CleanScript(utilityProj, utilitiesDir, outDir, platform, cts.Token);
                if (result != 0)
                {
                    Trace.WriteLine($"Failed to clean {projectName} with exit code {result}");
                    cts.Cancel();
                    break;
                }
                Trace.WriteLine($"Restoring {projectName}...");
                result = await RestoreScript(utilityProj, utilitiesDir, outDir, platform, cts.Token);
                if (result != 0)
                {
                    Trace.WriteLine($"Failed to restore {projectName} with exit code {result}");
                    cts.Cancel();
                    break;
                }
                Trace.WriteLine($"Building {projectName}...");
                result = await BuildScript(utilityProj, utilitiesDir, outDir, platform, cts.Token);
                if (result != 0)
                {
                    Trace.WriteLine($"Failed to build {projectName} with exit code {result}");
                    cts.Cancel();
                    break;
                }
                updatedUtilities.Add(utilityProj);
            }
            else
            {
                Trace.WriteLine($"Skipping {projectName} - no changes detected.");
            }
        }

        // Build Core Scripts
        result = await BuildScripts(coreScripts, scriptsToProcess, coreScriptsDir, outDir, platform, force,
            cleanBeforeBuild, branchChanged, timeStamp, excludeMode, updatedUtilities, cts);

        if (result == 0)
        {
            SaveBuildRecord(recordFile, currentBranch);
        }
        else
        {
            Trace.WriteLine($"Failed to build core scripts for platform {platform} with exit code {result}");
            cts.Cancel();
            break;
        }

        // Build Pro Scripts if Core succeeded
        if (proScripts.Length > 0)
        {
            outDir = Path.GetFullPath(Path.Combine(proDir, "build-tools", platform));
            Trace.WriteLine($"Output directory: {outDir}");
            Directory.CreateDirectory(outDir);

            recordFile = Path.Combine(outDir, ".csbuild-record.json");
            (timeStamp, oldBranch) = GetLastBuildRecord(recordFile);
            branchChanged = oldBranch != currentBranch;

            result = await BuildScripts(proScripts, scriptsToProcess, proScriptsDir, outDir, platform, force,
                cleanBeforeBuild, branchChanged, timeStamp, excludeMode, updatedUtilities, cts);
            if (result == 0)
            {
                SaveBuildRecord(recordFile, currentBranch);
            }
            else
            {
                Trace.WriteLine($"Failed to build pro scripts for platform {platform} with exit code {result}");
                cts.Cancel();
                break;
            }
        }
    }
    catch (Exception ex) when (ex is not OperationCanceledException)
    {
        Trace.WriteLine($"Exception occurred while building scripts for platform {platform}: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
        cts.Cancel();
    }
}

if (result != 0)
{
    Trace.WriteLine($"ScriptBuilder failed with exit code {result}");
}

return result;

static async Task<int> BuildScripts(string[] scripts, HashSet<string> scriptsToProcess, string scriptsDir, string outDir,
    string runtime, bool force, bool cleanBeforeBuild, bool branchChanged, long timeStamp, bool excludeMode,
    HashSet<string> updatedUtilities, CancellationTokenSource cts)
{
    List<string> filteredScripts;
    if (scriptsToProcess.Count > 0)
    {
        Trace.WriteLine(excludeMode
            ? $"Excluding specified scripts: {string.Join(", ", scriptsToProcess)}"
            : $"Including only specified scripts: {string.Join(", ", scriptsToProcess)}");

        filteredScripts = excludeMode
            ? scripts.Where(s => !scriptsToProcess.Contains(Path.GetFileName(s))).ToList()
            : scripts.Where(s => scriptsToProcess.Contains(Path.GetFileName(s))).ToList();
    }
    else
    {
        filteredScripts = scripts.ToList();
    }

    filteredScripts.RemoveAll(s => Path.GetFileName(s) == "ScriptBuilder.cs");

    Dictionary<string, List<string>> scriptReferences = [];

    foreach (string script in filteredScripts)
    {
        scriptReferences[script] = GetScriptReferences(script);
    }

    int returnCode = 0;

    using SemaphoreSlim semaphore = new(1, 1);

    if (cleanBeforeBuild)
    {
        await Parallel.ForEachAsync(filteredScripts, cts.Token, async (script, token) =>
        {
            string fileName = Path.GetFileName(script);

            if (token.IsCancellationRequested)
            {
                Trace.WriteLine($"Build cancelled. Skipping script: {fileName}");
                return;
            }

            if (!force && !branchChanged && !CheckIfNeedsBuild(timeStamp, script, outDir, scriptsDir) 
                && !updatedUtilities.Intersect(scriptReferences[script]).Any())
            {
                Trace.WriteLine($"Skipping unchanged script: {fileName}");
                return;
            }

            if (scriptReferences[script].Any())
            {
                await semaphore.WaitAsync(token);
            }

            try
            {
                int scriptReturnCode = await CleanScript(fileName, scriptsDir, outDir, runtime, cts.Token);

                if (scriptReturnCode != 0)
                {
                    Trace.WriteLine($"Failed to clean script: {fileName} with exit code {scriptReturnCode}");
                    returnCode = scriptReturnCode;
                    cts.Cancel();
                }
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                Trace.WriteLine($"Exception occurred while cleaning script {fileName}: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
                returnCode = 1;
                cts.Cancel();
            }
            finally
            {
                if (scriptReferences[script].Any())
                {
                    semaphore.Release();
                }
            }
        });
    }

    await Parallel.ForEachAsync(filteredScripts, cts.Token, async (script, token) =>
    {
        string fileName = Path.GetFileName(script);

        if (token.IsCancellationRequested)
        {
            Trace.WriteLine($"Build cancelled. Skipping script: {fileName}");
            return;
        }
        
        if (!force && !branchChanged && !CheckIfNeedsBuild(timeStamp, script, outDir, scriptsDir) 
            && !updatedUtilities.Intersect(scriptReferences[script]).Any())
        {
            Trace.WriteLine($"Skipping unchanged script: {fileName}");
            return;
        }

        if (scriptReferences[script].Any())
        {
            await semaphore.WaitAsync(token);
        }

        try
        {
            int scriptReturnCode = await BuildScript(fileName, scriptsDir, outDir, runtime, cts.Token);

            if (scriptReturnCode != 0)
            {
                Trace.WriteLine($"Failed to build script: {fileName} with exit code {scriptReturnCode}");
                returnCode = scriptReturnCode;
                cts.Cancel();
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            Trace.WriteLine($"Exception occurred while building script {fileName}: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
            returnCode = 1;
            cts.Cancel();
        }
        finally
        {
            if (scriptReferences[script].Any())
            {
                semaphore.Release();
            }
        }
    });

    return returnCode;
}

/// <summary>
/// Compiles a single C# script to a DLL using 'dotnet build'.
/// </summary>
/// <param name="scriptName">The name of the script file (e.g., "ESBuild.cs").</param>
/// <param name="scriptsDir">The directory containing the script.</param>
/// <param name="outDir">The output directory for the compiled DLL.</param>
/// <param name="runtime">The runtime identifier for the build.</param>
/// <param name="cancellationToken">The cancellation token for the build process.</param>
/// <returns>0 on success, non-zero on failure.</returns>
static async Task<int> BuildScript(string scriptName, string scriptsDir, string outDir, string runtime, CancellationToken cancellationToken)
{
    Console.WriteLine($"Building script: {scriptName} for runtime: {runtime}");
    List<string> args =
    [
        "build",
        scriptName,
        "-c",
        "Release",
        "-o",
        outDir,
        "--runtime",
        runtime
    ];

    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = string.Join(" ", args),
        WorkingDirectory = scriptsDir,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    
    using Process? process = Process.Start(psi);
    if (process is null)
    {
        Trace.WriteLine($"Failed to build {scriptName}");
        return 1;
    }

    // Read output asynchronously
    process.OutputDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync(cancellationToken);

    // The file-based-app SDK bakes the source .cs file's absolute path into the generated
    // runtimeconfig.json. Rewrite it to a stable relative value so the committed output doesn't churn across machines.
    if (process.ExitCode == 0 && scriptName.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
    {
        RewriteRuntimeConfigPaths(scriptName, outDir);
    }

    return process.ExitCode;
}

/// <summary>
/// Replaces the absolute EntryPointFilePath/EntryPointFileDirectoryPath that the file-based-app SDK
/// writes into a script's runtimeconfig.json with machine-independent relative values.
/// </summary>
static void RewriteRuntimeConfigPaths(string scriptName, string outDir)
{
    string runtimeConfigPath = Path.Combine(outDir, Path.GetFileNameWithoutExtension(scriptName) + ".runtimeconfig.json");
    if (!File.Exists(runtimeConfigPath))
    {
        return;
    }

    try
    {
        if (JsonNode.Parse(File.ReadAllText(runtimeConfigPath)) is not { } root
            || root["runtimeOptions"] is not JsonObject runtimeOptions)
        {
            return;
        }

        // Remove the dead doubly-nested block left by the old runtimeconfig.template.json
        runtimeOptions.Remove("runtimeOptions");

        if (runtimeOptions["configProperties"] is not JsonObject configProperties
            || !configProperties.ContainsKey("EntryPointFilePath"))
        {
            return;
        }

        configProperties["EntryPointFilePath"] = $"./{scriptName}";
        configProperties["EntryPointFileDirectoryPath"] = ".";

        File.WriteAllText(runtimeConfigPath, root.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
    }
    catch (Exception ex)
    {
        Trace.WriteLine($"Failed to rewrite runtime config paths for {scriptName}: {ex.Message}");
    }
}

static async Task<int> CleanScript(string scriptName, string scriptsDir, string outDir, string runtime,
    CancellationToken cancellationToken)
{
    Console.WriteLine($"Cleaning script: {scriptName} for runtime: {runtime}");
    string[] args =
    [
        "clean",
        scriptName
    ];

    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = string.Join(" ", args),
        WorkingDirectory = scriptsDir,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    
    using Process? process = Process.Start(psi);
    if (process is null)
    {
        Trace.WriteLine($"Failed to build {scriptName}");
        return 1;
    }

    // Read output asynchronously
    process.OutputDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync(cancellationToken);
    return process.ExitCode;
}

static async Task<int> RestoreScript(string scriptName, string scriptsDir, string outDir, string runtime, 
    CancellationToken cancellationToken)
{
    Console.WriteLine($"Restoring packages for script: {scriptName} for runtime: {runtime}");
    string[] args =
    [
        "restore",
        scriptName,
        "--runtime",
        runtime
    ];

    ProcessStartInfo psi = new ProcessStartInfo
    {
        FileName = "dotnet",
        Arguments = string.Join(" ", args),
        WorkingDirectory = scriptsDir,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    
    using Process? process = Process.Start(psi);
    if (process is null)
    {
        Trace.WriteLine($"Failed to build {scriptName}");
        return 1;
    }

    // Read output asynchronously
    process.OutputDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Trace.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    await process.WaitForExitAsync(cancellationToken);
    return process.ExitCode;
}

/// <summary>
/// Gets the current Git branch name for a repository.
/// </summary>
/// <param name="workingDirectory">The directory within the Git repository.</param>
/// <returns>The branch name, or "unknown" if Git is unavailable or fails.</returns>
static string GetCurrentGitBranch(string workingDirectory)
{
    try
    {
        var psi = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = "rev-parse --abbrev-ref HEAD",
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi);
        if (process is null) return "unknown";

        string output = process.StandardOutput.ReadToEnd().Trim();
        process.WaitForExit();

        return process.ExitCode == 0 ? output : "unknown";
    }
    catch
    {
        return "unknown";
    }
}

/// <summary>
/// Determines whether a build is needed.
/// A build is needed if the script was modified since last build,
/// or the output directory is empty.
/// </summary>
/// <param name="timeStamp">The timestamp of the last build.</param>
/// <param name="script">The script name to check for changes.</param>
/// <param name="outputDir">Path to the JavaScript output directory.</param>
/// <returns>True if a build should be performed.</returns>
static bool CheckIfNeedsBuild(long timeStamp, string script, string outputDir, string scriptsDir)
{
    if (!GetScriptModifiedSince(script, timeStamp, scriptsDir))
    {
        Trace.WriteLine("No change in script since last build.");

        // Check output directory for existing files
        if (Directory.Exists(outputDir) && Directory.GetFiles(outputDir).Length > 0)
        {
            // DLLs and runtimeconfig.json files must exist for each script to function in build pipelines
            string fileName = Path.GetFileNameWithoutExtension(script);
            if (fileName == "ScriptBuilder")
            {
                // we always skip ScriptBuilder itself
                return false;
            }
            string outputDll = Path.Combine(outputDir, fileName + ".dll");
            if (!File.Exists(outputDll))
            {
                Trace.WriteLine($"Output DLL missing: {outputDll}. Proceeding with build.");
                return true;
            }
            // Library projects (.csproj) don't produce runtimeconfig.json, only scripts (.cs) do
            if (script.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
            {
                string outputRuntimeJson = Path.Combine(outputDir, fileName + ".runtimeconfig.json");
                if (!File.Exists(outputRuntimeJson))
                {
                    Trace.WriteLine($"Output runtime config missing: {outputRuntimeJson}. Proceeding with build.");
                    return true;
                }
            }
        }
        else
        {
            Trace.WriteLine("Output directory is empty. Proceeding with build.");
            return true;
        }

        return false;
    }

    Trace.WriteLine("Changes detected in Scripts folder. Proceeding with build.");
    return true;
}

/// <summary>
/// Reads the last build record from the JSON file.
/// The record contains the timestamp of the last successful build and the branch name.
/// </summary>
/// <param name="recordFilePath">Path to the .esbuild-record.json file.</param>
/// <returns>A tuple containing the Unix timestamp (milliseconds) and branch name.</returns>
static (long Timestamp, string Branch) GetLastBuildRecord(string recordFilePath)
{
    if (!File.Exists(recordFilePath))
    {
        return (0, "unknown");
    }

    try
    {
        string json = File.ReadAllText(recordFilePath);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        long timestamp = root.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;
        string branch = root.TryGetProperty("branch", out var br) ? br.GetString() ?? "unknown" : "unknown";

        return (timestamp, branch);
    }
    catch
    {
        return (0, "unknown");
    }
}

/// <summary>
/// Checks if the script is newer than the compiled tool
/// </summary>
/// <param name="script">Path to the source script.</param>
/// <param name="lastTimestamp">Unix timestamp (milliseconds) of the last build.</param>
/// <returns>True if the file has been modified since the timestamp.</returns>
static bool GetScriptModifiedSince(string script, long lastTimestamp, string scriptsDir)
{
    var lastBuildTime = DateTimeOffset.FromUnixTimeMilliseconds(lastTimestamp).DateTime;

    return File.GetLastWriteTimeUtc(script) > lastBuildTime;
}

/// <summary>
/// Saves the build record to a JSON file after a successful build.
/// Records the current timestamp and branch name for incremental build detection.
/// </summary>
/// <param name="recordFilePath">Path where the record should be saved.</param>
/// <param name="branch">The current Git branch name.</param>
static void SaveBuildRecord(string recordFilePath, string branch)
{
    long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    // Write JSON manually to avoid reflection-based serialization (not compatible with Native AOT)
    string json = $$"""
        {
          "timestamp": {{timestamp}},
          "branch": "{{branch.Replace("\\", "\\\\").Replace("\"", "\\\"")}}"
        }
        """;
    File.WriteAllText(recordFilePath, json);
}

/// <summary>
/// Gets the relative directory containing the build scripts.
/// </summary>
static string GetCoreScriptsDirectory([CallerFilePath] string? callerFilePath = null)
{
    string dllDirectory = AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

    if (dllDirectory.Contains("dotnet"))
    {
        // we are running from the C# script in build-scripts, so we can use the caller file path to find the script directory
        return Path.GetDirectoryName(callerFilePath!)!;
    }

    // otherwise the dll is stored in ./build-tools/{os}-{arch}
    return Path.GetFullPath(Path.Combine(dllDirectory, "..", "build-scripts"));
}


static List<string> GetScriptReferences(string scriptPath)
{
    List<string> references = [];
    
    if (!File.Exists(scriptPath))
    {
        return references;
    }

    try
    {
        string scriptDir = Path.GetDirectoryName(scriptPath)!;
        string scriptContent = File.ReadAllText(scriptPath);
        var matches = Regex.Matches(scriptContent, @"#:project\s+([^\r\n]+)", RegexOptions.IgnoreCase);
        foreach (Match match in matches)
        {
            string refPath = match.Groups[1].Value.Trim();
            // Resolve relative paths to full paths so they match updatedUtilities entries
            references.Add(Path.GetFullPath(Path.Combine(scriptDir, refPath)));
        }
        return references;
    }
    catch
    {
        return references;
    }
}