﻿namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleMarkerSymbol is used for rendering 2D Point geometries with a simple shape and color in either a MapView or a
///     SceneView. It may be filled with a solid color and have an optional outline, which is defined with a
///     SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleMarkerSymbol : MarkerSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleMarkerSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleMarkerSymbol in code with parameters
    /// </summary>
    /// <param name="outline">
    ///     The outline of the marker symbol.
    /// </param>
    /// <param name="color">
    ///     The color of the marker symbol.
    /// </param>
    /// <param name="size">
    ///     The size of the marker in points.
    /// </param>
    /// <param name="style">
    ///     The marker style.
    /// </param>
    /// <param name="angle">
    ///     The angle of the marker relative to the screen in degrees.
    /// </param>
    /// <param name="xOffset">
    ///     The offset on the x-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </param>
    /// <param name="yOffset">
    ///     The offset on the y-axis in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </param>
    public SimpleMarkerSymbol(Outline? outline = null, MapColor? color = null, Dimension? size = null,
        SimpleMarkerSymbolStyle? style = null, double? angle = null, Dimension? xOffset = null, Dimension? yOffset = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Outline = outline;
        Color = color;
        Size = size;
        Angle = angle;
        XOffset = xOffset;
        YOffset = yOffset;
        Style = style;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     The outline of the marker symbol.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }

    /// <summary>
    ///     The size of the marker in points. This value may be autocast with a string expressing size in points or pixels (e.g. 12px).
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dimension? Size { get; set; }

    /// <inheritdoc />
    public override SymbolType Type => SymbolType.SimpleMarker;

    /// <summary>
    ///     The marker style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public SimpleMarkerSymbolStyle? Style { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                }

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }

    internal override SymbolSerializationRecord ToSerializationRecord()
    {
        return new SymbolSerializationRecord(Type.ToString().ToKebabCase(), Color)
        {
            Outline = Outline?.ToSerializationRecord(),
            Size = Size?.Points,
            Style = Style?.ToString().ToKebabCase(),
            Angle = Angle,
            XOffset = XOffset?.Points,
            YOffset = YOffset?.Points
        };
    }
}