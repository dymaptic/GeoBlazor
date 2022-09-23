namespace dymaptic.Blazor.GIS.API.Core.Components.Popups;

public class FieldsPopupContent : PopupContent
{
    public override string Type => "fields";

    public HashSet<FieldInfo> FieldInfos { get; set; } = new();

    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfo fieldInfo:
                if (!FieldInfos.Contains(fieldInfo))
                {
                    FieldInfos.Add(fieldInfo);
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
            case FieldInfo fieldInfo:
                if (FieldInfos.Contains(fieldInfo))
                {
                    FieldInfos.Remove(fieldInfo);
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

        foreach (FieldInfo info in FieldInfos)
        {
            info.ValidateRequiredChildren();
        }
    }
}