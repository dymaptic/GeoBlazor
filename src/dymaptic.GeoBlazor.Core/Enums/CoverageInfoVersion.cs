namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The service version.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-WCSLayer.html#CoverageInfo">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(CoverageInfoVersionConverter))]
public enum CoverageInfoVersion
{
    /// <summary>
    ///     1.0.0
    /// </summary>
    OnePointZeroPointZero,
    /// <summary>
    ///     1.1.0
    /// </summary>
    OnePointOnePointZero,
    /// <summary>
    ///     1.1.1
    /// </summary>
    OnePointOnePointOne,
    /// <summary>
    ///     1.1.2
    /// </summary>
    OnePointOnePointTwo,
    /// <summary>
    ///     2.0.1
    /// </summary>
    TwoPointZeroPointOne
}

internal class CoverageInfoVersionConverter : JsonConverter<CoverageInfoVersion>
{
    public override CoverageInfoVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        return value switch
        {
            "1.0.0" => CoverageInfoVersion.OnePointZeroPointZero,
            "1.1.0" => CoverageInfoVersion.OnePointOnePointZero,
            "1.1.1" => CoverageInfoVersion.OnePointOnePointOne,
            "1.1.2" => CoverageInfoVersion.OnePointOnePointTwo,
            "2.0.1" => CoverageInfoVersion.TwoPointZeroPointOne,
            _ => CoverageInfoVersion.OnePointZeroPointZero
        };
    }

    public override void Write(Utf8JsonWriter writer, CoverageInfoVersion value, JsonSerializerOptions options)
    {
        string version = value switch
        {
            CoverageInfoVersion.OnePointZeroPointZero => "1.0.0",
            CoverageInfoVersion.OnePointOnePointZero => "1.1.0",
            CoverageInfoVersion.OnePointOnePointOne => "1.1.1",
            CoverageInfoVersion.OnePointOnePointTwo => "1.1.2",
            CoverageInfoVersion.TwoPointZeroPointOne => "2.0.1",
            _ => string.Empty
        };

        writer.WriteStringValue(version);
    }
}