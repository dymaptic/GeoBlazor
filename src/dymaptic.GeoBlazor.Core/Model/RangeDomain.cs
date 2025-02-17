namespace dymaptic.GeoBlazor.Core.Model;

public partial class RangeDomain : Domain
{
    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="maxValue">
    ///     The maximum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#maxValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="minValue">
    ///     The minimum valid value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html#minValue">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="name">
    ///     The domain name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public RangeDomain(
        string? maxValue = null,
        string? minValue = null,
        string? name = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        MaxValue = maxValue;
        MinValue = minValue;
        Name = name;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc/>
    public override string Type => "range";
}