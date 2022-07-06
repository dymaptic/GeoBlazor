using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Popups;

public class FieldInfo : MapComponent, IEquatable<FieldInfo>
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

    public bool Equals(FieldInfo? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        return ((Object)this).Equals(other) && (FieldName == other.FieldName) && (Label == other.Label) &&
            (IsEditable == other.IsEditable) && (Tooltip == other.Tooltip) && (Visible == other.Visible) &&
            (StringFieldOption == other.StringFieldOption);
    }

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

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        return Equals((FieldInfo)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), FieldName, Label, IsEditable, Tooltip, Visible, StringFieldOption);
    }
}