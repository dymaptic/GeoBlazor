namespace dymaptic.GeoBlazor.Core.Components;

public partial class PortalItem : MapComponent
{
    /// <summary>
    ///     The unique id for the item.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [RequiredProperty]
    public new string Id { get; set; } = default!;

    /// <summary>
    ///     An authorization string used to access the portal item. API keys are generated and managed in the ArcGIS Developer Portal. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }

}