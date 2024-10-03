using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
/// Represents a sublayer in a WMTSLayer. 
/// <a target = "_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-WMTSSublayer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>

public class WMTSSublayer
{
    /// <summary>
    ///     Constructor for use as a razor component
    /// </summary>
    public WMTSSublayer()
    {
    }

    /// <summary>
    ///     Constructor for the WMTSSublayer class.
    /// </summary>
    /// <param name="description">
    ///     Description for the WMTS sublayer.
    /// </param>
    /// <param name="fullExtent">
    ///     The full extent of the sublayer.
    /// </param>
    /// <param name="id">
    ///     The unique id of the sublayer.
    /// </param>
    /// <param name="imageFormat">
    ///     The map image format (MIME type) to request.
    /// </param>
    /// <param name="imageFormats">
    ///     Supported image formats as retrieved from the GetCapabilities request.
    /// </param>
    /// <param name="layer">
    ///     The WMTSLayer to which the sublayer belongs.
    /// </param>
    /// <param name="parent">
    ///     The parent WMTSLayer to which the sublayer belongs.
    /// </param>
    /// <param name="styleId">
    ///     The WMTSStyle to request.
    /// </param>
    /// <param name="styles">
    ///     A collection of supported WMTSStyles as retrieved from the GetCapabilities request.
    /// </param>
    /// <param name="tileMatrixSet">
    ///     The TileMatrixSet to request.
    /// </param>
    /// <param name="tileMatrixSets">
    ///     A collection of supported TileMatrixSets.
    /// </param>
    /// <param name="tileMatrixSetId">
    ///     The id of the TileMatrixSet to request.
    /// </param>
    /// <param name="title">
    ///     The title of the WMTS sublayer used to identify it in places such as the LayerList and Legend widgets.
    /// </param>
    public WMTSSublayer(string? description, Extent? fullExtent, string? id, ImageFormat? imageFormat,
        ImageFormat[]? imageFormats, WMTSLayer? layer, WMTSLayer? parent, string? styleId, WMTSStyle[]? styles,
        TileMatrixSet? tileMatrixSet, TileMatrixSet[]? tileMatrixSets, string? tileMatrixSetId, string? title)
    {
        Description = description;
        FullExtent = fullExtent;
        Id = id;
        ImageFormat = imageFormat;
        ImageFormats = imageFormats;
        Layer = layer;
        Parent = parent;
        StyleId = styleId;
        Styles = styles;
        TileMatrixSet = tileMatrixSet;
        TileMatrixSets = tileMatrixSets;
        TileMatrixSetId = tileMatrixSetId;
        Title = title;
    }

    /// <summary>
    ///     Description for the WMTS sublayer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     The full extent of the sublayer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? FullExtent { get; set; }

    /// <summary>
    ///     The unique id of the sublayer.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    ///     The map image format (MIME type) to request.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageFormat? ImageFormat { get; set; }

    /// <summary>
    ///     Supported image formats as retrieved from the GetCapabilities request.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageFormat[]? ImageFormats { get; set; }

    /// <summary>
    ///     The WMTSLayer to which the sublayer belongs.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WMTSLayer? Layer { get; set; }

    /// <summary>
    ///     The parent WMTSLayer to which the sublayer belongs.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WMTSLayer? Parent { get; set; }

    /// <summary>
    ///     The WMTSStyle to request.
    /// </summary>
    public string? StyleId { get; set; }

    /// <summary>
    ///     A collection of supported WMTSStyles as retrieved from the GetCapabilities request.
    /// </summary>
    public WMTSStyle[]? Styles { get; set; }

    /// <summary>
    ///     The TileMatrixSet to request.
    /// </summary>
    public TileMatrixSet? TileMatrixSet { get; set; }

    /// <summary>
    ///     A collection of supported TileMatrixSets.
    /// </summary>
    public TileMatrixSet[]? TileMatrixSets { get; set; }

    /// <summary>
    ///     The id of the TileMatrixSet to request.
    /// </summary>
    public string? TileMatrixSetId { get; set; }

    /// <summary>
    ///     The title of the WMTS sublayer used to identify it in places such as the LayerList and Legend widgets.
    /// </summary>
    public string? Title { get; set; }
}
