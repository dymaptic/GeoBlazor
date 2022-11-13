using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     Defines the spatial reference of a view, layer, or method parameters. This indicates the projected or geographic coordinate system used to locate geographic features in the map. Each projected and geographic coordinate system is defined by either a well-known ID (WKID) or a definition string (WKT). Note that for versions prior to ArcGIS 10, only WKID was supported. For a full list of supported spatial reference IDs and their corresponding definition strings, see Using spatial references.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-SpatialReference.html">ArcGIS JS API</a>
/// </summary>
public class SpatialReference : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public SpatialReference()
    {
    }

    /// <summary>
    ///     Creates a new SpatialReference in code with a Wkid
    /// </summary>
    /// <param name="wkid">
    ///     The well-known Id for the spatial reference
    /// </param>
    public SpatialReference(double wkid)
    {
#pragma warning disable BL0005
        Wkid = wkid;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     An image coordinate system defines the spatial reference used to display the image in its original coordinates without distortion, map transformations or ortho-rectification.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public object? ImageCoordinateSystem { get; set; }

    /// <summary>
    ///     Indicates if the spatial reference refers to a geographic coordinate system.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsGeographic { get; set; }

    /// <summary>
    ///     Indicates if the wkid of the spatial reference object is one of the following values: 102113, 102100, 3857.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWebMercator { get; set; }

    /// <summary>
    ///     Indicates if the wkid of the spatial reference object is 4326.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWgs84 { get; set; }

    /// <summary>
    ///     Indicates if the spatial reference of the map supports wrapping around the International Date Line.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public bool? IsWrappable { get; set; }

    /// <summary>
    ///     The well-known ID of a spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public double? Wkid { get; set; }

    /// <summary>
    ///     The well-known text that defines a spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Wkt { get; set; }

    /// <summary>
    ///     A convenience static instance for WGS84 Spatial Reference.
    /// </summary>
    [JsonIgnore]
    public static SpatialReference Wgs84 { get; set; } = new(4326);

    /// <summary>
    ///     A convenience static instance for WebMercator Spatial Reference.
    /// </summary>
    [JsonIgnore]
    public static SpatialReference WebMercator { get; set; } = new(3857);
}