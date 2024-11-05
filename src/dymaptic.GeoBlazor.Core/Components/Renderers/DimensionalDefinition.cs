using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Defines the symbols to use in a UniqueValueRenderer. Each unique value info defines a symbol that should be used to
///     represent features with a specific value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-DimensionalDefinition.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class DimensionalDefinition : MapComponent
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public DimensionalDefinition() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public DimensionalDefinition(string? dimensionName = null, bool? isSlice = null, string? variableName = null, List<long>? values = null)
    {
#pragma warning disable BL0005
        DimensionName = dimensionName;
        IsSlice = isSlice;
        VariableName = variableName;
        Values = values;
#pragma warning restore BL0005
    }
    /// <summary>
    ///     The dimension associated with the variable..
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DimensionName { get; set; }

    /// <summary>
    ///     Indicates whether the values indicate slices (rather than ranges).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsSlice { get; set; }

    /// <summary>
    ///     The required variable name by which to filter.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VariableName { get; set; }

    /// <summary>
    ///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<long>? Values { get; set; }
}
