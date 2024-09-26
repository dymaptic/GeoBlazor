using dymaptic.GeoBlazor.Core.Serialization;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
/// Measurement systems or area units. List of available units and unit systems (imperial, metric) for displaying the area values. 
/// By default, the following units are included: metric, imperial, square-inches, square-feet, square-us-feet, square-yards, square-miles,
/// square-meters, square-kilometers, acres, ares, hectares. Possible unit values can only be a subset of this list.
///  <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-units.html#SystemOrAreaUnit">ArcGIS Maps SDK for JavaScript</a>
/// Used by Widgets.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SystemOrAreaUnit>))]
public enum SystemOrAreaUnit
{
#pragma warning disable CS1591
    MeasurementSystem,
    AreaUnit
#pragma warning restore CS1591
}
