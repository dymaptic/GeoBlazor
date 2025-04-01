namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class LegendWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Legend;


    /// <summary>
    /// Indicates the style of the legend. The style determines the legend's layout and behavior.
    /// You can either specify a string or an object to indicate the style.
    /// The known string values are the same values listed in the table within the type property.
    /// <a target="_blank" href=" https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Legend.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public LegendStyle? Style { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LegendStyle style:
                Style = style;

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
            case LegendStyle _:
                Style = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}

