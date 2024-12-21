﻿namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     PictureMarkerSymbol renders Point graphics in either a 2D MapView or 3D SceneView using an image. A url must point
///     to a valid image. PictureMarkerSymbols may be applied to point features in a FeatureLayer or individual graphics.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-PictureMarkerSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class PictureMarkerSymbol : MarkerSymbol
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component
    /// </summary>
    public PictureMarkerSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    /// <param name="url">
    ///     The URL to an image or SVG document.
    /// </param>
    /// <param name="width">
    ///     The width of the image in points.
    /// </param>
    /// <param name="height">
    ///     The height of the image in points.
    /// </param>
    /// <param name="angle">
    ///     The angle of the marker relative to the screen in degrees.
    /// </param>
    /// <param name="xOffset">
    ///     The offset on the x-axis in points.
    /// </param>
    /// <param name="yOffset">
    ///     The offset on the y-axis in points.
    /// </param>
    public PictureMarkerSymbol(string url, Dimension? width = null, Dimension? height = null,
        double? angle = null, Dimension? xOffset = null, Dimension? yOffset = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Url = url;
        Width = width;
        Height = height;
        Angle = angle;
        XOffset = xOffset;
        YOffset = yOffset;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The height of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Height { get; set; }

    /// <summary>
    ///     The width of the image in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Width { get; set; }

    /// <inheritdoc />
    public override string Type => "picture-marker";

    /// <summary>
    ///     The URL to an image or SVG document.
    /// </summary>
    [Parameter]
    public string Url { get; set; } = default!;

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type, null)
        {
            Url = Url,
            Width = Width?.Points,
            Height = Height?.Points,
            Angle = Angle,
            XOffset = XOffset?.Points,
            YOffset = YOffset?.Points
        };
    }
}