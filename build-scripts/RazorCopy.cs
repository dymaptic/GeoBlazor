#!/usr/bin/env dotnet

// RazorCopy Script
// Copies .razor sample files from Core and Pro to the docs/assets/samples folder as .txt files
//
// Usage: dotnet RazorCopy.cs
//   -h, --help    Display help message
//   -v, --verbose Show detailed output

using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// Parse command line arguments
bool help = args.Any(a => a is "-h" or "--help");
bool verbose = args.Any(a => a is "-v" or "--verbose");

if (help)
{
    Console.WriteLine("RazorCopy Script");
    Console.WriteLine("Copies .razor sample files from Core and Pro to the docs/assets/samples folder as .txt files.");
    Console.WriteLine("Excludes files starting with 'CustomerTests'.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet RazorCopy.cs");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -h, --help     Display this help message");
    Console.WriteLine("  -v, --verbose  Show detailed output");
    return 0;
}

string scriptDir = GetScriptsDirectory();

// Define paths relative to script location (build-scripts folder)
// Script is in: GeoBlazor.Pro/GeoBlazor/build-scripts/
// Core pages:   GeoBlazor.Pro/GeoBlazor/samples/dymaptic.GeoBlazor.Core.Sample.Shared/Pages/
// Pro pages:    GeoBlazor.Pro/samples/dymaptic.GeoBlazor.Pro.Sample.Shared/Pages/
// Save path:    GeoBlazor.Pro/docs/assets/samples/

string corePagesPath = Path.GetFullPath(Path.Combine(scriptDir, "..", "samples", "dymaptic.GeoBlazor.Core.Sample.Shared", "Pages"));
string proPagesPath = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "samples", "dymaptic.GeoBlazor.Pro.Sample.Shared", "Pages"));
string savePath = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "docs", "assets", "samples"));

if (verbose)
{
    Console.WriteLine($"Core pages path: {corePagesPath}");
    Console.WriteLine($"Pro pages path:  {proPagesPath}");
    Console.WriteLine($"Save path:       {savePath}");
    Console.WriteLine();
}

// Ensure save directory exists
if (!Directory.Exists(savePath))
{
    Directory.CreateDirectory(savePath);
    if (verbose)
    {
        Console.WriteLine($"Created directory: {savePath}");
    }
}
else
{
    // Clear existing .txt files
    var existingFiles = Directory.GetFiles(savePath, "*.txt");
    foreach (string file in existingFiles)
    {
        File.Delete(file);
        if (verbose)
        {
            Console.WriteLine($"Deleted existing file: {Path.GetFileName(file)}");
        }
    }
}

int copiedCount = 0;

// Copy Pro pages
if (Directory.Exists(proPagesPath))
{
    copiedCount += CopyRazorFiles(proPagesPath, savePath, "Pro", verbose);
}
else
{
    Console.WriteLine($"Warning: Pro pages directory not found: {proPagesPath}");
}

// Copy Core pages
if (Directory.Exists(corePagesPath))
{
    copiedCount += CopyRazorFiles(corePagesPath, savePath, "Core", verbose);
}
else
{
    Console.WriteLine($"Warning: Core pages directory not found: {corePagesPath}");
}

Console.WriteLine($"Copied {copiedCount} razor file(s) to {savePath}");
return 0;

// Helper methods
static int CopyRazorFiles(string sourcePath, string destPath, string label, bool verbose)
{
    int count = 0;
    string[] excludePatterns =
    [
        "CustomerTests.razor.*",
        "^Home.razor.*",
        "^SourceCode.razor.*",
        "^Test.razor.*",
        "^Tests.razor.*",
        @"^[A-Za-z\.]+\.css$"
    ];
    var razorFiles = Directory.GetFiles(sourcePath, "*.razor*")
        .Where(f => !excludePatterns.Any(p => Regex.Match(Path.GetFileName(f), p).Success))
        .ToArray();

    foreach (string file in razorFiles)
    {
        string fileName = Path.GetFileName(file);
        string destFile = Path.Combine(destPath, fileName + ".txt");

        try
        {
            File.Copy(file, destFile, overwrite: true);
            count++;
            if (verbose)
            {
                Console.WriteLine($"[{label}] Copied: {fileName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to copy {fileName}: {ex.Message}");
        }
    }

    return count;
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
    string parent = Path.GetDirectoryName(dllDirectory)!;
    while (Path.GetFileName(parent) != "GeoBlazor")
    {
        parent = Path.GetDirectoryName(parent)!;
    }
    return Path.Combine(parent!, "build-scripts");
}
