using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Determines the order in which features are drawn in the view.
/// </summary>
public class OrderedLayerOrderBy : MapComponent
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

/// <summary>
///     The sort order options for <see cref="OrderedLayerOrderBy" />
/// </summary>
[JsonConverter(typeof(SortOrderConverter))]
public enum SortOrder
{
#pragma warning disable CS1591
    Ascending,
    Descending
#pragma warning restore CS1591
}

internal class SortOrderConverter : EnumToKebabCaseStringConverter<SortOrder>
{
    public override SortOrder Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();

        if (value is not null && value.Contains("desc", StringComparison.OrdinalIgnoreCase))
        {
            return SortOrder.Descending;
        }

        return SortOrder.Ascending;
    }
}