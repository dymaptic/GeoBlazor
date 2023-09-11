using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     Domains define constraints on a layer field. There are two types of domains: coded values and range domains. This is an abstract class.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html">ArcGIS JS API</a>
/// </summary>
[JsonConverter(typeof(DomainConverter))]
public abstract class Domain : MapComponent
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

/// <summary>
///     Information about the coded values belonging to the domain. Coded value domains specify a valid set of values for a field. Each valid value is assigned a unique name. For example, in a layer for water mains, water main features may be buried under different types of surfaces as signified by a GroundSurfaceType field: pavement, gravel, sand, or none (for exposed water mains). The coded value domain includes both the actual value that is stored in the database (for example, 1 for pavement) and a more user-friendly description of what that value actually means.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html">ArcGIS JS API</a>
/// </summary>
public class CodedValueDomain<T> : Domain
{
    /// <inheritdoc />
    public override string Type => "coded-value";

    /// <summary>
    ///     An array of the coded values in the domain.
    /// </summary>
    public HashSet<CodedValue<T>>? CodedValues { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CodedValue<T> codedValue:
                CodedValues ??= new HashSet<CodedValue<T>>();

                CodedValues.Add(codedValue);

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CodedValue<T> codedValue:
                CodedValues?.Remove(codedValue);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}

/// <summary>
///     The coded value in a domain.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html#CodedValue">ArcGIS JS API</a>
/// </summary>
public class CodedValue<T> : MapComponent
{
    /// <summary>
    ///     The name of the coded value.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    ///     The value of the code.
    /// </summary>
    [Parameter]
    public T? Code { get; set; }
}

/// <summary>
/// Inherited domains apply to domains at the feature type level. It implies that the domain for a given field at the feature
/// type level is the same as the domain for the field at the layer level.
/// NOTE: Name is not used and will always be null.
/// </summary>
public class InheritedDomain : Domain
{
    public override string Type => "inherited";
}

/// <summary>
///     Range domains specify a valid minimum and maximum valid value that can be stored in numeric and date fields.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-RangeDomain.html">ArcGIS JS API</a>
/// </summary>
public class RangeDomain : Domain
{
    /// <inheritdoc />
    public override string Type => "range";

    /// <summary>
    ///     The maximum valid value.
    /// </summary>
    [Parameter]
    public double? MaxValue { get; set; }

    /// <summary>
    ///     The minimum valid value.
    /// </summary>
    [Parameter]
    public double? MinValue { get; set; }
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