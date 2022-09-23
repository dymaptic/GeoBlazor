using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Popups;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class Graphic : LayerObject
{
    public Attributes? Attributes { get; set; }

    public Geometry? Geometry { get; set; }

    public int? GraphicIndex { get; set; }

    public PopupTemplate? PopupTemplate { get; set; }

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Attributes attributes:
                if (!attributes.Equals(Attributes))
                {
                    Attributes = attributes;
                    await UpdateComponent();
                }

                break;
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

    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Attributes _:
                Attributes = null;

                break;
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
    
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Attributes?.ValidateRequiredChildren();
        Geometry?.ValidateRequiredChildren();
        PopupTemplate?.ValidateRequiredChildren();
    }

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