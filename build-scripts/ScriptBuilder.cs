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
//   --exclude    When specified, the listed scripts will be skipped instead of included
//   --force, -f  Force rebuild of all scripts regardless of changes
//
// Output:
//   Compiled DLLs are placed in GeoBlazor/build-tools/ directory
//
// Note: ScriptBuilder.cs itself is always skipped to avoid self-compilation issues.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

bool excludeMode = false;
HashSet<string> scriptsToProcess = new();
string scriptsDir = GetScriptsDirectory();
string coreDir = Path.GetFullPath(Path.Combine(scriptsDir, ".."));
string outDir = Path.GetFullPath(Path.Combine(coreDir, "build-tools"));

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.WriteLine("Starting ScriptBuilder...");

string[] scripts = Directory.GetFiles(scriptsDir, "*.cs");
bool force = false;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();

    switch (arg)
    {
        case "--exclude":
            excludeMode = true;
            break;
        case "--force":
        case "-f":
            force = true;
            break;
        default:
            scriptsToProcess.Add(arg);
            break;
    }
}

string recordFile = Path.Combine(outDir, ".csbuild-record.json");
string currentBranch = GetCurrentGitBranch(coreDir);
if (!force)
{
    if (!CheckIfNeedsBuild(recordFile, currentBranch, scriptsDir, outDir, scripts))
    {
        return 0;
    }
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

    int returnCode = BuildScript(Path.GetFileName(script), scriptsDir, outDir);
    if (returnCode != 0)
    {
        return returnCode;
    }
}

SaveBuildRecord(recordFile, currentBranch);

return 0;



/// <summary>
/// Compiles a single C# script to a DLL using 'dotnet build'.
/// </summary>
/// <param name="scriptName">The name of the script file (e.g., "ESBuild.cs").</param>
/// <param name="scriptsDir">The directory containing the script.</param>
/// <param name="outDir">The output directory for the compiled DLL.</param>
/// <returns>0 on success, non-zero on failure.</returns>
static int BuildScript(string scriptName, string scriptsDir, string outDir)
{
    string[] args =
    [
        "build",
        scriptName,
        "-c",
        "Release",
        "-o",
        outDir
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
/// Gets the directory containing the build scripts.
/// When running as a .cs file, uses [CallerFilePath]. When running as a compiled DLL,
/// calculates the path relative to the DLL location.
/// </summary>
/// <param name="callerFilePath">Automatically populated with the source file path at compile time.</param>
/// <returns>The absolute path to the build-scripts directory.</returns>
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
/// A build is needed if: the branch changed, scripts were modified since last build,
/// or the output directory is empty.
/// </summary>
/// <param name="recordFilePath">Path to the build record file.</param>
/// <param name="currentBranch">The current Git branch name.</param>
/// <param name="scriptsDir">Path to the TypeScript source files.</param>
/// <param name="outputDir">Path to the JavaScript output directory.</param>
/// <param name="scripts">Array of script names to check for changes.</param>
/// <returns>True if a build should be performed.</returns>
static bool CheckIfNeedsBuild(string recordFilePath, string currentBranch, string scriptsDir, string outputDir,
    string[] scripts)
{
    // Check if build is needed
    var lastBuild = GetLastBuildRecord(recordFilePath);
    bool branchChanged = currentBranch != lastBuild.Branch;

    if (branchChanged)
    {
        Trace.WriteLine($"Git branch changed from \"{lastBuild.Branch}\" to \"{currentBranch}\". Rebuilding...");
        return true;
    }

    if (!GetScriptsModifiedSince(scriptsDir, lastBuild.Timestamp))
    {
        Trace.WriteLine("No changes in Scripts folder since last build.");

        // Check output directory for existing files
        if (Directory.Exists(outputDir) && Directory.GetFiles(outputDir).Length > 0)
        {
            // DLLs and runtimeconfig.json files must exist for each script to function in build pipelines
            foreach (string script in scripts)
            {
                string fileName = Path.GetFileNameWithoutExtension(script);
                if (fileName == "ScriptBuilder")
                {
                    continue;
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
            return false;
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
/// Checks if any files in the build-tools directory have been modified
/// since the given timestamp.
/// </summary>
/// <param name="scriptsDir">Path to the Scripts directory to scan.</param>
/// <param name="lastTimestamp">Unix timestamp (milliseconds) of the last build.</param>
/// <returns>True if any files have been modified since the timestamp.</returns>
static bool GetScriptsModifiedSince(string scriptsDir, long lastTimestamp)
{
    if (!Directory.Exists(scriptsDir))
    {
        return true; // Force rebuild if Scripts folder doesn't exist
    }

    var lastBuildTime = DateTimeOffset.FromUnixTimeMilliseconds(lastTimestamp).DateTime;

    foreach (string file in Directory.GetFiles(scriptsDir, "*", SearchOption.AllDirectories))
    {
        if (File.GetLastWriteTimeUtc(file) > lastBuildTime)
        {
            return true;
        }
    }

    return false;
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