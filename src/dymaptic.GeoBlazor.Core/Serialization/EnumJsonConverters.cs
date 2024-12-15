using dymaptic.GeoBlazor.Core.Enums;
using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using System.Text.Json;


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
            .Replace("-", string.Empty)
            .Replace("esri", string.Empty)
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


/// <summary>
/// Converts an enum to a kebab case string for serialization. Used with TimeInerval which returns esriTimeUnits from the ESRI JS.
/// </summary>
/// <typeparam name="T"></typeparam>
public class TimeEnumToKebabCaseStringConverter<T> : EnumToKebabCaseStringConverter<T> where T : notnull
{
    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty)
            .Replace("esriTimeUnits", string.Empty)
            .Replace(typeof(T).Name, string.Empty);

        try
        {
            return value is not null ? (T)Enum.Parse(typeof(T), value, true) : default!;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return default!;
        }
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
            ?.Replace("-", string.Empty)
            .Replace("esriServerPointLabelPlacement", string.Empty);

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
            ?.Replace("-", string.Empty)
            .Replace("esriFeatureEditTool", string.Empty);

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

public class EnumToTypeScriptEnumConverter<T>: EnumToKebabCaseStringConverter<T> where T : notnull
{
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        Type enumType = typeof(T);
        string enumName = enumType.Name;
        writer.WriteStringValue($"{enumName}.{Enum.GetName(enumType, value)}");
    }
}

internal class EnumRelationshipConverter<T> : EnumToKebabCaseStringConverter<T> where T : notnull
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()
            ?.Replace("-", string.Empty)
            .Replace("Rel", string.Empty)
            .Replace("Role", string.Empty)
            .Replace("esri", string.Empty)
            .Replace(nameof(Cardinality), string.Empty);

        return value is not null ? (T)Enum.Parse(typeof(T), value, true) : default(T)!;
    }
}