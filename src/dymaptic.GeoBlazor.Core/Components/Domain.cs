namespace dymaptic.GeoBlazor.Core.Components;

[JsonConverter(typeof(DomainConverter))]
public abstract partial class Domain : MapComponent
{
    /// <summary>
    ///     The domain type.
    /// </summary>
    public abstract string Type { get; }

    /// <summary>
    ///     The domain name.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }
}

internal class DomainConverter : JsonConverter<Domain>
{
    public override Domain? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var json = JsonDocument.ParseValue(ref reader);
        var type = json.RootElement.GetProperty("type").GetString();

        Domain? result = null;

        switch (type)
        {
            //coded values can be numbers or strings, so we can look ahead to see which type we need to deserialize
            case "coded-value":
                {
                    if (json.RootElement.TryGetProperty("codedValues", out JsonElement valueArray) && valueArray.EnumerateArray().FirstOrDefault().TryGetProperty("code", out JsonElement code))
                    {
                        result = code.ValueKind == JsonValueKind.String
                            ? JsonSerializer.Deserialize<CodedValueDomain<string>>(json.RootElement.GetRawText(),
                                options)
                            : JsonSerializer.Deserialize<CodedValueDomain<double>>(json.RootElement.GetRawText(),
                                options);
                    }
                    break;
                }
            case "range":
                result = JsonSerializer.Deserialize<RangeDomain>(json.RootElement.GetRawText(), options);
                break;
            case "inherited":
                result = JsonSerializer.Deserialize<InheritedDomain>(json.RootElement.GetRawText(), options);
                break;
            default:
                return null;
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, Domain value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}