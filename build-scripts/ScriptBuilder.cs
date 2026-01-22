#!/usr/bin/env dotnet

using System.Diagnostics;
using System.Runtime.CompilerServices;

// Builds all C# scripts in the current directory using dotnet build.
// Outputs built DLLs to ../build-tools/
// Usage: dotnet ScriptBuilder.cs
// Can also pass in script names to build specific scripts only:
// Usage: dotnet ScriptBuilder.cs Script1.cs Script2.cs ...
// or the --exclude option to skip specific scripts:
// Usage: dotnet ScriptBuilder.cs --exclude Script1.cs Script2.cs ...

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


static string GetScriptDirectory([CallerFilePath] string? callerFilePath = null)
{
    return Path.GetDirectoryName(callerFilePath) ?? Environment.CurrentDirectory;
}