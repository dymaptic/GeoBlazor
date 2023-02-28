using Microsoft.AspNetCore.Components;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     An item (a unit of content) in the Portal. Each item has a unique identifier and a well known URL that is
///     independent of the user owning the item. An item may have associated binary or textual data which is available via
///     the item data resource. View the ArcGIS portal API REST documentation for the item for more details.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-portal-PortalItem.html">
///         ArcGIS
///         JS API
///     </a>
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
}