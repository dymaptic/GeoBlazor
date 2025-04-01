namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     The Bing Maps Imagery Set Styles. ArcGIS currently only supports 3 options.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-BingMapsLayer.html#style">ArcGIS Maps SDK for JavaScript</a>
///     <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata#template-parameters">Bing Maps Imagery Set Styles</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<BingImageryStyle>))]
public enum BingImageryStyle
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Road,
    Aerial,
    Hybrid
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}