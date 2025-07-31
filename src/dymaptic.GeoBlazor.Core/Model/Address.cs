namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A complete street address for use in an <see cref="AddressQuery" />
///     note: the Street property is converted to Address in JavaScript, but C# does not allow properties
///     with the same name as the containing class
/// </summary>
public record Address(
    [property: JsonPropertyName("Address")]
    string Street,
    string City,
    string State,
    string Zone);