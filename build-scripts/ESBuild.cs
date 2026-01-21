#!/usr/bin/env dotnet

// ESBuild TypeScript -> JavaScript Compilation Script
// C# file-based app version of esBuild.ps1
// Usage: dotnet esBuild.cs [options]
//   -c, --configuration <Debug|Release>  Build configuration (default: Debug)
//   -f, --force                          Force rebuild, ignoring lock files and record
//   -p, --pro                            Run the GeoBlazor Pro ESBuild process
//   -d, --dialog                         Show a console dialog during build
//   -v, --verbose                        Enable verbose logging
//   -h, --help                           Display help message

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

// Get the actual script location using CallerFilePath (resolved at compile time)
string scriptDir = GetScriptsDirectory();
string toolsDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "build-tools"));

// Parse command line arguments
string configuration = "Debug";
bool force = false;
bool help = false;
bool pro = false;
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
        case "--pro":
            pro = true;
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

if (help)
{
    Trace.WriteLine("ESBuild TypeScript -> JavaScript Compilation Script");
    Trace.WriteLine("");
    Trace.WriteLine("Parameters:");
    Trace.WriteLine("  -f, --force                          Removes any lock files and forces the script to run");
    Trace.WriteLine("  -c, --configuration <string>         Build configuration (default is 'Debug')");
    Trace.WriteLine("                                       Valid values are 'Debug' and 'Release'");
    Trace.WriteLine("  -p, --pro                            Run the GeoBlazor Pro ESBuild process");
    Trace.WriteLine("  -h, --help                           Display this help message");
    return 0;
}

Trace.Listeners.Add(new ConsoleTraceListener());

Process? dialogProcess = null;

if (verbose)
{
    if (dialog) // only start the dialog early if we are in Verbose + Dialog mode
    {
        dialogProcess = StartConsoleDialog(toolsDir, $"GeoBlazor {(pro ? "Pro" : "Core")} ESBuild");
    }
    Trace.WriteLine("Launching ESBuild...");
}

// Normalize configuration
configuration = configuration.Equals("release", StringComparison.OrdinalIgnoreCase) ? "Release" : "Debug";

// The build folder is where this script is located (scriptDir set at top using CallerFilePath)
// Core source is at ../src/dymaptic.GeoBlazor.Core relative to build folder
string coreSourceDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "src", "dymaptic.GeoBlazor.Core"));
string proSourceDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Pro"));
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

string coreDebugLockFile = Path.Combine(coreSourceDir, "esBuild.Debug.lock");
string coreReleaseLockFile = Path.Combine(coreSourceDir, "esBuild.Release.lock");
string proDebugLockFile = Path.Combine(proSourceDir, "esBuild.Debug.lock");
string proReleaseLockFile = Path.Combine(proSourceDir, "esBuild.Release.lock");
string debugLockFile = configuration == "Debug" ? (pro ? proDebugLockFile : coreDebugLockFile) : string.Empty;
string releaseLockFile = configuration == "Release" ? (pro ? proReleaseLockFile : coreReleaseLockFile) : string.Empty;
string coreLockFilePath = configuration == "Release" ? coreReleaseLockFile : coreDebugLockFile;
string proLockFilePath = configuration == "Release" ? proReleaseLockFile : proDebugLockFile;
string lockFilePath = pro ? proLockFilePath : coreLockFilePath;

// Handle --force flag: delete record file
if (force && File.Exists(coreRecordFilePath))
{
    Trace.WriteLine("Force rebuild: Deleting existing record file.");
    File.Delete(coreRecordFilePath);
}
if (force && File.Exists(proRecordFilePath))
{
    Trace.WriteLine("Force rebuild: Deleting existing record file.");
    File.Delete(proRecordFilePath);
}

string currentBranch = GetCurrentGitBranch(coreSourceDir);

bool needsBuild = CheckIfNeedsBuild(
    coreRecordFilePath,
    currentBranch,
    coreScriptsDir,
    coreOutputDir);

if (pro)
{
    currentBranch = GetCurrentGitBranch(proSourceDir);
    needsBuild = CheckIfNeedsBuild(
        proRecordFilePath,
        currentBranch,
        proScriptsDir,
        proOutputDir);
}

if (!needsBuild)
{
    KillDialog(dialogProcess);
    Environment.Exit(0);
}

if (!verbose)
{
    if (dialog) // start the dialog now if we are not in Verbose mode
    {
        dialogProcess = StartConsoleDialog(toolsDir, $"GeoBlazor {(pro ? "Pro" : "Core")} ESBuild");
    }
    Trace.WriteLine("Launching ESBuild...");
}

// Check if the process is locked for the current configuration
bool locked = configuration == "Debug" && File.Exists(debugLockFile)
           || configuration == "Release" && File.Exists(releaseLockFile);

// Prevent multiple instances of the script from running at the same time
if (locked)
{
    if (force)
    {
        if (File.Exists(debugLockFile)) File.Delete(debugLockFile);
        if (File.Exists(releaseLockFile)) File.Delete(releaseLockFile);
        Trace.WriteLine("Cleared esBuild lock files");
    }
    else
    {
        Trace.WriteLine("Another instance of the script is already running. Exiting.");
        KillDialog(dialogProcess);
        return 1;
    }
}

try
{
    // Lock
    File.WriteAllText(lockFilePath, DateTime.UtcNow.ToString("o"));

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
    var (installOutput, installExitCode) = RunNpmCommand(sourceDir, "install", dialogProcess);
    Trace.WriteLine("-----");

    if (installExitCode != 0 || HasErrorOrWarning(installOutput))
    {
        Trace.WriteLine("NPM Install failed");
        HoldDialog(dialogProcess);
        return 1;
    }

    // Run ESLint before build
    Trace.WriteLine("Running ESLint...");
    var (lintOutput, lintExitCode) = RunNpmCommand(sourceDir, "run lint", dialogProcess);
    Trace.WriteLine("-----");

    if (lintExitCode != 0 || lintOutput.Any(l => l.Contains("error", StringComparison.OrdinalIgnoreCase)))
    {
        Trace.WriteLine("ESLint found errors");
        HoldDialog(dialogProcess);
        return 1;
    }

    // Run build
    string buildCommand = configuration == "Release" ? "run releaseBuild" : "run debugBuild";
    var (buildOutput, buildExitCode) = RunNpmCommand(sourceDir, buildCommand, dialogProcess);
    Trace.WriteLine("-----");

    if (buildExitCode != 0 || HasErrorOrWarning(buildOutput))
    {
        HoldDialog(dialogProcess);
        return 1;
    }

    // Update build record on success
    SaveBuildRecord(recordFilePath, currentBranch);

    Trace.WriteLine("NPM Build Complete");
    KillDialog(dialogProcess);
    return 0;
}
catch (Exception ex)
{
    Trace.WriteLine("An error occurred in esBuild.cs");
    Trace.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
    HoldDialog(dialogProcess);
    return 1;
}
finally
{
    // Unlock
    if (File.Exists(lockFilePath))
    {
        File.Delete(lockFilePath);
    }
}

// Helper methods

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

static bool CheckIfNeedsBuild(string recordFilePath, string currentBranch, string scriptsDir, string outputDir)
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
            Trace.WriteLine("Output directory is not empty. Skipping build.");
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

static void CopyScriptsToPro(string coreScriptsDir, string proScriptsDir, bool verbose)
{
    Trace.WriteLine("Copying core Scripts to Pro Scripts directory...");
    if (!Directory.Exists(proScriptsDir))
    {
        Directory.CreateDirectory(proScriptsDir);
    }

    int copiedCount = 0;
    int skippedCount = 0;
    List<string> fileNames = [];

    foreach (string filePath in Directory.GetFiles(coreScriptsDir, "*.ts", SearchOption.AllDirectories))
    {
        string fileName = Path.GetFileName(filePath);
        fileNames.Add(fileName);
        string destinationPath = Path.Combine(proScriptsDir, fileName);

        if (!File.Exists(destinationPath))
        {
            File.Copy(filePath, destinationPath, true);
            copiedCount++;
            if (verbose)
            {
                Trace.WriteLine($"Copied new file: {fileName}");
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
                Trace.WriteLine($"Updated file: {fileName}");
            }
            copiedCount++;
        }
        else
        {
            skippedCount++;
        }
    }
    
    Trace.WriteLine($"Copied {copiedCount} files, skipped {skippedCount} files.");
}

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

static bool GetScriptsModifiedSince(string scriptsDir, long lastTimestamp)
{
    if (!Directory.Exists(scriptsDir))
    {
        return true; // Force rebuild if Scripts folder doesn't exist
    }

    var lastBuildTime = DateTimeOffset.FromUnixTimeMilliseconds(lastTimestamp).DateTime;

    foreach (string file in Directory.GetFiles(scriptsDir, "*", SearchOption.AllDirectories))
    {
        if (File.GetLastWriteTime(file) > lastBuildTime)
        {
            return true;
        }
    }

    return false;
}

static Process? StartConsoleDialog(string buildDir, string title)
{
    try
    {
        string consoleDialogPath = Path.Combine(buildDir, "ConsoleDialog.dll");
        if (!File.Exists(consoleDialogPath))
        {
            Trace.WriteLine($"ConsoleDialog.dll not found at {consoleDialogPath}");
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
            Trace.WriteLine("Failed to start console dialog. Exiting.");
        }
        else
        {
            dialog.StandardInput.AutoFlush = true;
            Trace.Listeners.Add(new DialogTraceListener(dialog));
        }

        return dialog;
    }
    catch (Exception ex)
    {
        Trace.WriteLine($"Failed to start ConsoleDialog: {ex.Message}");
        return null;
    }
}

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

static (List<string> Output, int ExitCode) RunNpmCommand(string workingDirectory, string command, Process? dialogProcess)
{
    var output = new List<string>();

    try
    {
        // Use pwsh (PowerShell 7) for cross-platform compatibility
        // This ensures proper shell resolution and avoids issues with multiple npm installations
        var psi = new ProcessStartInfo
        {
            FileName = "pwsh",
            Arguments = $"-NoProfile -Command \"npm {command}\"",
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(psi);
        if (process is null)
        {
            return (["Failed to start npm"], 1);
        }

        // Read output asynchronously
        process.OutputDataReceived += (sender, e) =>
        {
            if (e.Data is not null)
            {
                Trace.WriteLine(e.Data);
                output.Add(e.Data);
            }
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data is not null)
            {
                Trace.WriteLine(e.Data);
                output.Add(e.Data);
            }
        };

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit();

        return (output, process.ExitCode);
    }
    catch (Exception ex)
    {
        Trace.WriteLine($"Error running npm {command}: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
        output.Add(ex.Message);
        return (output, 1);
    }
}

static bool HasErrorOrWarning(List<string> output)
{
    return output.Any(line =>
        line.Contains("Error", StringComparison.OrdinalIgnoreCase) ||
        line.Contains("Warning", StringComparison.OrdinalIgnoreCase));
}

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

static void HoldDialog(Process? dialog)
{
    if (dialog?.StandardInput is not null && !dialog.HasExited)
    {
        dialog.StandardInput.WriteLine("NPM Install failed");
    }
}

public class DialogTraceListener(Process dialog) : TraceListener
{
    public override void Write(string? message)
    {
        if (dialog.StandardInput is null || dialog.HasExited)
        {
            return;
        }

        try
        {
            dialog.StandardInput.Write(message);
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
            dialog.StandardInput.WriteLine(message);
        }
        catch
        {
            // Dialog may have closed - ignore
        }
    }
}