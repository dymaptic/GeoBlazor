namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class BasemapToggleWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.BasemapToggle;

    /// <summary>
    ///     The name of the next basemap for toggling.
    /// </summary>
    /// <remarks>
    ///     Set either <see cref="NextBasemapName" /> or <see cref="NextBasemap" />
    /// </remarks>
    [Parameter]
    [Obsolete("Use NextBasemapStyle instead")]
    [RequiredProperty(nameof(NextBasemap), nameof(NextBasemapStyle))]
    public string? NextBasemapName { get; set; }
    
    /// <summary>
    ///     The next <see cref="BasemapStyleName" /> for toggling.
    /// </summary>
    [Parameter]
#pragma warning disable CS0618 // Type or member is obsolete
    [RequiredProperty(nameof(NextBasemapName), nameof(NextBasemap))]
#pragma warning restore CS0618 // Type or member is obsolete
    public BasemapStyleName? NextBasemapStyle { get; set; }


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Basemap basemap:
                NextBasemap = basemap;

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
            case Basemap _:
                NextBasemap = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}