using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Popups;

public class PopupTemplate : MapComponent
{
    [Parameter]
    [RequiredProperty(nameof(Content))]
    public string? StringContent { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [RequiredProperty(nameof(StringContent))]
    public HashSet<PopupContent> Content { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupContent popupContent:
                if (!Content.Contains(popupContent))
                {
                    Content.Add(popupContent);
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
            case PopupContent popupContent:
                if (Content.Contains(popupContent))
                {
                    Content.Remove(popupContent);
                }

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        foreach (PopupContent item in Content)
        {
            item.ValidateRequiredChildren();
        }
    }
}