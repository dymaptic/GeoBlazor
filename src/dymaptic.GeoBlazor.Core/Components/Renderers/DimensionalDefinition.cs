using dymaptic.GeoBlazor.Core.Attributes;


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
    public DimensionalDefinition()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public DimensionalDefinition(string? dimensionName = null, bool? isSlice = null, string? variableName = null, 
        DimensionalDefinitionValues? values = null)
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
    public DimensionalDefinitionValues? Values { get; set; }
}

/// <summary>
///     An array of single values or tuples [min, max] each defining a range of valid values along the specified dimension.
/// </summary>
[JsonConverter(typeof(DimensionalDefinitionValuesConverter))]
public class DimensionalDefinitionValues : MapComponent
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public DimensionalDefinitionValues()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="valueArray">
    ///     An array of single values each defining a valid value along the specified dimension.
    /// </param>
    public DimensionalDefinitionValues(IReadOnlyList<long> valueArray)
    {
# pragma warning disable BL0005
        ValueArray = valueArray;
# pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="valueTupleArray">
    ///     An array of tuples [min, max] each defining a range of valid values along the specified dimension.
    /// </param>
    public DimensionalDefinitionValues(IReadOnlyList<(long, long)> valueTupleArray)
    {
# pragma warning disable BL0005
        ValueTupleArray = valueTupleArray;
# pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Implicit conversion from a list of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues(List<long> valueList) => new(valueList);
    /// <summary>
    ///     Implicit conversion from an array of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues(long[] valueArray) => new(valueArray);
    /// <summary>
    ///     Implicit conversion from a list of tuples of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues(List<(long, long)> valueTupleList) => new(valueTupleList);
    /// <summary>
    ///     Implicit conversion from an array of tuples of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues((long, long)[] valueTupleArray) => new(valueTupleArray);
    /// <summary>
    ///     Implicit conversion from a tuple of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues((long, long) valueTuple) => new([ valueTuple ]);
    /// <summary>
    ///     Implicit conversion from a list of lists of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues(List<List<long>> valueList) => 
        new(valueList.Select(x => (x[0], x[1])).ToList());
    /// <summary>
    ///     Implicit conversion from an array of arrays of long values to a DimensionalDefinitionValues object.
    /// </summary>
    public static implicit operator DimensionalDefinitionValues(long[][] valueArray) => 
        new(valueArray.Select(x => (x[0], x[1])).ToList());

    /// <summary>
    ///     An array of single values each defining a valid value along the specified dimension.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(ValueTupleArray))]
    public IReadOnlyList<long>? ValueArray { get; set; }
    
    /// <summary>
    ///     An array of tuples [min, max] each defining a range of valid values along the specified dimension.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(ValueArray))]
    public IReadOnlyList<(long, long)>? ValueTupleArray { get; set; }
}

internal class DimensionalDefinitionValuesConverter: JsonConverter<DimensionalDefinitionValues>
{
    public override DimensionalDefinitionValues? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);

            JsonElement root = document.RootElement;
            if (root[0].ValueKind == JsonValueKind.Array)
            {
                var valueTupleArray = root.EnumerateArray()
                    .Select(e => (e[0].GetInt64(), e[1].GetInt64()))
                    .ToList();
                return new DimensionalDefinitionValues(valueTupleArray);
            }

            var valueArray = root.EnumerateArray()
                .Select(e => e.GetInt64())
                .ToList();
            return new DimensionalDefinitionValues(valueArray);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, DimensionalDefinitionValues values, JsonSerializerOptions options)
    {
        if (values.ValueArray is not null)
        {
            writer.WriteStartArray();
            foreach (long item in values.ValueArray)
            {
                writer.WriteNumberValue(item);
            }
            writer.WriteEndArray();
        }
        else if (values.ValueTupleArray is not null)
        {
            writer.WriteStartArray();
            foreach ((long, long) item in values.ValueTupleArray)
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(item.Item1);
                writer.WriteNumberValue(item.Item2);
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
}