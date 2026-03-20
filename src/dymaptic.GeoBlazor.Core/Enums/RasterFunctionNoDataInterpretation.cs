namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Enums.RasterFunctionNoDataInterpretation.html">GeoBlazor Docs</a>
///     The interpretation of no data values in the raster dataset.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RasterFunctionNoDataInterpretation>))]
public enum RasterFunctionNoDataInterpretation
{
#pragma warning disable CS1591
    MatchAny,
    MatchAll
#pragma warning restore CS1591
}