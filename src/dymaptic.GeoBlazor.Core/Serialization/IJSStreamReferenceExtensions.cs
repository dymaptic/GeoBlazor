using Microsoft.JSInterop.Implementation;
using System.Text.RegularExpressions;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Extension methods for <see cref="IJSStreamReference" /> to facilitate reading data from JavaScript streams.
/// </summary>
public static partial class IJSStreamReferenceExtensions
{
    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    /// </summary>
    internal static async Task<T?> ReadJsStreamReference<T>(this IJSStreamReference jsStreamReference,
        long maxAllowedSize = 1_000_000_000L)
    {
        return (T?)await jsStreamReference.ReadJsStreamReference(typeof(T), maxAllowedSize);
    }

    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    ///     This overload returns an <see cref="object" />, so the type does not need to be known at compile time.
    /// </summary>
    internal static async Task<object?> ReadJsStreamReference(this IJSStreamReference jsStreamReference, Type returnType,
        long maxAllowedSize = 1_000_000_000)
    {
        await using Stream stream =
            await jsStreamReference.OpenReadStreamAsync(maxAllowedSize);
        using StreamReader reader = new(stream, Encoding.UTF8);

        string json = await reader.ReadToEndAsync();

        Type unwrappedType = GetUnwrappedType(returnType);

        if (unwrappedType == typeof(string))
        {
            json = json.Trim('"');
            return json == "null"
                ? null :
                json == "empty-string"
                    ? string.Empty
                    : json;
        }

        if (unwrappedType == typeof(bool))
        {
            if (bool.TryParse(json, out bool boolResult))
            {
                return boolResult;
            }

            return null;
        }

        if (json is "null" or "empty-string")
        {
            return null;
        }

        if (unwrappedStringJsonRegex.IsMatch(json))
        {
            json = $"\"{json}\"";
        }

        return JsonSerializer.Deserialize(json, returnType, jsStreamReference.GetJsonSerializerOptions());
    }

    private static JsonSerializerOptions GetJsonSerializerOptions(this IJSStreamReference jsStreamReference)
    {
        // steal the private IJSRuntime from this instance
        IJSRuntime jsRuntime = (IJSRuntime)jsRuntimeFieldInfo.GetValue(jsStreamReference)!;

        if (serializerOptionsCache.TryGetValue(jsRuntime, out JsonSerializerOptions? options))
        {
            return options;
        }

        // copy the static options
        options = new(GeoBlazorSerialization.JsonSerializerOptions);

        // add the ElementReferenceConverter
        options.Converters.Add(new ElementReferenceConverter(new WebElementReferenceContext(jsRuntime)));

        serializerOptionsCache[jsRuntime] = options;
        return options;
    }

    private static Type GetUnwrappedType(Type type)
    {
        return type is { IsGenericType: true }
            && (type.GetGenericTypeDefinition() == typeof(Nullable<>))
            ? type.GenericTypeArguments[0]
            : type;
    }

    private static readonly System.Reflection.FieldInfo jsRuntimeFieldInfo = typeof(JSStreamReference)
        .GetField("_jsRuntime", BindingFlags.NonPublic | BindingFlags.Instance)!;
    private static readonly ConcurrentDictionary<IJSRuntime, JsonSerializerOptions> serializerOptionsCache = new();

    [GeneratedRegex(@"^(?<!false)(?<!true)[A-Za-z][A-Za-z0-9_/.:-]*$")]
    private static partial Regex UnwrappedStringJsonRegex();

    private static readonly Regex unwrappedStringJsonRegex = UnwrappedStringJsonRegex();
}