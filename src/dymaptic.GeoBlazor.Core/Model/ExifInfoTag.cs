namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     The tag for an ExifInfo object.
/// </summary>
/// <param name="Name">
///     The tag name.
/// </param>
/// <param name="Description">
///     The tag description.
/// </param>
/// <param name="Value">
///     The value of the tag.
/// </param>
public record ExifInfoTag(string Name, string Description, object Value);