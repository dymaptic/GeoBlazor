using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     The minimum and maximum X and Y coordinates of a bounding box. Extent is used to describe the visible portion of a MapView. When working in a SceneView, Camera is used to define the visible part of the map within the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">ArcGIS JS API</a>
/// </summary>
public class Extent : Geometry
{
    /// <summary>
    ///     The maximum X-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    public double Xmax { get; set; }

    /// <summary>
    ///     The minimum X-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    public double Xmin { get; set; }

    /// <summary>
    ///     The maximum Y-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    public double Ymax { get; set; }

    /// <summary>
    ///     The minimum Y-coordinate of an extent envelope.
    /// </summary>
    [Parameter]
    public double Ymin { get; set; }

    /// <summary>
    ///     The maximum possible z, or elevation, value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Zmax { get; set; }

    /// <summary>
    ///     The minimum possible z, or elevation, value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Zmin { get; set; }

    /// <summary>
    ///     The maximum possible m value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Mmax { get; set; }

    /// <summary>
    ///     The minimum possible m value in an extent envelope.
    /// </summary>
    [Parameter]
    public double? Mmin { get; set; }

    /// <inheritdoc />
    public override string Type => "extent";
}