namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Extension methods for <see cref="IJSStreamReference" /> to facilitate reading data from JavaScript streams.
/// </summary>
public static class IJSStreamReferenceExtensions
{
    internal static async Task<Stream?> ReadJsStreamReferenceAsStream(this IJSStreamReference jsStreamReference,
        long? maxAllowedSize = null, CancellationToken cancellationToken = default)
    {
        maxAllowedSize ??= 1_000_000_000L;

        return await jsStreamReference.OpenReadStreamAsync(maxAllowedSize.Value, cancellationToken);
    }

    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    /// </summary>
    internal static async Task<T?> ReadJsStreamReferenceAsJSON<T>(this IJSStreamReference jsStreamReference,
        long? maxAllowedSize = null, CancellationToken cancellationToken = default)
    {
        maxAllowedSize ??= 1_000_000_000L;

        return (T?)await jsStreamReference.ReadJsStreamReferenceAsJSON(typeof(T), maxAllowedSize, cancellationToken);
    }

    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    ///     This overload returns an <see cref="object" />, so the type does not need to be known at compile time.
    /// </summary>
    internal static async Task<object?> ReadJsStreamReferenceAsJSON(this IJSStreamReference jsStreamReference,
        Type returnType,
        long? maxAllowedSize = null,
        CancellationToken cancellationToken = default)
    {
        maxAllowedSize ??= 1_000_000_000L;

        await using Stream stream =
            await jsStreamReference.OpenReadStreamAsync(maxAllowedSize.Value, cancellationToken);
        using StreamReader reader = new(stream, Encoding.UTF8);

        string json = await reader.ReadToEndAsync(cancellationToken);

        if (returnType == typeof(string))
        {
            return json.Trim('"');
        }

        return JsonSerializer.Deserialize(json, returnType, GeoBlazorSerialization.JsonSerializerOptions);
    }
}