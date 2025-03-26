namespace dymaptic.GeoBlazor.Core.Objects;


/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LayerSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The where clause specified for filtering suggests or search results.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
    
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}

/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LocatorSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}