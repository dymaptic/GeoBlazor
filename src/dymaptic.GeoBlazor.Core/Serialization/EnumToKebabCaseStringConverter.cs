using dymaptic.GeoBlazor.Core.Extensions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Serialization;

internal class EnumToKebabCaseStringConverter<T> : JsonConverter<T> where T : notnull
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString()?.Replace("-", string.Empty)
            .Replace("esri", string.Empty)
            .Replace(typeof(T).Name, string.Empty);

        try
        {
            return value is not null ? (T)Enum.Parse(typeof(T), value, true) : default(T)!;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return default(T)!;
        }
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        string? stringVal = Enum.GetName(typeof(T), value);
        string resultString = stringVal!.ToKebabCase();
        writer.WriteStringValue(resultString);
    }
}