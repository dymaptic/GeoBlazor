

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A numeric field used for generating a relationship renderer
/// </summary>
/// <param name="Field">
///     The name of a numeric field.
/// </param>
/// <param name="NormalizationField">
///     The name of a numeric field used to normalize the given field. In choropleth visualizations it is best practice to normalize your data values if they haven't already been normalized.
/// </param>
/// <param name="ClassBreakInfos">
///     Describes the class breaks generated for this field.
/// </param>
/// <param name="Label">
///     The label used to describe the field or variable in the legend.
/// </param>
public record AuthoringInfoField(string Field, string? NormalizationField, 
    IReadOnlyCollection<ClassBreakInfo>? ClassBreakInfos, string? Label);