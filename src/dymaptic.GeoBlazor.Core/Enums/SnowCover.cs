namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-3d-environment-SnowyWeather.html#snowCover">GeoBlazor Docs</a>
///     <summary>
///          Enumeration for SnowCover
///      </summary>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SnowCover>))]
public enum SnowCover
{
#pragma warning disable CS1591
    Enabled,
    Disabled
#pragma warning restore CS1591
}