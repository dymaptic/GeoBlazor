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

bool excludeMode = false;
HashSet<string> scriptsToProcess = new();
string scriptsDir = GetScriptsDirectory();
string coreDir = Path.GetFullPath(Path.Combine(scriptsDir, "..", ".."));

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.WriteLine("Starting ScriptBuilder...");

string[] scripts = Directory.GetFiles(scriptsDir, "*.cs");
bool force = false;
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

int result = -1;

if (allPlatforms)
{
    string[] platforms = new[] { "linux-x64", "osx-arm64", "win-x64" };
    foreach (string plat in platforms)
    {
        Trace.WriteLine($"Building for platform: {plat}");
        result = BuildScripts(scripts, scriptsToProcess, coreDir, plat, force, scriptsDir, excludeMode, currentBranch);
        if (result != 0)
        {
            break;
        }
    }
}
else if (runtime == "win-x64" && RuntimeInformation.OSArchitecture != Architecture.X64)
{
    Trace.WriteLine("Warning: Building for win-x64 on non-x64 architecture may fail.");
    result = BuildScripts(scripts, scriptsToProcess, coreDir, runtime, force, scriptsDir, excludeMode, currentBranch);
}
else if (runtime == "osx-arm64" && RuntimeInformation.OSArchitecture != Architecture.Arm64)
{
    Trace.WriteLine("Warning: Building for osx-arm64 on non-Arm64 architecture may fail.");
    result = BuildScripts(scripts, scriptsToProcess, coreDir, runtime, force, scriptsDir, excludeMode, currentBranch);
}
else if (runtime == "linux-x64" && RuntimeInformation.OSArchitecture != Architecture.X64)
{
    Trace.WriteLine("Warning: Building for linux-x64 on non-x64 architecture may fail.");
    result = BuildScripts(scripts, scriptsToProcess, coreDir, runtime, force, scriptsDir, excludeMode, currentBranch);
}
else
{
    result = BuildScripts(scripts, scriptsToProcess, coreDir, runtime, force, scriptsDir, excludeMode, currentBranch);
}

if (result != 0)
{
    Trace.WriteLine($"ScriptBuilder failed with exit code {result}");
    return result;
}

return 0;

static int BuildScripts(string[] scripts, HashSet<string> scriptsToProcess, string coreDir, string runtime, bool force,
    string scriptsDir, bool excludeMode, string currentBranch)
{
    string outDir = Path.GetFullPath(Path.Combine(coreDir, "build-tools", runtime));
    Trace.WriteLine($"Output directory: {outDir}");

    Directory.CreateDirectory(outDir);

    string recordFile = Path.Combine(outDir, ".csbuild-record.json");
    (long timeStamp, string oldBranch) = GetLastBuildRecord(recordFile);
    bool branchChanged = oldBranch != currentBranch;

    if (scriptsToProcess.Count > 0)
    {
        Trace.WriteLine(excludeMode
            ? $"Excluding specified scripts: {string.Join(", ", scriptsToProcess)}"
            : $"Including only specified scripts: {string.Join(", ", scriptsToProcess)}");
    }

    foreach (string script in scripts)
    {
        if (Path.GetFileName(script) == "ScriptBuilder.cs")
        {
            continue;
        }

        if (scriptsToProcess.Count > 0)
        {
            if (excludeMode && scriptsToProcess.Contains(Path.GetFileName(script)))
            {
                Trace.WriteLine($"Skipping excluded script: {Path.GetFileName(script)}");
                continue;
            }
            else if (!excludeMode && !scriptsToProcess.Contains(Path.GetFileName(script)))
            {
                Trace.WriteLine($"Skipping unlisted script: {Path.GetFileName(script)}");
                continue;
            }
        }

        if (!branchChanged && !CheckIfNeedsBuild(timeStamp, script, outDir))
        {
            Trace.WriteLine($"Skipping unchanged script: {Path.GetFileName(script)}");
            continue;
        }

        int returnCode = BuildScript(Path.GetFileName(script), scriptsDir, outDir, runtime);
        if (returnCode != 0)
        {
            return returnCode;
        }
    }

    SaveBuildRecord(recordFile, currentBranch);

    return 0;
}

/// <summary>
/// Compiles a single C# script to a DLL using 'dotnet build'.
/// </summary>
/// <param name="scriptName">The name of the script file (e.g., "ESBuild.cs").</param>
/// <param name="scriptsDir">The directory containing the script.</param>
/// <param name="outDir">The output directory for the compiled DLL.</param>
/// <param name="runtime">The runtime identifier for the build.</param>
/// <returns>0 on success, non-zero on failure.</returns>
static int BuildScript(string scriptName, string scriptsDir, string outDir, string runtime)
{
    string[] args =
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
    process.WaitForExit();
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
static bool CheckIfNeedsBuild(long timeStamp, string script, string outputDir)
{
    if (!GetScriptModifiedSince(script, timeStamp))
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
            string outputRuntimeJson = Path.Combine(outputDir, fileName + ".runtimeconfig.json");
            if (!File.Exists(outputRuntimeJson))
            {
                Trace.WriteLine($"Output runtime config missing: {outputRuntimeJson}. Proceeding with build.");
                return true;
            }
        }
        else
        {
            Trace.WriteLine("Output directory is empty. Proceeding with build.");
            return true;
        }
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
static bool GetScriptModifiedSince(string script, long lastTimestamp)
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
static string GetScriptsDirectory([CallerFilePath] string? callerFilePath = null)
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