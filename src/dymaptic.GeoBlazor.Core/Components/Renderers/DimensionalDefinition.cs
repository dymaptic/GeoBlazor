using dymaptic.GeoBlazor.Core.Components.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     Defines the symbols to use in a UniqueValueRenderer. Each unique value info defines a symbol that should be used to
///     represent features with a specific value.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-DimensionalDefinition.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class DimensionalDefinition : LayerObject
{
    /// <summary>
    ///     The dimension associated with the variable..
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DimensionName { get; set; }

    /// <summary>
    ///     Indicates whether the values indicate slices (rather than ranges).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? IsSlice { get; set; }

    /// <summary>
    ///     The required variable name by which to filter.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VariableName { get; set; }

    /// <summary>
    ///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<int>? Values { get; set; }
}
