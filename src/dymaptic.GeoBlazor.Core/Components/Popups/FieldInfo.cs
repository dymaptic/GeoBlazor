using Microsoft.AspNetCore.Components;

namespace dymaptic.GeoBlazor.Core.Components.Popups;

public class FieldInfo : MapComponent
{
    [Parameter]
    public string? FieldName { get; set; }
    [Parameter]
    public string? Label { get; set; }
    [Parameter]
    public bool IsEditable { get; set; }

    [Parameter]
    public string Tooltip { get; set; } = string.Empty;

    [Parameter]
    public bool Visible { get; set; }
    [Parameter]
    public string? StringFieldOption { get; set; }

    public FieldInfoFormat? Format { get; set; }
    
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfoFormat format:
                if (!((Object)format).Equals(Format))
                {
                    Format = format;
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
            case FieldInfoFormat:
                Format = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
    
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Format?.ValidateRequiredChildren();
    }
}