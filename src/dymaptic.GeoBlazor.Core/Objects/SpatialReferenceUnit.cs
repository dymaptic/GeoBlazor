using System.Text.Json;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The unit of the spatial reference.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html#unit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(SpatialReferenceUnitConverter))]
public enum SpatialReferenceUnit
{
#pragma warning disable CS1591
    Degrees,
    Meters,
    Feet,
    UsFeet,
    ClarkeFeet,
    ClarkeYards,
    ClarkeLinks,
    SearsYards,
    SearsFeet,
    SearsChains,
    Benoit1895BChains,
    IndianYards,
    Indian1937Yards,
    GoldCoastFeet,
    Sears1922TruncatedChains,
    FiftyKilometers,
    OneHundredFiftyKilometers
#pragma warning restore CS1591
}

internal class SpatialReferenceUnitConverter : JsonConverter<SpatialReferenceUnit>
{
    public override SpatialReferenceUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "degrees" => SpatialReferenceUnit.Degrees,
            "meters" => SpatialReferenceUnit.Meters,
            "feet" => SpatialReferenceUnit.Feet,
            "us-feet" => SpatialReferenceUnit.UsFeet,
            "clarke-feet" => SpatialReferenceUnit.ClarkeFeet,
            "clarke-yards" => SpatialReferenceUnit.ClarkeYards,
            "clarke-links" => SpatialReferenceUnit.ClarkeLinks,
            "sears-yards" => SpatialReferenceUnit.SearsYards,
            "sears-feet" => SpatialReferenceUnit.SearsFeet,
            "sears-chains" => SpatialReferenceUnit.SearsChains,
            "benoit-1895-b-chains" => SpatialReferenceUnit.Benoit1895BChains,
            "indian-yards" => SpatialReferenceUnit.IndianYards,
            "indian-1937-yards" => SpatialReferenceUnit.Indian1937Yards,
            "gold-coast-feet" => SpatialReferenceUnit.GoldCoastFeet,
            "sears-1922-truncated-chains" => SpatialReferenceUnit.Sears1922TruncatedChains,
            "50-kilometers" => SpatialReferenceUnit.FiftyKilometers,
            "150-kilometers" => SpatialReferenceUnit.OneHundredFiftyKilometers,
            _ => SpatialReferenceUnit.Degrees
        };
    }

    public override void Write(Utf8JsonWriter writer, SpatialReferenceUnit value, JsonSerializerOptions options)
    {
        string unit = value switch
        {
            SpatialReferenceUnit.Degrees => "degrees",
            SpatialReferenceUnit.Meters => "meters",
            SpatialReferenceUnit.Feet => "feet",
            SpatialReferenceUnit.UsFeet => "us-feet",
            SpatialReferenceUnit.ClarkeFeet => "clarke-feet",
            SpatialReferenceUnit.ClarkeYards => "clarke-yards",
            SpatialReferenceUnit.ClarkeLinks => "clarke-links",
            SpatialReferenceUnit.SearsYards => "sears-yards",
            SpatialReferenceUnit.SearsFeet => "sears-feet",
            SpatialReferenceUnit.SearsChains => "sears-chains",
            SpatialReferenceUnit.Benoit1895BChains => "benoit-1895-b-chains",
            SpatialReferenceUnit.IndianYards => "indian-yards",
            SpatialReferenceUnit.Indian1937Yards => "indian-1937-yards",
            SpatialReferenceUnit.GoldCoastFeet => "gold-coast-feet",
            SpatialReferenceUnit.Sears1922TruncatedChains => "sears-1922-truncated-chains",
            SpatialReferenceUnit.FiftyKilometers => "50-kilometers",
            SpatialReferenceUnit.OneHundredFiftyKilometers => "150-kilometers",
            _ => string.Empty
        };

        writer.WriteStringValue(unit);
    }
}