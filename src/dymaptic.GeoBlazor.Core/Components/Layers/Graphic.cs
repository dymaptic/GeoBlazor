using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     A Graphic is a vector representation of real world geographic phenomena. It can contain geometry, a symbol, and attributes. A Graphic is displayed in the GraphicsLayer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Graphic.html">ArcGIS JS API</a>
/// </summary>
public class Graphic : LayerObject
{
    /// <summary>
    ///     Name-value pairs of fields and field values associated with the graphic.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Attributes { get; set; }

    /// <summary>
    ///     The geometry that defines the graphic's location.
    /// </summary>
    public Geometry? Geometry { get; set; }

    /// <summary>
    ///     The position of the graphic in its parent layer's collection. 
    /// </summary>
    public int? GraphicIndex { get; set; }

    /// <summary>
    ///     The <see cref="PopupTemplate"/> for displaying content in a Popup when the graphic is selected.
    /// </summary>
    public PopupTemplate? PopupTemplate { get; set; }

    /// <summary>
    ///     Retrieves the <see cref="Geometry"/> from the rendered graphic.
    /// </summary>
    public async Task<Geometry> GetGeometry()
    {
        return await JsModule!.InvokeAsync<Geometry>("getGeometry", Id);
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Geometry geometry:
                if (!geometry.Equals(Geometry))
                {
                    Geometry = geometry;
                    await UpdateComponent();
                }

                break;
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
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
            case Geometry _:
                Geometry = null;

                break;
            case PopupTemplate _:
                PopupTemplate = null;

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
        Geometry?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
    }

    /// <inheritdoc />
    public override async Task UpdateComponent()
    {
        if (View is null || !MapRendered)
        {
            return;
        }

        int? layerIndex = null;

        if (Parent is Layer l)
        {
            layerIndex = l.LayerIndex;
        }

        await InvokeAsync(async () =>
        {
            await View!.UpdateGraphic(this, layerIndex);
        });
    }
}