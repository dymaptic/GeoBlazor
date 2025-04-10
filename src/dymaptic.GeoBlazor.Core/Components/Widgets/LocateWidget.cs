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
    [Obsolete("Deprecated since GeoBlazor v4. Use Track widget instead")]
    public bool? RotationEnabled { get; set; }

    /// <summary>
    ///     Indicates the scale to set on the view when navigating to the position of the geolocated result once a location is
    ///     returned from the track event.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Scale { get; set; } = 2500;

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
    ///    JS-invokable method that triggers the <see cref = "GoToOverride"/> function.
    ///     Should not be called by consuming code.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsGoToOverride(IJSStreamReference jsStreamRef)
    {
        await using Stream stream = await jsStreamRef.OpenReadStreamAsync(1_000_000_000L);
        await using MemoryStream ms = new();
        await stream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);
        byte[] encodedJson = ms.ToArray();
        string json = Encoding.UTF8.GetString(encodedJson);
        GoToOverrideParameters goToParameters = JsonSerializer.Deserialize<GoToOverrideParameters>(
            json, GeoBlazorSerialization.JsonSerializerOptions)!;
        if (GoToOverride is not null)
        {
            await GoToOverride.Invoke(goToParameters);
        }
    }

    /// <summary>
    ///     Identifies whether a custom <see cref="GoToOverride" /> was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;
}