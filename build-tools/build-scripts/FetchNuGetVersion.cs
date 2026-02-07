#!/usr/bin/env dotnet

// Fetch NuGet Package Version Script
// C# file-based app version of fetchNuGetVersion.ps1
// Usage: dotnet FetchNuGetVersion.cs <package-name>
// Example: dotnet FetchNuGetVersion.cs dymaptic.GeoBlazor.Core
// Returns the latest non-prerelease version of the specified package from NuGet.org

using System.Text.Json;

if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
{
    Console.Error.WriteLine("Package name must be provided.");
    return 1;
}

string package = args[0];

try
{
    // Query NuGet API (same endpoint as the PowerShell script)
    string nugetUrl = $"https://azuresearch-usnc.nuget.org/query?q={Uri.EscapeDataString(package)}&prerelease=false";

    using var client = new HttpClient();
    client.DefaultRequestHeaders.Add("User-Agent", "GeoBlazor-Build-Script");

    string json = await client.GetStringAsync(nugetUrl);
    using var doc = JsonDocument.Parse(json);
    var root = doc.RootElement;

    if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
    {
        Console.Error.WriteLine("Could not determine latest version from NuGet API.");
        return 1;
    }

    // Find the package with exact match and get the highest version
    string? latestVersion = null;

    foreach (var item in data.EnumerateArray())
    {
        // Check for exact package name match (case-insensitive)
        if (item.TryGetProperty("id", out var idProp))
        {
            string? id = idProp.GetString();
            if (string.Equals(id, package, StringComparison.OrdinalIgnoreCase))
            {
                if (item.TryGetProperty("version", out var versionProp))
                {
                    latestVersion = versionProp.GetString();
                    break; // NuGet API returns the latest version for each package
                }
            }
        }
    }

    // Fallback: if no exact match, try to parse versions from all results
    if (latestVersion is null)
    {
        var versions = new List<(Version Version, string Original)>();

        foreach (var item in data.EnumerateArray())
        {
            if (item.TryGetProperty("version", out var versionProp))
            {
                string? versionStr = versionProp.GetString();
                if (versionStr is not null && Version.TryParse(versionStr.Split('-')[0], out var version))
                {
                    versions.Add((version, versionStr));
                }
            }
        }

        if (versions.Count > 0)
        {
            latestVersion = versions.OrderByDescending(v => v.Version).First().Original;
        }
    }

    if (latestVersion is null)
    {
        Console.Error.WriteLine("Could not determine latest version from NuGet API.");
        return 1;
    }

    Console.WriteLine(latestVersion);
    return 0;
}
catch (HttpRequestException ex)
{
    Console.Error.WriteLine($"Failed to query NuGet API: {ex.Message}");
    return 1;
}
catch (JsonException ex)
{
    Console.Error.WriteLine($"Failed to parse NuGet API response: {ex.Message}");
    return 1;
}
