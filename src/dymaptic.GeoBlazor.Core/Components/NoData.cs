using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     The pixel value representing no available information. Can be a number (same value for all bands) or array (specific value for each band).
/// </summary>
[JsonConverter(typeof(NoDataConverter))]
public class NoData : MapComponent
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public NoData()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="pixelValue">
    ///     A single pixel value representing no available information.
    /// </param>
    public NoData(long pixelValue)
    {
#pragma warning disable BL0005
        PixelValue = pixelValue;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="pixelValueArray">
    ///     An array of pixel values representing no available information. Each value corresponds to a band in the raster dataset.
    /// </param>
    public NoData(long[] pixelValueArray)
    {
#pragma warning disable BL0005
        PixelValueArray = pixelValueArray;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Implicit conversion from a single pixel value to a NoData object.
    /// </summary>
    public static implicit operator NoData(long pixelValue) => new(pixelValue);
    /// <summary>
    ///     Implicit conversion from an array of pixel values to a NoData object.
    /// </summary>
    public static implicit operator NoData(long[] pixelValueArray) => new(pixelValueArray);
    /// <summary>
    ///     Implicit conversion from a list of pixel values to a NoData object.
    /// </summary>
    public static implicit operator NoData(List<long> pixelValueList) => new(pixelValueList.ToArray());
    
    /// <summary>
    ///     A single pixel value representing no available information.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(PixelValueArray))]
    public long? PixelValue { get; set; }
    
    /// <summary>
    ///     An array of pixel values representing no available information. Each value corresponds to a band in the raster dataset.
    /// </summary>
    [Parameter]
    [RequiredProperty(nameof(PixelValue))]
    public long[]? PixelValueArray { get; set; }
}

/// <summary>
///     The interpretation of no data values in the raster dataset.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<NoDataInterpretation>))]
public enum NoDataInterpretation
{
#pragma warning disable  CS1591
    Any,
    All
#pragma warning restore  CS1591
}

internal class NoDataConverter : JsonConverter<NoData>
{
    public override NoData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return new NoData(reader.GetInt64());
        }

        if (reader.TokenType == JsonTokenType.StartArray)
        {
            return new NoData(JsonSerializer.Deserialize<long[]>(ref reader, options)!);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, NoData value, JsonSerializerOptions options)
    {
        if (value.PixelValue is not null)
        {
            writer.WriteNumberValue(value.PixelValue.Value);
        }
        else if (value.PixelValueArray is not null)
        {
            JsonSerializer.Serialize(writer, value.PixelValueArray, options);
        }
    }
}