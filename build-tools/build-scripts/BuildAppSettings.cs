#!/usr/bin/env dotnet

// Build AppSettings Script
// C# file-based app version of buildAppSettings.ps1
// Generates appsettings.json files for test applications.
//
// Usage: dotnet BuildAppSettings.cs [options]
//   -k, --api-key <key>        ArcGIS API key (required)
//   -l, --license-key <key>    GeoBlazor license key (required)
//   -o, --output <path>        Output path(s) for appsettings.json (required, can specify multiple)
//   -d, --docs-url <url>       Documentation URL (default: https://docs.geoblazor.com)
//   -b, --bypass-key <key>     API bypass key for samples (optional)
//   -w, --wfs-servers <json>   Additional WFS server configuration JSON fragment (optional)
//   -h, --help                 Display help message
//
// Example:
//   dotnet BuildAppSettings.cs -k "your-arcgis-key" -l "your-license" -o "./appsettings.json"
//   dotnet BuildAppSettings.cs -k "key" -l "license" -o "./app1/appsettings.json" -o "./app2/appsettings.json"

using System.Text;

string? arcGISApiKey = null;
string? licenseKey = null;
List<string> outputPaths = [];
string docsUrl = "https://docs.geoblazor.com";
string byPassApiKey = "";
string wfsServers = "";
bool help = false;

// Parse command line arguments
for (int i = 0; i < args.Length; i++)
{
    string arg = args[i];
    switch (arg.ToLowerInvariant())
    {
        case "-k":
        case "--api-key":
            if (i + 1 < args.Length)
            {
                arcGISApiKey = args[++i];
            }
            break;
        case "-l":
        case "--license-key":
            if (i + 1 < args.Length)
            {
                licenseKey = args[++i];
            }
            break;
        case "-o":
        case "--output":
            if (i + 1 < args.Length)
            {
                outputPaths.Add(args[++i]);
            }
            break;
        case "-d":
        case "--docs-url":
            if (i + 1 < args.Length)
            {
                docsUrl = args[++i];
            }
            break;
        case "-b":
        case "--bypass-key":
            if (i + 1 < args.Length)
            {
                byPassApiKey = args[++i];
            }
            break;
        case "-w":
        case "--wfs-servers":
            if (i + 1 < args.Length)
            {
                wfsServers = args[++i];
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
    Console.WriteLine("Build AppSettings Script");
    Console.WriteLine("Generates appsettings.json files for test applications.");
    Console.WriteLine();
    Console.WriteLine("Usage: dotnet BuildAppSettings.cs [options]");
    Console.WriteLine();
    Console.WriteLine("Options:");
    Console.WriteLine("  -k, --api-key <key>        ArcGIS API key (required)");
    Console.WriteLine("  -l, --license-key <key>    GeoBlazor license key (required)");
    Console.WriteLine("  -o, --output <path>        Output path(s) for appsettings.json (required, can specify multiple)");
    Console.WriteLine("  -d, --docs-url <url>       Documentation URL (default: https://docs.geoblazor.com)");
    Console.WriteLine("  -b, --bypass-key <key>     API bypass key for samples (optional)");
    Console.WriteLine("  -w, --wfs-servers <json>   Additional WFS server configuration JSON fragment (optional)");
    Console.WriteLine("  -h, --help                 Display this help message");
    Console.WriteLine();
    Console.WriteLine("Examples:");
    Console.WriteLine("  dotnet BuildAppSettings.cs -k \"your-arcgis-key\" -l \"your-license\" -o \"./appsettings.json\"");
    Console.WriteLine("  dotnet BuildAppSettings.cs -k \"key\" -l \"license\" -o \"./app1/appsettings.json\" -o \"./app2/appsettings.json\"");
    return 0;
}

// Validate required parameters
if (string.IsNullOrWhiteSpace(arcGISApiKey))
{
    Console.Error.WriteLine("Error: ArcGIS API key is required. Use -k or --api-key to specify.");
    return 1;
}

if (string.IsNullOrWhiteSpace(licenseKey))
{
    Console.Error.WriteLine("Error: GeoBlazor license key is required. Use -l or --license-key to specify.");
    return 1;
}

if (outputPaths.Count == 0)
{
    Console.Error.WriteLine("Error: At least one output path is required. Use -o or --output to specify.");
    return 1;
}

// Build the appsettings JSON content
var sb = new StringBuilder();
sb.AppendLine("{");
sb.AppendLine($"  \"ArcGISApiKey\": \"{EscapeJsonString(arcGISApiKey)}\",");
sb.AppendLine("  \"GeoBlazor\": {");
sb.AppendLine($"    \"LicenseKey\": \"{EscapeJsonString(licenseKey)}\"");
sb.AppendLine("  },");
sb.AppendLine($"  \"DocsUrl\": \"{EscapeJsonString(docsUrl)}\",");
sb.Append($"  \"ByPassApiKey\": \"{EscapeJsonString(byPassApiKey)}\"");

// Add WFS servers if provided
if (!string.IsNullOrWhiteSpace(wfsServers))
{
    sb.AppendLine(",");
    sb.Append($"  {wfsServers}");
}

sb.AppendLine();
sb.AppendLine("}");

string appSettingsContent = sb.ToString();

// Write to each target path
foreach (string path in outputPaths)
{
    try
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        File.WriteAllText(path, appSettingsContent, Encoding.UTF8);
        Console.WriteLine($"Created: {path}");
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error writing to {path}: {ex.Message}");
        return 1;
    }
}

Console.WriteLine("AppSettings files generated successfully.");
return 0;

// Helper function to escape JSON string values
static string EscapeJsonString(string value)
{
    return value
        .Replace("\\", "\\\\")
        .Replace("\"", "\\\"")
        .Replace("\n", "\\n")
        .Replace("\r", "\\r")
        .Replace("\t", "\\t");
}
