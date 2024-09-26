using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// Measurement systems or length units. Use one of the possible values listed below.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.html#SystemOrLengthUnit">ArcGIS Maps SDK for JavaScript</a>
/// Used by Widgets.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<ActiveWidget>))]
public enum ActiveWidget
{
#pragma warning disable CS1591
    AreaMeasurement2D,
    AreaMeasurement3D,
    DirectLineMeasurement3D,
    DistanceMeasurement2D,
#pragma warning restore CS1591
}
