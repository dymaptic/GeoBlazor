using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

public class SpatialReference : MapComponent
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public object? ImageCoordinateSystem { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsGeographic { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWebMercator { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWgs84 { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWrappable { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public double? Wkid { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Wkt { get; set; }

    [JsonIgnore]
    public static SpatialReference Wgs84 { get; set; } = new() { Wkid = 4326 };

    [JsonIgnore]
    public static SpatialReference WebMercator { get; set; } = new() { Wkid = 3857 };
}