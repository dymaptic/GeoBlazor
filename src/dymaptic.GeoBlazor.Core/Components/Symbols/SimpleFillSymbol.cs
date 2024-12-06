using dymaptic.GeoBlazor.Core.Extensions;
using dymaptic.GeoBlazor.Core.Objects;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleFillSymbol is used for rendering 2D polygons in either a MapView or a SceneView. It can be filled with a
///     solid color, or a pattern. In addition, the symbol can have an optional outline, which is defined by a
///     SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleFillSymbol : FillSymbol
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public SimpleFillSymbol()
    {
    }

    /// <summary>
    ///     Constructs a new SimpleFillSymbol in code with parameters
    /// </summary>
    /// <param name="outline">
    ///     The outline of the polygon.
    /// </param>
    /// <param name="color">
    ///     The color of the polygon.
    /// </param>
    /// <param name="fillStyle">
    ///     The fill style.
    /// </param>
    public SimpleFillSymbol(Outline? outline = null, MapColor? color = null, FillStyle? fillStyle = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Outline = outline;
        Color = color;
        FillStyle = fillStyle;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The fill style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    [JsonPropertyName("style")]
    public FillStyle? FillStyle { get; set; }

    /// <inheritdoc />
    public override string Type => "simple-fill";

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
        return new SymbolSerializationRecord(Type, Color)
        {
            Outline = Outline?.ToSerializationRecord(), 
            Style = FillStyle?.ToString().ToKebabCase()
        };
    }
}

/// <summary>
///     The possible fill style for the <see cref="SimpleFillSymbol" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<FillStyle>))]
public enum FillStyle
{
#pragma warning disable CS1591
    BackwardDiagonal,
    Cross,
    DiagonalCross,
    ForwardDiagonal,
    Horizontal,
    None,
    Solid,
    Vertical
#pragma warning restore CS1591
}