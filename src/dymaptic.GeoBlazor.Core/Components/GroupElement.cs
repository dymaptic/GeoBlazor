namespace dymaptic.GeoBlazor.Core.Components;

public partial class GroupElement : FormElement
{
    /// <inheritdoc/>
    public override string Type => "group";


    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements ??= [];
                Elements = [..Elements, fieldElement];
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements = Elements?.Except([fieldElement]).ToList();
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

}
