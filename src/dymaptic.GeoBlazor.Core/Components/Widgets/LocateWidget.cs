namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class LocateWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Locate;
    
    /// <summary>
    ///    Indicates whether the widget will automatically rotate to the device heading based on the Geolocation APIs GeolocationCoordinates.heading property. The map will not rotate if the speed is 0, or if the device is unable to provide heading information.
    ///     Set to false to disable this behavior. Default Value:true
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RotationEnabled { get; set; }

    /// <summary>
    ///     Indicates the scale to set on the view when navigating to the position of the geolocated result once a location is
    ///     returned from the track event.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Scale { get; set; } = 2500;

    /// <summary>
    ///     This function provides the ability to override either the MapView goTo() or SceneView goTo() methods with your own implementation.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public GoToOverride? GoToOverride { get; set; }

    /// <summary>
    ///     Identifies whether a custom <see cref="GoToOverride" /> was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;
    
    /// <summary>
    ///     JavaScript-invokable method for internal use
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public Task OnJavaScriptGoToOverride(GoToOverrideParameters goToOverrideParams)
    {
        return GoToOverride?.Invoke(goToOverrideParams) ?? Task.CompletedTask;
    }
}