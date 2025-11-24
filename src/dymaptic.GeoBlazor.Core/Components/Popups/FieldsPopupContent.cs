namespace dymaptic.GeoBlazor.Core.Components.Popups;

[ProtobufSerializable]
public partial class FieldsPopupContent : PopupContent
{
    /// <summary>
    ///     Describes the field's content in detail.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    /// <summary>
    ///     Heading indicating what the field's content represents.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <inheritdoc />
    public override PopupContentType Type => PopupContentType.Fields;


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfo fieldInfo:
                FieldInfos ??= [];
                FieldInfos = [..FieldInfos, fieldInfo];

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
                FieldInfos = FieldInfos?.Except([fieldInfo]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }


    /// <inheritdoc />
    public override PopupContentSerializationRecord ToProtobuf()
    {
        return new PopupContentSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase())
        {
            FieldInfos = FieldInfos?.Select(i => i.ToProtobuf()).ToArray(), 
            Description = Description, Title = Title
        };
    }
}