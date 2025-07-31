namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class HomeWidget : Widget
{
    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Home;
    
#region Event Handlers
    
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
    ///     A convenience property that signifies whether a custom <see cref="GoToOverride" /> function was registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoToOverride => GoToOverride is not null;

    /// <summary>
    ///     JavaScript-Invokable Method for internal use only.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    [ArcGISMethod]
    public async Task OnJsGo(IJSStreamReference jsStreamRef)
    {
        await using Stream stream = await jsStreamRef.OpenReadStreamAsync(1_000_000_000L);
        await using MemoryStream ms = new();
        await stream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);
        byte[] encodedJson = ms.ToArray();
        string json = Encoding.UTF8.GetString(encodedJson);
        HomeGoEvent goEvent = 
            JsonSerializer.Deserialize<HomeGoEvent>(json, 
                GeoBlazorSerialization.JsonSerializerOptions)!;
        View!.ExtentChangedInJs = true;
        await OnGo.InvokeAsync(goEvent);
    }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Widgets.HomeWidget.html#homewidgetongo-property">GeoBlazor Docs</a>
    ///     Event Listener for Go.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<HomeGoEvent> OnGo { get; set; }
   
    /// <summary>
    ///     Used in JavaScript layer to determine if the event listener is registered.
    /// </summary>
    [CodeGenerationIgnore]
    public bool HasGoListener =>  true; // always return true, required event handler
    
#endregion

}