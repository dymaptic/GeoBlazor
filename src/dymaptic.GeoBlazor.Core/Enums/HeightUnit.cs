namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The unit of the vertical coordinate system.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-HeightModelInfo.html#heightUnit">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(HeightUnitConverter))]
public enum HeightUnit
{
#pragma warning disable CS1591
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

internal class HeightUnitConverter : JsonConverter<HeightUnit>
{
    public override HeightUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "meters" => HeightUnit.Meters,
            "feet" => HeightUnit.Feet,
            "us-feet" => HeightUnit.UsFeet,
            "clarke-feet" => HeightUnit.ClarkeFeet,
            "clarke-yards" => HeightUnit.ClarkeYards,
            "clarke-links" => HeightUnit.ClarkeLinks,
            "sears-yards" => HeightUnit.SearsYards,
            "sears-feet" => HeightUnit.SearsFeet,
            "sears-chains" => HeightUnit.SearsChains,
            "benoit-1895-b-chains" => HeightUnit.Benoit1895BChains,
            "indian-yards" => HeightUnit.IndianYards,
            "indian-1937-yards" => HeightUnit.Indian1937Yards,
            "gold-coast-feet" => HeightUnit.GoldCoastFeet,
            "sears-1922-truncated-chains" => HeightUnit.Sears1922TruncatedChains,
            "50-kilometers" => HeightUnit.FiftyKilometers,
            "150-kilometers" => HeightUnit.OneHundredFiftyKilometers,
            _ => HeightUnit.Meters
        };
    }

    public override void Write(Utf8JsonWriter writer, HeightUnit value, JsonSerializerOptions options)
    {
        string unit = value switch
        {
            HeightUnit.Meters => "meters",
            HeightUnit.Feet => "feet",
            HeightUnit.UsFeet => "us-feet",
            HeightUnit.ClarkeFeet => "clarke-feet",
            HeightUnit.ClarkeYards => "clarke-yards",
            HeightUnit.ClarkeLinks => "clarke-links",
            HeightUnit.SearsYards => "sears-yards",
            HeightUnit.SearsFeet => "sears-feet",
            HeightUnit.SearsChains => "sears-chains",
            HeightUnit.Benoit1895BChains => "benoit-1895-b-chains",
            HeightUnit.IndianYards => "indian-yards",
            HeightUnit.Indian1937Yards => "indian-1937-yards",
            HeightUnit.GoldCoastFeet => "gold-coast-feet",
            HeightUnit.Sears1922TruncatedChains => "sears-1922-truncated-chains",
            HeightUnit.FiftyKilometers => "50-kilometers",
            HeightUnit.OneHundredFiftyKilometers => "150-kilometers",
            _ => "meters"
        };

        writer.WriteStringValue(unit);
    }
}

/// <summary>
///     Defines the type of statistic.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<StatisticType>))]
public enum StatisticType
{
#pragma warning disable CS1591
    Count,
    Sum,
    Min,
    Max,
    Avg,
    Stddev,
    Var,
    PercentileContinuous,
    PercentileDiscrete,
    EnvelopeAggregate,
    CentroidAggregate,
    ConvexHullAggregate
#pragma warning restore CS1591
}