namespace dymaptic.GeoBlazor.Core.Components;

public partial class OrderedLayerOrderBy : MapComponent
{
    /// <summary>
    ///     The number or date field whose values will be used to sort features.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Field { get; set; }

    /// <summary>
    ///     An [Arcade](https://developers.arcgis.com/javascript/latest/arcade/) expression following the specification defined
    ///     by the [Arcade Feature Z Profile](https://developers.arcgis.com/javascript/latest/arcade/#feature-sorting).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ValueExpression { get; set; }

    /// <summary>
    ///     The sort order
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SortOrder? Order { get; set; }
}