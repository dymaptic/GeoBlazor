using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     An item (a unit of content) in the Portal. Each item has a unique identifier and a well known URL that is
///     independent of the user owning the item. An item may have associated binary or textual data which is available via
///     the item data resource. View the ArcGIS portal API REST documentation for the item for more details.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class PortalItem : MapComponent
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

    /// <summary>
    ///     The portal that contains the item. It uses Portal.getDefault().
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Portal? Portal { get; set; }


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Portal portal:
                Portal = portal;

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
            case Portal _:
                Portal = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Portal?.ValidateRequiredChildren();
    }
}