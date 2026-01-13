using Microsoft.Extensions.Configuration;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Test.Blazor.Shared.Configuration;

public static class ConfigurationHelper
{

    /// <summary>
    /// Recursively converts IConfiguration to a nested Dictionary and serializes to JSON.
    /// </summary>
    public static string ToJson(this IConfiguration config)
    {
        var dict = ToDictionary(config);
        var options = new JsonSerializerOptions
        {
            WriteIndented = true // Pretty print
        };
        return JsonSerializer.Serialize(dict, options);
    }

    /// <summary>
    /// Recursively builds a dictionary from IConfiguration.
    /// </summary>
    private static Dictionary<string, object?> ToDictionary(IConfiguration config)
    {
        var result = new Dictionary<string, object?>();

        foreach (var child in config.GetChildren())
        {
            // If the child has further children, recurse
            if (child.GetChildren().Any())
            {
                result[child.Key] = ToDictionary(child);
            }
            else
            {
                result[child.Key] = child.Value;
            }
        }

        return result;
    }
}