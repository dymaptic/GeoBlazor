namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Extension methods for <see cref="IJSStreamReference" /> to facilitate reading data from JavaScript streams.
/// </summary>
public static class IJSStreamReferenceHelper
{
    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    /// </summary>
    public static async Task<T?> ReadJsStreamReference<T>(this IJSStreamReference jsStreamReference,
        long maxAllowedSize = 1_000_000_000L)
    {
        return (T?)await ReadJsStreamReference(jsStreamReference, typeof(T), maxAllowedSize);
    }

    /// <summary>
    ///     Convenience method to deserialize an <see cref="IJSStreamReference" /> to a specific .NET type.
    ///     This overload returns an <see cref="object" />, so the type does not need to be known at compile time.
    /// </summary>
    public static async Task<object?> ReadJsStreamReference(this IJSStreamReference jsStreamReference, Type returnType,
        long maxAllowedSize = 1_000_000_000)
    {
        await using Stream stream = await jsStreamReference.OpenReadStreamAsync(maxAllowedSize);
        using StreamReader reader = new(stream, Encoding.UTF8);

        string json = await reader.ReadToEndAsync();

        return JsonSerializer.Deserialize(json, returnType, GeoBlazorSerialization.JsonSerializerOptions);
    }
}