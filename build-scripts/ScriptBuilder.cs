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
//
// Output:
//   Compiled DLLs are placed in GeoBlazor/build-tools/ directory
//
// Note: ScriptBuilder.cs itself is always skipped to avoid self-compilation issues.

using System.Diagnostics;
using System.Runtime.CompilerServices;

bool excludeMode = false;
HashSet<string> scriptsToProcess = new();
string scriptDir = GetScriptDirectory();
string outDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "build-tools"));

string[] scripts = Directory.GetFiles(scriptDir, "*.cs");

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();

    switch (arg)
    {
        case "--exclude":
            excludeMode = true;
            break;
        default:
            scriptsToProcess.Add(arg);
            break;
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
            Console.WriteLine($"Skipping excluded script: {Path.GetFileName(script)}");
            continue;
        }
        else if (!excludeMode && !scriptsToProcess.Contains(Path.GetFileName(script)))
        {
            Console.WriteLine($"Skipping unlisted script: {Path.GetFileName(script)}");
            continue;
        }
    }

    int returnCode = BuildScript(Path.GetFileName(script), scriptDir, outDir);
    if (returnCode != 0)
    {
        return returnCode;
    }
}

return 0;



/// <summary>
/// Compiles a single C# script to a DLL using 'dotnet build'.
/// </summary>
/// <param name="scriptName">The name of the script file (e.g., "ESBuild.cs").</param>
/// <param name="scriptDir">The directory containing the script.</param>
/// <param name="outDir">The output directory for the compiled DLL.</param>
/// <returns>0 on success, non-zero on failure.</returns>
static int BuildScript(string scriptName, string scriptDir, string outDir)
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
        WorkingDirectory = scriptDir,
        RedirectStandardInput = true,
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    
    using Process? process = Process.Start(psi);
    if (process is null)
    {
        Console.WriteLine($"Failed to build {scriptName}");
        return 1;
    }

    // Read output asynchronously
    process.OutputDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.ErrorDataReceived += (sender, e) =>
    {
        if (e.Data is not null)
        {
            Console.WriteLine(e.Data);
        }
    };

    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    process.WaitForExit();
    return process.ExitCode;
}


/// <summary>
/// Gets the directory containing this script file.
/// Uses [CallerFilePath] to resolve the path at compile time.
/// </summary>
/// <param name="callerFilePath">Automatically populated with the source file path.</param>
/// <returns>The directory path containing this script.</returns>
static string GetScriptDirectory([CallerFilePath] string? callerFilePath = null)
{
    return Path.GetDirectoryName(callerFilePath) ?? Environment.CurrentDirectory;
}