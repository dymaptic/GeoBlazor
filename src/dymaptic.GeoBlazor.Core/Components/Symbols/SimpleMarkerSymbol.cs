using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Symbols;

/// <summary>
///     SimpleMarkerSymbol is used for rendering 2D Point geometries with a simple shape and color in either a MapView or a SceneView. It may be filled with a solid color and have an optional outline, which is defined with a SimpleLineSymbol.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">ArcGIS JS API</a>
/// </summary>
public class SimpleMarkerSymbol : MarkerSymbol
{
    /// <summary>
    ///     The outline of the marker symbol.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }

    /// <summary>
    ///     The size of the marker in points.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <inheritdoc />
    public override string Type => "simple-marker";

    /// <summary>
    ///     The marker style.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [Parameter]
    public string? Style { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (!outline.Equals(Outline))
                {
                    Outline = outline;
                    await UpdateComponent();
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
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Outline?.ValidateRequiredChildren();
    }
}