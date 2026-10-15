namespace dymaptic.GeoBlazor.Pro.Components;

public partial class AttachmentsCapabilities : MapComponent
{


    /// <summary>
    ///     Indicates whether to allow attachment editing. The feature layer must be enabled to support editing. Default value is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Editing { get; set; }

}


