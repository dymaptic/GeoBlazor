namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class TrackWidget : ProWidget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Track;
    
    /// <summary>
    ///     Indicates whether the widget will automatically navigate the view to the user's position when a geolocation result is found. Set to false to disable this behavior, leaving full control to the developer.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    public bool? GoToLocationEnabled { get; set; }
    
    /// <summary>
    ///     Indicates whether the widget will automatically rotate to the device heading based on the Geolocation APIs GeolocationCoordinates.heading property. The map will not rotate if the speed is 0, or if the device is unable to provide heading information.
    ///     Set to false to disable this behavior.
    ///     Default Value:true
    /// </summary>
    [Parameter]
    public bool? RotationEnabled { get; set; }
    
    /// <summary>
    ///     Indicates the scale to set on the view when navigating to the position of the geolocated result, after a location is returned from the track event.
    ///     By default, the view will navigate to a scale of 2500 for 3D and 4514 for 2D. To override the default in 2D, set the scale property and also set snapToZoom to false. For 2D views the value should be within the effectiveMinScale and effectiveMaxScale.
    /// </summary>
    [Parameter]
    public double? Scale { get; set; }

    /// <summary>
    ///     Controls how often the events are fired.
    /// </summary>
    [Parameter]
    public int EventRateLimitInMilliseconds { get; set; } = 100;
    
    /// <summary>
    ///     This function provides the ability to override either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#goTo">MapView goTo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#goTo">SceneView goTo()</a> methods.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GoTo.html#goToOverride">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public GoToOverride? GoToOverride { get; set; }
    
    /// <summary>
    ///    JS-invokable method that triggers the <see cref="GoToOverride"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsGoToOverride(IJSStreamReference jsStreamRef)
    {
        GoToOverrideParameters? goToParameters = await jsStreamRef.ReadJsStreamReference<GoToOverrideParameters>();
        if (GoToOverride is not null && goToParameters is not null)
        {
            await GoToOverride.Invoke(goToParameters);
        }
    }
}