using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// Measurement system for measurement. Use one of the possible values listed below.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.html#MeasurementSystem">ArcGIS Maps SDK for JavaScript</a>
/// Used by Widgets.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<MeasurementSystem>))]
public enum MeasurementSystem
{
#pragma warning disable CS1591
    Imperial,
    Metric
#pragma warning restore CS1591
}
