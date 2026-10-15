#!/usr/bin/env dotnet
#:property PublishAot=false
#:project ../../../build-tools/utilities/Utilities.csproj

// Build Templates Script
// C# file-based app version of buildTemplates.ps1
// Updates and builds GeoBlazor project templates
//
// Usage: dotnet BuildTemplates.cs [options]
//   -i, --install                      Install templates after building
//   -c, --core-version <version>       Override Core version (default: read from Directory.Build.props)
//   -p, --pro-version <version>        Override Pro version (default: read from Directory.Build.props)
//   -t, --templates-dir <path>         Templates directory (default: auto-detect from script location)
//   -bl --binlog <path>                Path to save binary log of the build process (default: none)
//   -h, --help                         Display help message
//
// Example:
//   dotnet BuildTemplates.cs
//   dotnet BuildTemplates.cs -i
//   dotnet BuildTemplates.cs -c 5.0.0 -p 5.0.0 -i

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Utilities;

// Target frameworks to support
int[] targetFrameworks = [8, 9, 10];

// Package definitions
string[] packages =
[
    "Microsoft.Maui.Controls",
    "Microsoft.AspNetCore.Components.WebView.Maui",
    "Microsoft.Extensions.Configuration.Abstractions",
    "Microsoft.Extensions.Logging.Debug",
    "Microsoft.AspNetCore.Components.Web",
    "Microsoft.AspNetCore.Components.WebAssembly.Server",
    "Microsoft.AspNetCore.Components.WebAssembly",
    "Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore",
    "Microsoft.AspNetCore.Identity.EntityFrameworkCore",
    "Microsoft.EntityFrameworkCore.Tools",
    "Microsoft.EntityFrameworkCore.SqlServer",
    "Microsoft.AspNetCore.Components.WebAssembly.Authentication",
    "Microsoft.AspNetCore.Components.WebAssembly.DevServer",
    "Microsoft.Authentication.WebAssembly.Msal"
];

// Package to symbol name mapping
Dictionary<string, string> packageToSymbol = new()
{
    ["Microsoft.Maui.Controls"] = "MauiControls",
    ["Microsoft.AspNetCore.Components.WebView.Maui"] = "WebViewMaui",
    ["Microsoft.Extensions.Configuration.Abstractions"] = "ConfigurationAbstractions",
    ["Microsoft.Extensions.Logging.Debug"] = "LoggingDebug",
    ["Microsoft.AspNetCore.Components.Web"] = "ComponentsWeb",
    ["Microsoft.AspNetCore.Components.WebAssembly.Server"] = "WebAssemblyServer",
    ["Microsoft.AspNetCore.Components.WebAssembly"] = "ComponentsWebAssembly",
    ["Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore"] = "DiagnosticsEntityFrameworkCore",
    ["Microsoft.AspNetCore.Identity.EntityFrameworkCore"] = "IdentityEntityFrameworkCore",
    ["Microsoft.EntityFrameworkCore.Tools"] = "EntityFrameworkCoreTools",
    ["Microsoft.EntityFrameworkCore.SqlServer"] = "EntityFrameworkCoreSqlServer",
    ["Microsoft.AspNetCore.Components.WebAssembly.Authentication"] = "WebAssemblyAuthentication",
    ["Microsoft.AspNetCore.Components.WebAssembly.DevServer"] = "WebAssemblyDevServer",
    ["Microsoft.Authentication.WebAssembly.Msal"] = "WebAssemblyMsal"
};

// Parse command line arguments
bool install = false;
string? coreVersionOverride = null;
string? proVersionOverride = null;
string? templatesDirOverride = null;
bool help = false;
bool binlog = false;

for (int i = 0; i < args.Length; i++)
{
    string arg = args[i].ToLowerInvariant();
    switch (arg)
    {
        case "-i":
        case "--install":
            install = true;
            break;
        case "-bl":
        case "--binlog":
            binlog = true;
            break;
        case "-c":
        case "--core-version":
            if (i + 1 < args.Length)
            {
                coreVersionOverride = args[++i];
            }
            break;
        case "-p":
        case "--pro-version":
            if (i + 1 < args.Length)
            {
                proVersionOverride = args[++i];
            }
            break;
        case "-t":
        case "--templates-dir":
            if (i + 1 < args.Length)
            {
                templatesDirOverride = args[++i];
            }
            break;
        case "-h":
        case "--help":
            help = true;
            break;
    }
}

if (help)
{
    Console.WriteLine("Build Templates Script");
    Console.WriteLine("Updates and builds GeoBlazor project templates.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet BuildTemplates.cs [options]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -i, --install                      Install templates after building");
    Console.WriteLine("  -c, --core-version <version>       Override Core version");
    Console.WriteLine("  -p, --pro-version <version>        Override Pro version");
    Console.WriteLine("  -t, --templates-dir <path>         Templates directory path");
    Console.WriteLine("  -h, --help                         Display this help message");
    Console.WriteLine();
    Console.WriteLine("Examples:");
    Console.WriteLine("  dotnet BuildTemplates.cs");
    Console.WriteLine("  dotnet BuildTemplates.cs -i");
    Console.WriteLine("  dotnet BuildTemplates.cs -c 5.0.0 -p 5.0.0 -i");
    return 0;
}

string scriptDir = PathFinder.GetScriptsDirectory();

// Scripts are in pro/build-tools/build-scripts
// Templates are in pro/templates
// Core lives at the repository root, one level above pro/
string templatesDir = templatesDirOverride ?? Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "templates"));
string coreProjectDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "..", "src", "dymaptic.GeoBlazor.Core"));
string proProjectDir = Path.GetFullPath(Path.Combine(scriptDir, "..", "..", "src", "dymaptic.GeoBlazor.Pro"));

if (!Directory.Exists(templatesDir))
{
    Console.Error.WriteLine($"Error: Templates directory not found at {templatesDir}");
    return 1;
}

// Determine versions
string coreVersion = coreVersionOverride ?? string.Empty;
string proVersion = proVersionOverride ?? string.Empty;

if (string.IsNullOrEmpty(coreVersion) || string.IsNullOrEmpty(proVersion))
{
    string buildPropsPath = Path.Combine(templatesDir, "..", "Directory.Build.props");
    if (!File.Exists(buildPropsPath))
    {
        Console.Error.WriteLine($"Error: Directory.Build.props not found at {buildPropsPath}");
        return 1;
    }

    var buildProps = XDocument.Load(buildPropsPath);
    string? propsVersion = buildProps.Descendants("ProVersion").FirstOrDefault()?.Value;

    if (string.IsNullOrEmpty(propsVersion))
    {
        Console.Error.WriteLine("Error: Could not read ProVersion from Directory.Build.props");
        return 1;
    }

    // Use ProVersion for both Core and Pro (intentional - they should match for production releases)
    if (string.IsNullOrEmpty(coreVersion))
    {
        coreVersion = propsVersion;
    }
    if (string.IsNullOrEmpty(proVersion))
    {
        proVersion = propsVersion;
    }
}

Console.WriteLine("Updating GeoBlazor Templates");
Console.WriteLine($"- Using Core Version: {coreVersion}");
Console.WriteLine($"- Using Pro Version: {proVersion}");
Console.WriteLine();

int step = 1;
DateTime stepStartTime = DateTime.Now;

GbCli.WriteStepHeader(step, "Updating project references in .csproj files");

// Find all .csproj files in content folder
string contentDir = Path.Combine(templatesDir, "content");
string[] projectFiles = Directory.GetFiles(contentDir, "*.csproj", SearchOption.AllDirectories);

// Use a 3-piece version for the package ref to make sure it references an actually deployed nuget version
string packageVersion = Regex.Replace(proVersion, @"^(\d+\.\d+\.\d+)\.\d+(.*)$", "$1$2");

foreach (string projectFile in projectFiles)
{
    string content = File.ReadAllText(projectFile);
    string originalContent = content;

    // Update GeoBlazor Core and Pro versions
    content = Regex.Replace(content,
        @"<PackageReference Include=""dymaptic\.GeoBlazor\.Core"" Version=""[^""]*""",
        $"<PackageReference Include=\"dymaptic.GeoBlazor.Core\" Version=\"{packageVersion}\"");
    content = Regex.Replace(content,
        @"<PackageReference Include=""dymaptic\.GeoBlazor\.Pro"" Version=""[^""]*""",
        $"<PackageReference Include=\"dymaptic.GeoBlazor.Pro\" Version=\"{packageVersion}\"");

    if (content != originalContent)
    {
        // Remove trailing newlines
        content = Regex.Replace(content, @"(\r?\n)*\z", "");
        File.WriteAllText(projectFile, content);
        Console.WriteLine($"  Updated: {Path.GetFileName(projectFile)}");
    }
}

GbCli.WriteStepCompleted(step++, stepStartTime);

step++;
stepStartTime = DateTime.Now;

GbCli.WriteStepHeader(step, "Fetching package versions from NuGet and updating template.json files");

var packageVersionsCache = new Dictionary<string, Dictionary<int, string?>>();
using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("User-Agent", "GeoBlazor-Build-Script");

foreach (string package in packages)
{
    try
    {
        Console.WriteLine($"Getting versions for {package}...");
        var versions = await GetPackageVersionsAsync(httpClient, package, targetFrameworks);
        packageVersionsCache[package] = versions;
        foreach (int tf in targetFrameworks)
        {
            Console.WriteLine($"  Found: net{tf}.0 = {versions[tf] ?? "(none)"}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting versions for package {package}: {ex.Message}");
    }
}

GbCli.WriteStepCompleted(step, stepStartTime);

step++;
stepStartTime = DateTime.Now;

GbCli.WriteStepHeader(step, "Updating template.json files with latest package versions");

var templateConfigDirs = Directory.GetDirectories(contentDir, ".template.config", SearchOption.AllDirectories);
foreach (string configDir in templateConfigDirs)
{
    string templateJsonPath = Path.Combine(configDir, "template.json");
    if (!File.Exists(templateJsonPath))
    {
        continue;
    }

    Console.WriteLine($"Processing {templateJsonPath}");

    string jsonText = File.ReadAllText(templateJsonPath);
    bool modified = false;

    // Parse JSON as mutable DOM
    JsonNode? rootNode = JsonNode.Parse(jsonText, documentOptions: new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
    if (rootNode is not JsonObject root)
    {
        Console.WriteLine("  Failed to parse JSON, skipping");
        continue;
    }

    JsonObject? symbols = root["symbols"]?.AsObject();
    if (symbols is null)
    {
        Console.WriteLine("  No symbols section found, skipping");
        continue;
    }

    int latestTf = targetFrameworks[^1];

    // 1. Handle Framework symbol - add missing choices and update default
    JsonObject? frameworkSymbol = symbols["Framework"]?.AsObject();
    if (frameworkSymbol is not null)
    {
        // Add missing framework choices
        JsonArray? choices = frameworkSymbol["choices"]?.AsArray();
        if (choices is not null)
        {
            foreach (int tf in targetFrameworks)
            {
                string choiceValue = $"net{tf}.0";
                bool exists = choices.Any(c => c?["choice"]?.GetValue<string>() == choiceValue);
                if (!exists)
                {
                    choices.Add(new JsonObject { ["choice"] = choiceValue });
                    modified = true;
                    Console.WriteLine($"  Added missing framework choice: {choiceValue}");
                }
            }
        }

        // Update default framework to latest
        string? currentDefault = frameworkSymbol["defaultValue"]?.GetValue<string>();
        string newDefault = $"net{latestTf}.0";
        if (currentDefault != newDefault)
        {
            frameworkSymbol["defaultValue"] = newDefault;
            modified = true;
            Console.WriteLine($"  Updated default framework to {newDefault}");
        }
    }

    // 2. Update package versions in cases for each package symbol
    foreach (string package in packages)
    {
        if (!packageToSymbol.TryGetValue(package, out string? symbolName))
        {
            continue;
        }

        var versions = packageVersionsCache.GetValueOrDefault(package);
        if (versions is null)
        {
            continue;
        }

        // Check if this symbol exists in the template
        JsonObject? packageSymbol = symbols[symbolName]?.AsObject();
        if (packageSymbol is null)
        {
            continue;
        }

        // Get the cases array from parameters
        JsonObject? parameters = packageSymbol["parameters"]?.AsObject();
        if (parameters is null)
        {
            continue;
        }

        JsonArray? cases = parameters["cases"]?.AsArray();
        if (cases is null)
        {
            continue;
        }

        foreach (int tf in targetFrameworks)
        {
            string? version = versions[tf];
            if (version is null)
            {
                continue;
            }

            string condition = $"(Framework == \"net{tf}.0\")";

            // Find existing case for this framework
            JsonObject? existingCase = null;
            foreach (var caseNode in cases)
            {
                if (caseNode is JsonObject caseObj &&
                    caseObj["condition"]?.GetValue<string>()?.Contains($"net{tf}.0") == true)
                {
                    existingCase = caseObj;
                    break;
                }
            }

            if (existingCase is not null)
            {
                // Update existing case value
                string? currentValue = existingCase["value"]?.GetValue<string>();
                if (currentValue != version)
                {
                    existingCase["value"] = version;
                    modified = true;
                    Console.WriteLine($"  Updated {symbolName} for net{tf}.0 to {version}");
                }
            }
            else
            {
                // Add new case for this framework
                var newCase = new JsonObject
                {
                    ["condition"] = condition,
                    ["value"] = version
                };
                cases.Add(newCase);
                modified = true;
                Console.WriteLine($"  Added {symbolName} case for net{tf}.0 with version {version}");
            }
        }
    }

    if (modified)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        File.WriteAllText(templateJsonPath, rootNode.ToJsonString(options));
        Console.WriteLine($"  Saved changes to {Path.GetFileName(templateJsonPath)}");
    }
    else
    {
        Console.WriteLine($"  No changes needed");
    }
}

GbCli.WriteStepCompleted(step, stepStartTime);

step++;
stepStartTime = DateTime.Now;

GbCli.WriteStepHeader(step, "Updating .razor files in content with those from Pages folder");

string pagesDir = Path.Combine(templatesDir, "Pages");
if (Directory.Exists(pagesDir))
{
    string[] razorFiles = Directory.GetFiles(pagesDir, "*.razor");
    foreach (string razorFile in razorFiles)
    {
        string fileName = Path.GetFileName(razorFile);
        string[] matchingContentFiles = Directory.GetFiles(contentDir, fileName, SearchOption.AllDirectories);
        foreach (string destFile in matchingContentFiles)
        {
            File.Copy(razorFile, destFile, true);
            Console.WriteLine($"  Copied {fileName} to {Path.GetRelativePath(templatesDir, destFile)}");
        }
    }
}
else
{
    Console.WriteLine("  Pages folder not found, skipping razor file copy");
}

GbCli.WriteStepCompleted(step, stepStartTime);

step++;
stepStartTime = DateTime.Now;

GbCli.WriteStepHeader(step, "Building GeoBlazor Templates project");

string templateProjectPath = Path.Combine(templatesDir, "dymaptic.GeoBlazor.Templates.csproj");

// add ESBuild lock files to prevent from running ESBuild, which we don't need for the templates
string esBuildLockFilePath = Path.Combine(coreProjectDir, "esBuild.lock");
File.WriteAllText(esBuildLockFilePath, DateTime.Now.ToString("o"));
string esBuildProLockFilePath = Path.Combine(proProjectDir, "esBuild.lock");
File.WriteAllText(esBuildProLockFilePath, DateTime.Now.ToString("o"));

List<string> templatesArgs = 
[
    templateProjectPath, "-c", "Release",
    $"/p:ProVersion={proVersion}",
    "/p:GenerateDocs=false",
    "/p:GenerateXmlComments=false",
    "/p:GeneratePackage=false"
];

if (binlog)
{
    templatesArgs.Add($"-bl:\"{Path.Combine(templatesDir, "build.binlog")}\"");
}

await ProcessRunner.RunDotnetCommand(templatesDir, "build", args: templatesArgs);

GbCli.WriteStepCompleted(step, stepStartTime);



// Install templates if requested
if (install)
{
    step++;
    stepStartTime = DateTime.Now;
    
    GbCli.WriteStepHeader(step, "Installing GeoBlazor Templates");

    try
    {
        await ProcessRunner.RunDotnetCommand(templatesDir, "new", args: ["uninstall", "dymaptic.GeoBlazor.Templates"]);
    }
    catch
    {
        // ok if it wasn't installed yet
    }

    string binDir = Path.Combine(templatesDir, "bin", "Release");
    string packageName = $"dymaptic.GeoBlazor.Templates.{proVersion}.nupkg";
    string packagePath = Path.Combine(binDir, packageName);

    if (!File.Exists(packagePath))
    {
        Console.Error.WriteLine($"Error: Package not found at {packagePath}");
        return 1;
    }

    await ProcessRunner.RunDotnetCommand(templatesDir, "new", args: ["install", packagePath]);

    GbCli.WriteStepCompleted(step, stepStartTime);
}

Console.WriteLine();
Console.WriteLine("Build templates completed successfully!");
return 0;

// Helper methods

static async Task<Dictionary<int, string?>> GetPackageVersionsAsync(
    HttpClient client, string packageName, int[] targetFrameworks)
{
    var result = new Dictionary<int, string?>();
    foreach (int tf in targetFrameworks)
    {
        result[tf] = null;
    }

    string nugetUrl = $"https://azuresearch-usnc.nuget.org/query?q={Uri.EscapeDataString(packageName)}&prerelease=false";
    string json = await client.GetStringAsync(nugetUrl);
    using var doc = JsonDocument.Parse(json);

    if (!doc.RootElement.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
    {
        return result;
    }

    // Find the package with exact ID match
    JsonElement? packageData = null;
    foreach (var item in data.EnumerateArray())
    {
        if (item.TryGetProperty("id", out var idProp) &&
            string.Equals(idProp.GetString(), packageName, StringComparison.OrdinalIgnoreCase))
        {
            packageData = item;
            break;
        }
    }

    if (packageData is null)
    {
        return result;
    }

    if (!packageData.Value.TryGetProperty("versions", out var versions))
    {
        return result;
    }

    foreach (int tf in targetFrameworks)
    {
        // Find latest version starting with the target framework number
        string? latestVersion = null;
        Version? latestParsedVersion = null;

        foreach (var versionItem in versions.EnumerateArray())
        {
            if (!versionItem.TryGetProperty("version", out var versionProp))
            {
                continue;
            }

            string? versionStr = versionProp.GetString();
            if (versionStr is null || !versionStr.StartsWith($"{tf}."))
            {
                continue;
            }

            // Parse version for comparison (strip prerelease suffix)
            string versionToParse = versionStr.Split('-')[0];
            if (Version.TryParse(versionToParse, out var parsedVersion))
            {
                if (latestParsedVersion is null || parsedVersion > latestParsedVersion)
                {
                    latestParsedVersion = parsedVersion;
                    latestVersion = versionStr;
                }
            }
        }

        if (latestVersion is not null)
        {
            result[tf] = latestVersion;
        }
        else
        {
            Console.WriteLine($"  Warning: No version found for {packageName} supporting net{tf}.0");
        }
    }

    return result;
}