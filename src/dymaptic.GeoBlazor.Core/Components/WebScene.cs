namespace dymaptic.GeoBlazor.Core.Components;

public partial class WebScene : Map, IPortalLayer
{
    /// <summary>
    /// ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public WebScene()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="applicationProperties">
    ///     Configuration of application and UI elements.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#applicationProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="authoringApp">
    ///     The name of the application that authored the WebScene.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#authoringApp">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="authoringAppVersion">
    ///     The version of the application that authored the WebScene.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#authoringAppVersion">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="clippingArea">
    ///     *This property only applies to local scenes.*
    ///     Represents an optional clipping area used to define the
    ///     bounds or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Extent.html">Extent</a> of a local scene.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#clippingArea">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="clippingEnabled">
    ///     *This property only applies to local scenes.*
    ///     Determines whether clipping using the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#clippingArea">clippingArea</a> is
    ///     enabled.
    ///     default false
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#clippingEnabled">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="floorInfo">
    ///     When a web scene is configured as floor-aware, it has a floorInfo property defined.
    ///     default null
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#floorInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="heightModelInfo">
    ///     The height model info of the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html">WebScene</a>.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#heightModelInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="initialViewProperties">
    ///     The initial view of the WebScene.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#initialViewProperties">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="portalItem">
    ///     The portal item from which the WebScene is loaded.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#portalItem">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="presentation">
    ///     Provides a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-Collection.html">Collection</a> of slides
    ///     that act as bookmarks for saving predefined <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Viewpoint.html">viewpoints</a>
    ///     and visible layers.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#presentation">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="thumbnailUrl">
    ///     The URL to the thumbnail used for the web scene.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#thumbnailUrl">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="widgets">
    ///     The widgets object contains widgets that are exposed to the user.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#widgets">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// [CodeGenerationIgnore]
    public WebScene(WebsceneApplicationProperties? applicationProperties = null,
        string? authoringApp = null,
        string? authoringAppVersion = null,
        Extent? clippingArea = null,
        bool? clippingEnabled = null,
        MapFloorInfo? floorInfo = null,
        HeightModelInfo? heightModelInfo = null,
        WebsceneInitialViewProperties? initialViewProperties = null,
        PortalItem? portalItem = null,
        IPresentation? presentation = null,
        string? thumbnailUrl = null,
        WebSceneWidgets? widgets = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        ApplicationProperties = applicationProperties;
        AuthoringApp = authoringApp;
        AuthoringAppVersion = authoringAppVersion;
        ClippingArea = clippingArea;
        ClippingEnabled = clippingEnabled;
        FloorInfo = floorInfo;
        HeightModelInfo = heightModelInfo;
        InitialViewProperties = initialViewProperties;
        PortalItem = portalItem;
        Presentation = presentation;
        ThumbnailUrl = thumbnailUrl;
        Widgets = widgets;
#pragma warning restore BL0005
    }
    

    /// <summary>
    ///     The portal item from which the WebScene is loaded.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-WebScene.html#portalItem">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [RequiredProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [CodeGenerationIgnore]
    public PortalItem? PortalItem { get; set; } = null!;
    
    /// <summary>
    ///    Asynchronously set the value of the PortalItem property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPortalItem(PortalItem? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        PortalItem = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(PortalItem)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
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
        
        await JsComponentReference.InvokeVoidAsync("setPortalItem", 
            CancellationTokenSource.Token, value);
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the PortalItem property.
    /// </summary>
    public async Task<PortalItem?> GetPortalItem()
    {
        if (CoreJsModule is null)
        {
            return PortalItem;
        }
        
        try 
        {
            JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
                "getJsComponent", CancellationTokenSource.Token, Id);
        }
        catch (JSException)
        {
            // this is expected if the component is not yet built
        }
        
        if (JsComponentReference is null)
        {
            return PortalItem;
        }

        PortalItem? result = await JsComponentReference.InvokeAsync<PortalItem?>(
            "getPortalItem", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (PortalItem is not null)
            {
                result.Id = PortalItem.Id;
            }
            
#pragma warning disable BL0005
            PortalItem = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(PortalItem)] = PortalItem;
        }
        
        return PortalItem;
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PortalItem portalItem:
                if (!portalItem.Equals(PortalItem))
                {
                    PortalItem = portalItem;
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
            case PortalItem _:
                PortalItem = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        PortalItem?.ValidateRequiredChildren();
    }
}