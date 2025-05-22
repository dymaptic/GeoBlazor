namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Converts an enum to a kebab case string for serialization.
/// </summary>
/// <typeparam name="T">
///     The enum type to convert.
/// </typeparam>
public class EnumToKebabCaseStringConverter<T> : JsonConverter<T> where T : notnull
{
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()?
            .KebabToPascalCase()
            .Replace("esri", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(typeof(T).Name, string.Empty);

        try
        {
            return string.IsNullOrWhiteSpace(value) ? default! : (T)Enum.Parse(typeof(T), value, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return default!;
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(T), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteStringValue(resultString);
    }
}

internal class SimpleLineSymbolStyleConverter : EnumToKebabCaseStringConverter<SimpleLineSymbolStyle>
{
    public override SimpleLineSymbolStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()?
            .KebabToPascalCase()
            .Replace("SLS", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("esri", string.Empty, StringComparison.OrdinalIgnoreCase);

        return value is not null ? (SimpleLineSymbolStyle)Enum.Parse(typeof(SimpleLineSymbolStyle), value, true) : default;
    }
}


/// <summary>
///     Converts an enum to a kebab case string for serialization. Used with LabelPlacement which returns esriServerPointLabelPlacement from the ESRI JS.
/// </summary>
public class LabelPlacementStringConverter : EnumToKebabCaseStringConverter<LabelPlacement>
{
    /// <inheritdoc />
    public override LabelPlacement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.KebabToPascalCase()
            .Replace("esriServerPointLabelPlacement", string.Empty, StringComparison.OrdinalIgnoreCase);

        try
        {
            return value is not null 
                ? (LabelPlacement)Enum.Parse(typeof(LabelPlacement), value, true) 
                : default;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return default;
        }
    }
}

/// <summary>
///     Converts an enum to a kebab case string for serialization. Used with LabelPlacement which returns esriServerPointLabelPlacement from the ESRI JS.
/// </summary>
public class DrawingToolStringConverter : EnumToKebabCaseStringConverter<DrawingTool>
{
    /// <inheritdoc />
    public override DrawingTool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.KebabToPascalCase()
            .Replace("esriFeatureEditTool", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("FeatureEditTool", string.Empty, StringComparison.OrdinalIgnoreCase);

        try
        {
            return value is not null 
                ? (DrawingTool)Enum.Parse(typeof(DrawingTool), value, true) 
                : default;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return default;
        }
    }
}

internal class EnumRelationshipConverter<T> : EnumToKebabCaseStringConverter<T> where T : notnull
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.KebabToPascalCase()
            .Replace("Rel", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("Role", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("esri", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(nameof(Cardinality), string.Empty);

        return value is not null ? (T)Enum.Parse(typeof(T), value, true) : default(T)!;
    }
}