namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BasemapGalleryWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.BasemapGallery;

    /// <summary>
    ///     The title to query against the source.
    /// </summary>
    /// <remarks>
    ///     Use either <see cref="Title" /> or <see cref="PortalBasemapsSource" /> to define the query.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; } = "\"World Basemaps for Developers\" AND owner:esri";

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case IBasemapGalleryWidgetSource src:
                if (!src.Equals(Source))
                {
                    Source = src;

                    if (MapRendered)
                    {
                        await UpdateWidget();
                    }
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
            case IBasemapGalleryWidgetSource _:
                Source = null;
                

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}