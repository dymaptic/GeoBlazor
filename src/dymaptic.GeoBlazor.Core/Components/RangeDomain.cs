namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Range domains specify a valid minimum and maximum valid value that can be stored in numeric and date fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class RangeDomain : Domain
{
    /// <inheritdoc />
    public override string Type => "range";

    /// <summary>
    ///     The maximum valid value.
    /// </summary>
    [Parameter]
    public double? MaxValue { get; set; }

    /// <summary>
    ///     The minimum valid value.
    /// </summary>
    [Parameter]
    public double? MinValue { get; set; }
}