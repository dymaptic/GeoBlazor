namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class FeatureFormWidget: ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.FeatureForm;


    /// <summary>
    ///     Controls how often the events are fired.
    /// </summary>
    [Parameter]
    [CodeGenerationIgnore]
    public int EventRateLimitInMilliseconds { get; set; } = 100;
}

