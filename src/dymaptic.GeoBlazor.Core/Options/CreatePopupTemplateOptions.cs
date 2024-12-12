namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Options for creating the <see cref="PopupTemplate" />.
/// </summary>
public record CreatePopupTemplateOptions
{
    /// <summary>
    ///     An array of field types to ignore when creating the popup. System fields such as Shape_Area and Shape_length, in
    ///     addition to geometry, blob, raster, guid and xml field types are automatically ignored.
    /// </summary>
    public string[]? IgnoreFieldTypes { get; set; }

    /// <summary>
    ///     An array of field names set to be visible within the PopupTemplate.
    /// </summary>
    public HashSet<string>? VisibleFieldNames { get; set; }
}