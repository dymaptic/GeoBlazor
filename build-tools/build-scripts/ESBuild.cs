#!/usr/bin/env dotnet
#:project ../utilities/Utilities.csproj

// ESBuild TypeScript -> JavaScript Compilation Script
// C# file-based app version of esBuild.ps1
// Usage: dotnet esBuild.cs [options]
//   -c, --configuration <Debug|Release>  Build configuration (default: Debug)
//   -f, --force                          Force rebuild, ignoring lock files and record
//   -p, --pro                            Run the GeoBlazor Pro ESBuild process
//   -pc, --prooncorechange               Run the GeoBlazor Pro ESBuild process if pro OR core files have changed
//   -d, --dialog                         Show a console dialog during build
//   -v, --verbose                        Enable verbose logging
//   -h, --help                           Display help message

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Utilities;

// Get the actual script location using CallerFilePath (resolved at compile time)
string scriptDir = PathFinder.GetScriptsDirectory();
string os = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? "win"
    : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
        ? "osx"
        : "linux";
string arch = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();
string toolsDir = Path.GetFullPath(Path.Combine(scriptDir, "..", $"{os}-{arch}"));

// Parse command line arguments
string configuration = Environment.GetEnvironmentVariable("Configuration") ?? "Debug";
bool force = false;
bool help = false;
bool pro = false;
bool proOnCoreChange = false;
bool dialog = false;
bool verbose = false;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();
    switch (arg)
    {
        case "-c":
        case "--configuration":
            if (i + 1 < args.Length)
            {
                configuration = args[++i];
            }
            break;
        case "-d":
        case "--dialog":
            dialog = true;
            break;
        case "-f":
        case "--force":
            force = true;
            break;
        case "-p":
        case "-pro":
        case "--pro":
            pro = true;
            break;
        case "-pc":
        case "-pocore":
        case "--prooncorechange":
            proOnCoreChange = true;
            break;
        case "-h":
        case "--help":
            help = true;
            break;
        case "-v":
        case "--verbose":
            verbose = true;
            break;
        default:
            // Check for combined forms like "-c=Release"
            if (arg.StartsWith("-c=") || arg.StartsWith("--configuration="))
            {
                configuration = args[i].Split('=', 2)[1];
            }
            break;
    }
}

Trace.Listeners.Add(new ConsoleTraceListener());
Trace.AutoFlush = true;

if (help)
{
    Trace.WriteLine("ESBuild TypeScript -> JavaScript Compilation Script");
    Trace.WriteLine("");
    Trace.WriteLine("Parameters:");
    Trace.WriteLine("  -f, --force                          Removes any lock files and forces the script to run");
    Trace.WriteLine("  -c, --configuration <string>         Build configuration (default is 'Debug')");
    Trace.WriteLine("                                       Valid values are 'Debug' and 'Release'");
    Trace.WriteLine("  -p, --pro                            Run the GeoBlazor Pro ESBuild process");
    Trace.WriteLine("  -pc, --prooncorechange               Run the GeoBlazor Pro ESBuild process if pro OR core files have changed");
    Trace.WriteLine("  -h, --help                           Display this help message");
    return 0;
}

Process? dialogProcess = null;

if (verbose)
{
    if (dialog) // only start the dialog early if we are in Verbose + Dialog mode
    {
        dialogProcess = StartConsoleDialog(toolsDir, $"GeoBlazor {(pro ? "PRO" : "CORE")} ESBuild", pro);
    }
    Trace.WriteLine($"ESBUILD {(pro ? "PRO:" : "CORE:")} Launching...");
}

// Normalize configuration
configuration = configuration.Equals("release", StringComparison.OrdinalIgnoreCase) ? "Release" : "Debug";

// Scripts are in GeoBlazor.Pro/GeoBlazor/build-tools/build-scripts
// Core source is at GeoBlazor.Pro/GeoBlazor/src/dymaptic.GeoBlazor.Core relative to build folder
// Pro source is at GeoBlazor.Pro/src/dymaptic.GeoBlazor.Pro relative to build folder
string coreSourceDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Core"));
string proSourceDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "..", "src", "dymaptic.GeoBlazor.Pro"));
string sourceDir = pro ? proSourceDir : coreSourceDir;

string coreScriptsDir = Path.Combine(coreSourceDir, "Scripts");
string proScriptsDir = Path.Combine(proSourceDir, "Scripts");
string scriptsDir = pro ? proScriptsDir : coreScriptsDir;

string coreOutputDir = Path.Combine(coreSourceDir, "wwwroot", "js");
string proOutputDir = Path.Combine(proSourceDir, "wwwroot", "js");
string outputDir = pro ? proOutputDir : coreOutputDir;

string coreRecordFilePath = Path.GetFullPath(Path.Combine(coreSourceDir, "..", ".esbuild-record.json"));
string proRecordFilePath = Path.GetFullPath(Path.Combine(proSourceDir, "..", ".esbuild-record.json"));
string recordFilePath = pro ? proRecordFilePath : coreRecordFilePath;

string currentBranch = GetCurrentGitBranch(sourceDir);

if (!force)
{
    bool needsBuild = CheckIfNeedsBuild(
        recordFilePath,
        currentBranch,
        scriptsDir, outputDir, pro ? "PRO" : "CORE", pro ? "PRO" : "CORE");

    if (!needsBuild && pro && proOnCoreChange)
    {
        needsBuild = CheckIfNeedsBuild(coreRecordFilePath,
            currentBranch, coreScriptsDir, coreOutputDir, "CORE", "PRO");
    }

    if (!needsBuild)
    {
        KillDialog(dialogProcess);
        Environment.Exit(0);
    }
}

if (!verbose)
{
    if (dialog) // start the dialog now if we are not in Verbose mode
    {
        dialogProcess = StartConsoleDialog(toolsDir, 
            $"GeoBlazor {(pro ? "PRO" : "CORE")} ESBuild", pro);
    }
    Trace.WriteLine($"ESBUILD {(pro ? "PRO:" : "CORE:")} Launching...");
}

try
{
    // Ensure output directory exists
    if (!Directory.Exists(outputDir))
    {
        Directory.CreateDirectory(outputDir);
    }

    if (pro)
    {
        // Copy core Scripts to Pro Scripts
        CopyScriptsToPro(coreScriptsDir, proScriptsDir, verbose);
    }

    // npm install
    await ProcessRunner.RunNpmCommand(sourceDir, "install");
    Trace.WriteLine("-----");

    // Run ESLint before build
    Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: Running ESLint...");
    await ProcessRunner.RunNpmCommand(sourceDir, "run lint");
    Trace.WriteLine("-----");

    // Run build
    string buildCommand = configuration == "Release" ? "run releaseBuild" : "run debugBuild";
    await ProcessRunner.RunNpmCommand(sourceDir, buildCommand);
    Trace.WriteLine("-----");

    // Update build record on success
    SaveBuildRecord(recordFilePath, currentBranch);

    Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: NPM Build Complete");
    KillDialog(dialogProcess);
    return 0;
}
catch (Exception ex)
{
    Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: An error occurred in esBuild.cs");
    Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
    HoldDialog(dialogProcess);
    return 1;
}

// ============================================================================
// Helper Methods
// ============================================================================

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
        if (process is null) return "no-git";

        string output = process.StandardOutput.ReadToEnd().Trim();
        process.WaitForExit();

        return process.ExitCode == 0 ? output : "no-git";
    }
    catch
    {
        return "no-git";
    }
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
/// Determines whether a TypeScript build is needed.
/// A build is needed if: the branch changed, scripts were modified since last build,
/// or the output directory is empty.
/// </summary>
/// <param name="recordFilePath">Path to the build record file.</param>
/// <param name="currentBranch">The current Git branch name.</param>
/// <param name="scriptsDir">Path to the TypeScript source files.</param>
/// <param name="outputDir">Path to the JavaScript output directory.</param>
/// <returns>True if a build should be performed.</returns>
static bool CheckIfNeedsBuild(string recordFilePath, string currentBranch, string scriptsDir, string outputDir,
    string proOrCore, string sourceProject)
{
    // Check if build is needed
    var lastBuild = GetLastBuildRecord(recordFilePath);
    bool branchChanged = currentBranch != "no-git" 
        && currentBranch != lastBuild.Branch;

    if (branchChanged)
    {
        Trace.WriteLine($"ESBUILD {sourceProject}: Git branch changed from \"{lastBuild.Branch}\" to \"{currentBranch}\". Rebuilding...");
        return true;
    }

    if (!GetScriptsModifiedSince(scriptsDir, lastBuild.Timestamp, sourceProject))
    {
        Trace.WriteLine($"ESBUILD {sourceProject}: No changes in Scripts folder since last build.");

        // Check output directory for existing files
        if (Directory.Exists(outputDir) && Directory.GetFiles(outputDir).Length > 0)
        {
            Trace.WriteLine($"ESBUILD {sourceProject}: Output directory is not empty. Skipping build.");
            return false;
        }
        else
        {
            Trace.WriteLine($"ESBUILD {sourceProject}: Output directory is empty. Proceeding with build.");
            return true;
        }
    }

    Trace.WriteLine($"ESBUILD {sourceProject}: Changes detected in Scripts folder. Proceeding with build.");
    return true;
}

/// <summary>
/// Copies TypeScript files from Core's Scripts directory to Pro's Scripts directory.
/// Files listed in Pro's esBuild.js with a "pro_" prefix are renamed accordingly.
/// Only copies files that are newer than the destination.
/// </summary>
/// <param name="coreScriptsDir">Path to Core's Scripts directory.</param>
/// <param name="proScriptsDir">Path to Pro's Scripts directory.</param>
/// <param name="verbose">If true, logs each file operation.</param>
static void CopyScriptsToPro(string coreScriptsDir, string proScriptsDir, bool verbose)
{
    Trace.WriteLine("ESBUILD PRO: Copying core Scripts to Pro Scripts directory...");
    if (!Directory.Exists(proScriptsDir))
    {
        Directory.CreateDirectory(proScriptsDir);
    }

    Regex proPrefixedFileRegex = new(@"^\s*'\.\/Scripts\/pro_(?<fileName>\w+)\.ts',\s*$",
        RegexOptions.Compiled);

    string proEsBuildJsFilePath = Path.GetFullPath(
        Path.Combine(proScriptsDir, "..", "esBuild.js"));

    List<string> proPrefixedFiles = [];

    foreach (string line in File.ReadAllLines(proEsBuildJsFilePath))
    {
        Match match = proPrefixedFileRegex.Match(line);
        if (match.Success)
        {
            string fileName = match.Groups["fileName"].Value;
            proPrefixedFiles.Add($"{fileName}.ts");
            Trace.WriteLine($"ESBUILD PRO: Found pro_ file: {fileName}.ts");
            continue;
        }
        if (line.TrimStart().StartsWith("chunkNames"))
        {
            // we are past all the pro_ files
            break;
        }
    }

    int copiedCount = 0;
    int skippedCount = 0;
    List<string> fileNames = [];

    foreach (string filePath in Directory.GetFiles(coreScriptsDir, "*.ts", SearchOption.AllDirectories))
    {
        string fileName = Path.GetFileName(filePath);
        fileNames.Add(fileName);
        string destinationFileName = fileName;
        if (proPrefixedFiles.Contains(fileName))
        {
            destinationFileName = $"pro_{fileName}";
        }
        string destinationPath = Path.Combine(proScriptsDir, destinationFileName);

        if (!File.Exists(destinationPath))
        {
            File.Copy(filePath, destinationPath, true);
            copiedCount++;
            if (verbose)
            {
                Trace.WriteLine($"ESBUILD PRO: Copied new file: {fileName}");
            }
            continue;
        }

        DateTime sourceDate = File.GetLastWriteTimeUtc(filePath);
        DateTime destDate = File.GetLastWriteTimeUtc(destinationPath);

        if (sourceDate > destDate)
        {
            File.Copy(filePath, destinationPath, true);
            if (verbose)
            {
                Trace.WriteLine($"ESBUILD PRO: Updated file: {fileName}");
            }
            copiedCount++;
        }
        else
        {
            skippedCount++;
        }
    }
    
    Trace.WriteLine($"ESBUILD PRO: Copied {copiedCount} files, skipped {skippedCount} files.");
}

/// <summary>
/// Saves the build record to a JSON file after a successful build.
/// Records the current timestamp and branch name for incremental build detection.
/// </summary>
/// <param name="recordFilePath">Path where the record should be saved.</param>
/// <param name="branch">The current Git branch name.</param>
static void SaveBuildRecord(string recordFilePath, string branch)
{
    // buffer 30 seconds into the future to avoid edge cases
    long timestamp = DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeMilliseconds();
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
/// Checks if any TypeScript files in the Scripts directory have been modified
/// since the given timestamp.
/// </summary>
/// <param name="scriptsDir">Path to the Scripts directory to scan.</param>
/// <param name="lastTimestamp">Unix timestamp (milliseconds) of the last build.</param>
/// <returns>True if any files have been modified since the timestamp.</returns>
static bool GetScriptsModifiedSince(string scriptsDir, long lastTimestamp, string sourceProject)
{
    if (!Directory.Exists(scriptsDir))
    {
        return true; // Force rebuild if Scripts folder doesn't exist
    }

    var lastBuildTime = DateTimeOffset.FromUnixTimeMilliseconds(lastTimestamp).DateTime;

    foreach (string file in Directory.GetFiles(scriptsDir, "*.ts", SearchOption.AllDirectories))
    {
        if (File.GetLastWriteTimeUtc(file) > lastBuildTime)
        {
            Trace.WriteLine($"ESBUILD {sourceProject}: File {file} modified at {File.GetLastWriteTimeUtc(file).ToLocalTime():T} (last build: {lastBuildTime.ToLocalTime():T})");
            return true;
        }
    }

    return false;
}

/// <summary>
/// Starts the ConsoleDialog process to display build progress in a separate window.
/// </summary>
/// <param name="buildDir">The build-tools directory containing ConsoleDialog.dll.</param>
/// <param name="title">The title for the console window.</param>
/// <returns>The started Process, or null if it failed to start.</returns>
static Process? StartConsoleDialog(string buildDir, string title, bool pro)
{
    try
    {
        string consoleDialogPath = Path.Combine(buildDir, "ConsoleDialog.dll");
        if (!File.Exists(consoleDialogPath))
        {
            Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: ConsoleDialog.dll not found at {consoleDialogPath}");
            return null;
        }
        
        string[] args =
        [
            "ConsoleDialog.dll",
            $"\"{title}\"",
            "-w",
            "2"
        ];

        var psi = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = string.Join(" ", args),
            WorkingDirectory = buildDir,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process? dialog = Process.Start(psi);

        if (dialog?.StandardInput is null)
        {
            Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: Failed to start console dialog. Exiting.");
        }
        else
        {
            dialog.StandardInput.AutoFlush = true;
            Trace.Listeners.Add(new DialogTraceListener(dialog, pro));
        }

        return dialog;
    }
    catch (Exception ex)
    {
        Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: Failed to start ConsoleDialog: {ex.Message}");
        return null;
    }
}

/// <summary>
/// Gracefully closes the ConsoleDialog process by sending an "exit" command.
/// </summary>
/// <param name="dialog">The ConsoleDialog process to close.</param>
static void KillDialog(Process? dialog)
{
    if (dialog is null || dialog.HasExited)
    {
        return;
    }

    try
    {
        if (dialog?.StandardInput is not null)
        {
            // Flush to ensure all pending messages are sent before exit
            dialog.StandardInput.Flush();
            // Small delay to allow the dialog to display the final message
            Thread.Sleep(500);
            dialog.StandardInput.WriteLine("exit");
        }
    }
    catch
    {
        dialog.Kill();
    }
}

/// <summary>
/// Sends a failure message to the dialog and keeps it open for user review.
/// </summary>
/// <param name="dialog">The ConsoleDialog process.</param>
static void HoldDialog(Process? dialog)
{
    if (dialog?.StandardInput is not null && !dialog.HasExited)
    {
        dialog.StandardInput.WriteLine("hold");
    }
}

/// <summary>
/// A TraceListener that forwards trace output to a ConsoleDialog process via stdin.
/// This allows build output to be displayed in the popup console window.
/// </summary>
public class DialogTraceListener(Process dialog, bool isPro) : TraceListener
{
    public override void Write(string? message)
    {
        if (dialog.StandardInput is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            dialog.StandardInput.Write(isPro ? $"PRO: {message}" : message);
        }
        catch
        {
            // Dialog may have closed - ignore
        }
    }

    public override void WriteLine(string? message)
    {
        if (dialog.StandardInput is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            dialog.StandardInput.WriteLine(isPro ? $"PRO: {message}" : message);
        }
        catch
        {
            // Dialog may have closed - ignore
        }
    }
}