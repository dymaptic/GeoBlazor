using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json;


namespace dymaptic.GeoBlazor.Core.Enums;

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