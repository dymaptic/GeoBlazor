using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Widgets;

/// <summary>
///     The BasemapGallery widget displays a collection images representing basemaps from ArcGIS.com or a user-defined set
///     of map or image services. When a new basemap is selected from the BasemapGallery, the map's basemap layers are
///     removed and replaced with the basemap layers of the associated basemap selected in the gallery.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-BasemapGallery.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BasemapGalleryWidget : Widget
{
    /// <inheritdoc />
    public override string WidgetType => "basemapGallery";

    /// <summary>
    ///     The title to query against the source.
    /// </summary>
    /// <remarks>
    ///     Use either <see cref="Title" /> or <see cref="PortalBasemapsSource" /> to define the query.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; } = "\"World Basemaps for Developers\" AND owner:esri";

    /// <summary>
    ///     The source for basemaps that the widget will display.
    /// </summary>
    /// <remarks>
    ///     Use either <see cref="Title" /> or <see cref="PortalBasemapsSource" /> to define the query.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PortalBasemapsSource? PortalBasemapsSource { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalBasemapsSource pbms:
                if (!pbms.Equals(PortalBasemapsSource))
                {
                    PortalBasemapsSource = pbms;
                    WidgetChanged = true;
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
            case PortalBasemapsSource _:
                PortalBasemapsSource = null;
                WidgetChanged = true;

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
        PortalBasemapsSource?.ValidateRequiredChildren();
    }
}