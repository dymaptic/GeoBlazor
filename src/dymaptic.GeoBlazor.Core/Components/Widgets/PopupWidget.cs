namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class PopupWidget : Widget
{
    /// <summary>
    ///     Defines actions that may be executed by clicking the icon or image symbolizing them in the popup. By default, every popup has a zoom-to action styled with a magnifying glass icon. When this icon is clicked, the view zooms in four LODs and centers on the selected feature.
    /// </summary>
    [CodeGenerationIgnore]
    [Parameter]
    public IReadOnlyList<ActionBase>? Actions { get; set; }

    /// <summary>
    ///     Position of the popup in relation to the selected feature. The default behavior is to display above the feature and adjust if not enough room. If needing to explicitly control where the popup displays in relation to the feature, choose an option besides auto.
    /// </summary>
    [Parameter]
    public PopupAlignment? Alignment { get; set; }

    /// <summary>
    ///     This closes the popup when the View camera or Viewpoint changes.
    /// </summary>
    [Parameter]
    public bool? AutoCloseEnabled { get; set; }

    /// <summary>
    ///     This property indicates to the Popup that it needs to allow or disallow the click event propagation. Use view.popup.autoOpenEnabled = false; when needing to stop the click event propagation.
    ///     DefaultValue: true
    /// </summary>
    [Parameter]
    [Obsolete("Use MapView.PopupEnabled instead")]
    public bool? AutoOpenEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the popup displays its content. If true, only the header displays.
    /// </summary>
    [Parameter]
    public bool? Collapsed { get; set; }

    /// <summary>
    ///     Indicates whether to enable collapse functionality for the popup.
    ///     DefaultValue: true
    /// </summary>
    [Parameter]
    [Obsolete("Deprecated since GeoBlazor v4. Use PopupVisibleElements.CollapseButton instead.")]
    public bool? CollapseEnabled { get; set; }

    /// <summary>
    ///     The html string content of the popup. When set directly on the Popup, this content is static and cannot use fields to set content templates. To set a template for the content based on field or attribute names, see <see cref="PopupTemplate.Content" />.
    /// </summary>
    [Parameter]
    public string? StringContent { get; set; }

    /// <summary>
    ///     Enables automatic creation of a popup template for layers that have popups enabled but no popupTemplate defined.
    ///     Automatic popup templates are supported for layers that support the createPopupTemplate method. (Supported for
    ///     FeatureLayer, GeoJSONLayer, OGCFeatureLayer, SceneLayer, CSVLayer, PointCloudLayer, StreamLayer, and ImageryLayer).
    /// </summary>
    [Parameter]
    public bool? DefaultPopupTemplateEnabled { get; set; }

    /// <summary>
    ///     Indicates whether the placement of the popup is docked to the side of the view.
    ///     Docking the popup allows for a better user experience, particularly when opening popups in apps on mobile devices.
    ///     When a popup is "dockEnabled" it means the popup no longer points to the selected feature or the location assigned
    ///     to it. Rather it is attached to a side, the top, or the bottom of the view.
    ///     See <see cref="DockOptions" /> to override default options related to docking the popup.
    /// </summary>
    [Parameter]
    public bool? DockEnabled { get; set; }

    /// <summary>
    ///     Indicates the heading level to use for the title of the popup. By default, the title is rendered as a level 2 heading (e.g. <h2>Popup title</h2>). Depending on the widget's placement in your app, you may need to adjust this heading for proper semantics. This is important for meeting accessibility standards.
    ///     DefaultValue:2
    /// </summary>
    [Parameter]
    public int? HeadingLevel { get; set; }

    /// <summary>
    ///     Highlight the selected popup feature using the highlightOptions set on the MapView or the highlightOptions set on the SceneView.
    /// </summary>
    [Parameter]
    public bool? HighlightEnabled { get; set; }


    /// <summary>
    ///     Defines the maximum icons displayed at one time in the action area.
    ///     DefaultValue: 3
    /// </summary>
    [Parameter]
    public int? MaxInlineActions { get; set; }

    /// <summary>
    ///     Indicates whether to display a spinner at the popup location prior to its display when it has pending promises.
    /// </summary>
    [Parameter]
    [Obsolete("Deprecated since GeoBlazor v4. Use PopupVisibleElements.Spinner instead.")]
    public bool? SpinnerEnabled { get; set; }

    /// <summary>
    ///     The title of the popup. This can be set generically on the popup no matter the features that are selected. If the selected feature has a PopupTemplate, then the title set in the corresponding template is used here.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }


    /// <inheritdoc />
    public override WidgetType Type => WidgetType.Popup;
    
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
    ///     The selected feature accessed by the popup. The content of the Popup is determined based on the PopupTemplate assigned to this feature.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Graphic?> GetSelectedFeature()
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        IJSStreamReference streamRef = await JsComponentReference!.InvokeAsync<IJSStreamReference>(
            "getSelectedFeature", CancellationTokenSource.Token);
        SelectedFeature = await ReadJsStreamReference<Graphic?>(streamRef);
        return SelectedFeature;
    }

    /// <summary>
    ///     Sets the string content of the popup.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task SetContent(string stringContent)
    {
        if (CoreJsModule is null)
        {
            return;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync("setContent", CancellationTokenSource.Token, stringContent);
    }

    /// <summary>
    ///     Removes promises, features, content, title and location from the Popup.
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task Clear()
    {
        if (CoreJsModule is null)
        {
            return;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync("clear", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Use this method to return feature(s) at a given screen location. These features are fetched from all of the LayerViews in the view. In order to use this, a layer must already have an associated PopupTemplate and have its popupEnabled. These features can then be used within a custom Popup or Feature widget experience.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Graphic[]?> FetchFeatures()
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        return await JsComponentReference!.InvokeAsync<Graphic[]>("fetchFeatures", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     The number of selected features available to the popup.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<int?> GetFeatureCount()
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        return await JsComponentReference!.InvokeAsync<int>("getFeatureCount", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<int?> GetSelectedFeatureIndex()
    {
        if (CoreJsModule is null)
        {
            return null;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        return await JsComponentReference!.InvokeAsync<int>("getSelectedFeatureIndex", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     Index of the feature that is selected. When features are set, the first index is automatically selected.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<bool?> GetVisibility()
    {
        if (CoreJsModule is null)
        {
            return Visible;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return null;
        }
        
        return await JsComponentReference!.InvokeAsync<bool>("getVisibility", CancellationTokenSource.Token);
    }


    /// <summary>
    ///     Closes the popup by setting its visible property to false. Users can alternatively close the popup by directly setting the visible property to false.
    /// </summary>
    [ArcGISMethod]
    [CodeGenerationIgnore]
    public async Task Close()
    {
        if (CoreJsModule is null)
        {
            return;
        }
        try 
        {
            JsComponentReference ??= await CoreJsModule!.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
                                        
        if (JsComponentReference is null)
        {
            return;
        }
        
        await JsComponentReference!.InvokeVoidAsync("close", CancellationTokenSource.Token);
    }

    /// <summary>
    ///     JS-invokable method for triggering actions.
    /// </summary>
    [JSInvokable]
    [CodeGenerationIgnore]
    public async Task OnJsTriggerAction(IJSStreamReference jsStreamRef)
    {
        await using Stream stream = await jsStreamRef.OpenReadStreamAsync(1_000_000_000L);
        await using MemoryStream ms = new();
        await stream.CopyToAsync(ms);
        ms.Seek(0, SeekOrigin.Begin);
        byte[] encodedJson = ms.ToArray();
        string json = Encoding.UTF8.GetString(encodedJson);
        PopupTriggerActionEvent triggerActionEvent = JsonSerializer.Deserialize<PopupTriggerActionEvent>(
            json, GeoBlazorSerialization.JsonSerializerOptions)!;
        if (Actions is null)
        {
            return;
        }
        
        foreach (ActionBase action in Actions)
        {
            if (action.ActionId == triggerActionEvent.Action.ActionId && action.CallbackFunction is not null)
            {
                await action.CallbackFunction.Invoke();
            }
        }
        
        await OnTriggerAction.InvokeAsync(triggerActionEvent);
    }
    
    /// <summary>
    ///     Event Listener for TriggerAction.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    [CodeGenerationIgnore]
    public EventCallback<PopupTriggerActionEvent> OnTriggerAction { get; set; }
    
    /// <summary>
    ///     Override the default symbol of the displayed cluster extent. Only applies when a PopupTemplate is set on a FeatureReductionCluster instance.
    /// </summary>
    public async Task SetSelectedClusterBoundaryFeatureSymbol(Symbol symbol)
    {
        await JsComponentReference!.InvokeVoidAsync("setSelectedClusterBoundaryFeatureSymbol",
            symbol);
    }
}