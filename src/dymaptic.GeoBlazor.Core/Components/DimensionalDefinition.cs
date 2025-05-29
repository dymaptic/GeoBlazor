namespace dymaptic.GeoBlazor.Core.Components;

public partial class DimensionalDefinition : MapComponent
{


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
    public DimensionalDefinitionValues? Values { get; set; }
}


