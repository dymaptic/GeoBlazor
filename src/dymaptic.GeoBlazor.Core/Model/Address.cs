namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     A complete street address for use in an <see cref="AddressQuery" />
/// </summary>
public record Address(string Street, string City, string State, string Zone);