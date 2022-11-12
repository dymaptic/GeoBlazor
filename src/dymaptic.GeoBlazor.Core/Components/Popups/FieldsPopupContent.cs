namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A FieldsContent popup element represents the FieldInfo associated with a feature. If this is not set within the content, it will revert to whatever may be set within the PopupTemplate.fieldInfos property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-FieldsContent.html">ArcGIS JS API</a>
/// </summary>
public class FieldsPopupContent : PopupContent
{
    /// <summary>
    ///     Parameterless constructor for using as a razor component
    /// </summary>
    public FieldsPopupContent()
    {
    }

    /// <summary>
    ///     Constructs a new PopupContent in code with parameters
    /// </summary>
    /// <param name="fieldInfos">
    ///     A collection of <see cref="FieldInfo"/>
    /// </param>
    public FieldsPopupContent(params FieldInfo[] fieldInfos)
    {
#pragma warning disable BL0005
        foreach (FieldInfo info in fieldInfos)
        {
            FieldInfos.Add(info);
        }
#pragma warning restore BL0005
    }
    
    /// <inheritdoc />
    public override string Type => "fields";

    /// <summary>
    ///     Array of <see cref="FieldInfo"/>s
    /// </summary>
    public HashSet<FieldInfo> FieldInfos { get; set; } = new();

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        foreach (FieldInfo info in FieldInfos)
        {
            info.ValidateRequiredChildren();
        }
    }
}