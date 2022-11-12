using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Geometries;

/// <summary>
///     The minimum and maximum X and Y coordinates of a bounding box. Extent is used to describe the visible portion of a MapView. When working in a SceneView, Camera is used to define the visible part of the map within the view.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">ArcGIS JS API</a>
/// </summary>
public class Extent : Geometry
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public Extent()
    {
    }

    /// <summary>
    ///     Creates a new Extent in code with parameters
    /// </summary>
    /// <param name="xmax">
    ///     The maximum X-coordinate of an extent envelope.
    /// </param>
    /// <param name="xmin">
    ///     The minimum X-coordinate of an extent envelope.
    /// </param>
    /// <param name="ymax">
    ///     The maximum Y-coordinate of an extent envelope.
    /// </param>
    /// <param name="ymin">
    ///     The minimum Y-coordinate of an extent envelope.
    /// </param>
    /// <param name="zmax">
    ///     The maximum possible z, or elevation, value in an extent envelope.
    /// </param>
    /// <param name="zmin">
    ///     The minimum possible z, or elevation, value in an extent envelope.
    /// </param>
    /// <param name="mmax">
    ///     The maximum possible m value in an extent envelope.
    /// </param>
    /// <param name="mmin">
    ///     The minimum possible m value in an extent envelope.
    /// </param>
    /// <param name="spatialReference">
    ///     The <see cref="SpatialReference"/> of the geometry.
    /// </param>
    public Extent(double xmax, double xmin, double ymax, double ymin, double? zmax = null, double? zmin = null,
        double? mmax = null, double? mmin = null, SpatialReference? spatialReference = null)
    {
#pragma warning disable BL0005
        Xmax = xmax;
        Xmin = xmin;
        Ymax = ymax;
        Ymin = ymin;
        Zmax = zmax;
        Zmin = zmin;
        Mmax = mmax;
        Mmin = mmin;
        SpatialReference = spatialReference;
#pragma warning restore BL0005
    }
    
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