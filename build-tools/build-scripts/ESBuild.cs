#!/usr/bin/env dotnet
#:project ../utilities/Utilities.csproj

// ESBuild TypeScript -> JavaScript Compilation Script
// C# file-based app version of esBuild.ps1
// Usage: dotnet esBuild.cs [options]
//   -c, --configuration <Debug|Release>  Build configuration (default: Debug)
//   -f, --force                          Force rebuild, ignoring lock files and record
//   -p, --pro                            Run the GeoBlazor Pro ESBuild process
//   -pc, --prooncorechange               Run the GeoBlazor Pro ESBuild process if pro OR core files have changed
//   -ninst, --noinstall                  Skip npm install step
//   -nl, --nolint                        Skip ESLint step
//   -v, --verbose                        Enable verbose logging
//   -w, --watch                          Run esbuild in watch mode (rebuild on changes)
//   -h, --help                           Display help message

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Utilities;

// Get the actual script location using CallerFilePath (resolved at compile time)
string scriptDir = PathFinder.GetScriptsDirectory();

// Parse command line arguments
string configuration = Environment.GetEnvironmentVariable("Configuration") ?? "Debug";
bool force = false;
bool help = false;
bool pro = false;
bool proOnCoreChange = false;
bool verbose = false;
bool lint = true;
bool install = true;
bool watch = false;

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
        case "-nl":
        case "--nolint":
            lint = false;
            break;
        case "-ninst":
        case "--noinstall":
            install = false;
            break;
        case "-w":
        case "--watch":
            watch = true;
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
    Trace.WriteLine("  -nl, --nolint                        Skip ESLint step");
    Trace.WriteLine("  -ninst, --noinstall                  Skip npm install step");
    Trace.WriteLine("  -v, --verbose                        Enable verbose logging");
    Trace.WriteLine("  -w, --watch                          Run esbuild in watch mode (rebuild on changes)");
    Trace.WriteLine("  -h, --help                           Display this help message");
    
    return 0;
}

if (verbose)
{
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

// Read the current record before the build — its timestamp becomes the "previous" after this build
var preBuildRecord = GetLastBuildRecord(recordFilePath);

if (!force)
{
    bool needsBuild = CheckIfNeedsBuild(
        recordFilePath,
        currentBranch,
        scriptsDir, outputDir, pro ? "PRO" : "CORE");

    if (!needsBuild && pro && proOnCoreChange)
    {
        needsBuild = CheckIfNeedsBuild(coreRecordFilePath,
            currentBranch, coreScriptsDir, coreOutputDir, "PRO");
    }

    if (!needsBuild)
    {
        Environment.Exit(0);
    }
}

if (!verbose)
{
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

    if (install)
    {
        // npm install
        await ProcessRunner.RunNpmCommand(sourceDir, "install");
        Trace.WriteLine("-----");
    }

    if (lint)
    {
        Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: Running ESLint...");
        await ProcessRunner.RunNpmCommand(sourceDir, "run lint");
        Trace.WriteLine("-----");
    }

    // Run build
    string buildCommand = configuration == "Release" ? "run releaseBuild" : "run debugBuild";
    await ProcessRunner.RunNpmCommand(sourceDir, buildCommand);
    Trace.WriteLine("-----");

    // Clean up old chunk files — only delete files older than the PREVIOUS build.
    // Files from the most recent build must be preserved because MSBuild has already
    // cataloged them as static web assets before ESBuild runs (dotnet/sdk#49988).
    CleanupOldChunks(outputDir, preBuildRecord.PreviousTimestamp, pro ? "PRO" : "CORE", verbose);

    // Update build record: current timestamp becomes "previous" for the next build
    SaveBuildRecord(recordFilePath, currentBranch, preBuildRecord.Timestamp);

    Trace.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: NPM Build Complete");

    if (watch)
    {
        await RunWatchLoop(pro, sourceDir, coreScriptsDir, proScriptsDir, scriptsDir, buildCommand, verbose);
    }

    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"ESBUILD {(pro ? "PRO" : "CORE")}: An error occurred in esBuild.cs");
    Console.Error.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
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
static BuildRecord GetLastBuildRecord(string recordFilePath)
{
    if (!File.Exists(recordFilePath))
    {
        return new BuildRecord();
    }

    try
    {
        string json = File.ReadAllText(recordFilePath);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        long timestamp = root.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;
        long previousTimestamp = root.TryGetProperty("previousTimestamp", out var pts) ? pts.GetInt64() : 0;
        string branch = root.TryGetProperty("branch", out var br) ? br.GetString() ?? "unknown" : "unknown";

        return new BuildRecord(timestamp, previousTimestamp, branch);
    }
    catch
    {
        return new BuildRecord();
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
    string sourceProject)
{
    // Check if build is needed
    BuildRecord lastBuild = GetLastBuildRecord(recordFilePath);
    bool branchChanged = currentBranch != "no-git" 
        && currentBranch != lastBuild.Branch;

    if (branchChanged)
    {
        Trace.WriteLine($"ESBUILD {sourceProject}: Git branch changed from \"{lastBuild.Branch}\" to \"{currentBranch}\". Rebuilding...");
        return true;
    }

    if (lastBuild.Timestamp > DateTimeOffset.UtcNow.AddMinutes(-1).ToUnixTimeMilliseconds())
    {
        // we just built this, possible if ESBuild gets triggered multiple times in a single run
        Trace.WriteLine($"ESBUILD {sourceProject}: Was built within the past 1 minute, will skip this build.");
        return false;
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
            proPrefixedFiles.Add(fileName);
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
        if (proPrefixedFiles.Contains(Path.GetFileNameWithoutExtension(filePath)))
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

        if (sourceDate > destDate
            // verify that the source isn't a placeholder file
            && File.ReadLines(filePath).FirstOrDefault()?.Contains("// PLACEHOLDER FOR GEOBLAZOR PRO IMPLEMENTATION") != true)
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
    
    // update arcGisJsInterop references to pro_ prefixed scripts
    string arcGisJsInteropPath = Path.Combine(proScriptsDir, "arcGisJsInterop.ts");
    string proArcGisJsInterop = File.ReadAllText(arcGisJsInteropPath);

    foreach (string proFile in proPrefixedFiles)
    {
        proArcGisJsInterop = proArcGisJsInterop.Replace($"\"./{proFile}\"", $"\"./pro_{proFile}\"");
    }
    
    File.WriteAllText(arcGisJsInteropPath, proArcGisJsInterop);
    
    Trace.WriteLine($"ESBUILD PRO: Copied {copiedCount} files, skipped {skippedCount} files.");
}

/// <summary>
/// Watches the active project's Scripts directory (and Core's, when building Pro) for
/// TypeScript changes, debounces bursts of events from a single save, and re-runs the
/// npm build on every settled change. Watchers are paused during the rebuild itself so
/// that the Pro CopyScriptsToPro step does not feedback-trigger another rebuild.
/// Blocks until Ctrl+C.
/// </summary>
static async Task RunWatchLoop(
    bool pro,
    string sourceDir,
    string coreScriptsDir,
    string proScriptsDir,
    string scriptsDir,
    string buildCommand,
    bool verbose)
{
    string label = pro ? "PRO" : "CORE";
    Trace.WriteLine("-----");
    Trace.WriteLine($"ESBUILD {label}: Watching for changes in Scripts folders. Press Ctrl+C to stop.");

    using var rebuildSignal = new SemaphoreSlim(0, int.MaxValue);
    using var cts = new CancellationTokenSource();

    ConsoleCancelEventHandler cancelHandler = (_, e) =>
    {
        Trace.WriteLine($"ESBUILD {label}: Stop requested, exiting watch loop...");
        cts.Cancel();
        e.Cancel = true;
    };
    Console.CancelKeyPress += cancelHandler;

    var watchers = new List<FileSystemWatcher>();

    FileSystemWatcher CreateWatcher(string dir)
    {
        var w = new FileSystemWatcher(dir)
        {
            IncludeSubdirectories = true,
            Filter = "*.ts",
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size
        };
        w.Changed += (_, _) => rebuildSignal.Release();
        w.Created += (_, _) => rebuildSignal.Release();
        w.Deleted += (_, _) => rebuildSignal.Release();
        w.Renamed += (_, _) => rebuildSignal.Release();
        w.Error += (_, args) =>
            Trace.WriteLine($"ESBUILD {label}: Watcher error on {dir}: {args.GetException().Message}");
        w.EnableRaisingEvents = true;
        return w;
    }

    if (Directory.Exists(scriptsDir))
    {
        watchers.Add(CreateWatcher(scriptsDir));
        Trace.WriteLine($"ESBUILD {label}: Watching {scriptsDir}");
    }

    if (pro && Directory.Exists(coreScriptsDir) &&
        !string.Equals(Path.GetFullPath(coreScriptsDir), Path.GetFullPath(scriptsDir), StringComparison.OrdinalIgnoreCase))
    {
        watchers.Add(CreateWatcher(coreScriptsDir));
        Trace.WriteLine($"ESBUILD {label}: Watching {coreScriptsDir}");
    }

    const int debounceMs = 500;

    try
    {
        while (!cts.IsCancellationRequested)
        {
            await rebuildSignal.WaitAsync(cts.Token);

            // Debounce — keep draining for `debounceMs` of quiet
            while (true)
            {
                await Task.Delay(debounceMs, cts.Token);
                bool drained = false;
                while (rebuildSignal.Wait(0)) { drained = true; }
                if (!drained) break;
            }

            // Pause watchers — the rebuild itself (esp. CopyScriptsToPro) will touch files we watch
            foreach (var w in watchers) w.EnableRaisingEvents = false;

            try
            {
                Trace.WriteLine($"ESBUILD {label}: Change detected, rebuilding...");
                if (pro)
                {
                    CopyScriptsToPro(coreScriptsDir, proScriptsDir, verbose);
                }
                await ProcessRunner.RunNpmCommand(sourceDir, buildCommand);
                Trace.WriteLine($"ESBUILD {label}: Rebuild complete. Watching...");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ESBUILD {label}: Rebuild failed: {ex.Message}");
                Trace.WriteLine($"ESBUILD {label}: Watching for next change...");
            }
            finally
            {
                // Settle, drain any events from the rebuild, then resume
                try { await Task.Delay(200, cts.Token); } catch (OperationCanceledException) { }
                while (rebuildSignal.Wait(0)) { }
                foreach (var w in watchers) w.EnableRaisingEvents = true;
            }
        }
    }
    catch (OperationCanceledException)
    {
        // Ctrl+C — fall through to cleanup
    }
    finally
    {
        Console.CancelKeyPress -= cancelHandler;
        foreach (var w in watchers) w.Dispose();
    }
}

/// <summary>
/// Saves the build record to a JSON file after a successful build.
/// Records the current timestamp, previous timestamp, and branch name.
/// The previous timestamp is used by cleanup to identify files safe to delete — only files
/// older than the PREVIOUS build are removed, so that files MSBuild already cataloged
/// (from the most recent build) are preserved. This avoids the dotnet/sdk#49988 race condition.
/// </summary>
/// <param name="recordFilePath">Path where the record should be saved.</param>
/// <param name="branch">The current Git branch name.</param>
/// <param name="previousTimestamp">The timestamp from the prior build record (shifted to previousTimestamp).</param>
static void SaveBuildRecord(string recordFilePath, string branch, long previousTimestamp)
{
    // buffer 30 seconds into the future to avoid edge cases
    long timestamp = DateTimeOffset.UtcNow.AddSeconds(30).ToUnixTimeMilliseconds();
    // Write JSON manually to avoid reflection-based serialization (not compatible with Native AOT)
    string json = $$"""
        {
          "timestamp": {{timestamp}},
          "previousTimestamp": {{previousTimestamp}},
          "branch": "{{branch.Replace("\\", "\\\\").Replace("\"", "\\\"")}}"
        }
        """;
    File.WriteAllText(recordFilePath, json);
}

/// <summary>
/// Deletes old chunk files from the output directory that predate the previous build.
/// Keeps files from the current build and the immediately preceding build intact.
/// This addresses the accumulation of hashed chunk files from esbuild code splitting
/// without triggering the MSBuild static web asset fingerprinting race condition
/// (dotnet/sdk#49988), since only files from 2+ builds ago are removed.
/// </summary>
/// <param name="outputDir">Path to the wwwroot/js output directory.</param>
/// <param name="previousTimestamp">Timestamp of the build before the most recent one (cutoff for deletion).</param>
/// <param name="proOrCore">Label for log messages ("PRO" or "CORE").</param>
/// <param name="verbose">If true, logs each deleted file.</param>
static void CleanupOldChunks(string outputDir, long previousTimestamp, string proOrCore, bool verbose)
{
    if (previousTimestamp <= 0)
    {
        Trace.WriteLine($"ESBUILD {proOrCore}: No previous build record for cleanup (need 3+ builds). Skipping.");
        return;
    }

    if (!Directory.Exists(outputDir))
    {
        return;
    }

    var cutoffTime = DateTimeOffset.FromUnixTimeMilliseconds(previousTimestamp).UtcDateTime;
    int deletedCount = 0;
    long freedBytes = 0;
    int errorCount = 0;

    // esbuild chunk files have an 8-char uppercase alphanumeric hash before the extension,
    // e.g. core_AreaMeasurement2D_LJWIAPAM.js / core_AreaMeasurement2D_LJWIAPAM.js.map
    // Non-chunk files like geoBlazorCore.js do NOT have this pattern and must be preserved.
    var chunkHashPattern = new Regex(@"_[A-Z0-9]{8}\.js(\.map)?$", RegexOptions.Compiled);

    foreach (string file in Directory.GetFiles(outputDir, "*.js*", SearchOption.TopDirectoryOnly))
    {
        if (!chunkHashPattern.IsMatch(Path.GetFileName(file)))
        {
            continue;
        }

        try
        {
            var lastWrite = File.GetLastWriteTimeUtc(file);
            if (lastWrite < cutoffTime)
            {
                long size = new FileInfo(file).Length;
                File.Delete(file);
                deletedCount++;
                freedBytes += size;
                if (verbose)
                {
                    Trace.WriteLine($"ESBUILD {proOrCore}: Deleted old chunk: {Path.GetFileName(file)}");
                }
            }
        }
        catch (Exception ex)
        {
            errorCount++;
            if (verbose)
            {
                Trace.WriteLine($"ESBUILD {proOrCore}: Failed to delete {Path.GetFileName(file)}: {ex.Message}");
            }
        }
    }

    if (deletedCount > 0)
    {
        double freedMB = freedBytes / (1024.0 * 1024.0);
        Trace.WriteLine($"ESBUILD {proOrCore}: Cleaned up {deletedCount} old chunk files ({freedMB:F1}MB freed).");
    }
    else
    {
        Trace.WriteLine($"ESBUILD {proOrCore}: No old chunks to clean up.");
    }

    if (errorCount > 0)
    {
        Trace.WriteLine($"ESBUILD {proOrCore}: {errorCount} files could not be deleted (may be locked).");
    }
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

record BuildRecord(long Timestamp = 0, long PreviousTimestamp = 0, string Branch = "unknown");