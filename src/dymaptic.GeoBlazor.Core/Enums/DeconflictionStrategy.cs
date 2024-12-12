using dymaptic.GeoBlazor.Core.Serialization;


namespace dymaptic.GeoBlazor.Core.Enums;


/// <summary>
///     Defines how labels should be placed relative to one another. By default, labels have a static deconfliction strategy, meaning labels that overlap are dropped to make them easier to read.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#deconflictionStrategy">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<DeconflictionStrategy>))]
public enum DeconflictionStrategy
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    None,
    Static
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}