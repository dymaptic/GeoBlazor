using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     A FieldsContent popup element represents the FieldInfo associated with a feature. If this is not set within the
///     content, it will revert to whatever may be set within the PopupTemplate.fieldInfos property.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-FieldsContent.html">
///         ArcGIS
///         JS API
///     </a>
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
    ///     A collection of <see cref="FieldInfo" />
    /// </param>
    /// <param name="description">
    ///     Describes the field's content in detail.
    /// </param>
    /// <param name="title">
    ///     Heading indicating what the field's content represents.
    /// </param>
    public FieldsPopupContent(FieldInfo[] fieldInfos, string? description = null, string? title = null)
    {
#pragma warning disable BL0005
        if (fieldInfos.Any())
        {
            FieldInfos = new HashSet<FieldInfo>();

            foreach (FieldInfo info in fieldInfos)
            {
                FieldInfos.Add(info);
            }
        }

        Description = description;
        Title = title;
#pragma warning restore BL0005
    }

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
    public override string Type => "fields";

    /// <summary>
    ///     Array of <see cref="FieldInfo" />s
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<FieldInfo>? FieldInfos { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldInfo fieldInfo:
                FieldInfos ??= new HashSet<FieldInfo>();

                if (!FieldInfos.Contains(fieldInfo))
                {
                    FieldInfos.Add(fieldInfo);
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
                if (FieldInfos?.Contains(fieldInfo) == true)
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

        if (FieldInfos != null)
        {
            foreach (FieldInfo info in FieldInfos)
            {
                info.ValidateRequiredChildren();
            }
        }
    }

    internal override PopupContentSerializationRecord ToSerializationRecord()
    {
        return new PopupContentSerializationRecord(Type)
        {
            FieldInfos = FieldInfos?.ToArray(), 
            Description = Description, 
            Title = Title
        };
    }
}