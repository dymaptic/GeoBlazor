namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.MeshTexture.html">GeoBlazor Docs</a>
///     MeshTexture represents image data to be used for <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshMaterial.html">MeshMaterial</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshMaterialMetallicRoughness.html">MeshMaterialMetallicRoughness</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
[ProtobufSerializable]
public class MeshTexture : MapComponent, IProtobufSerializable<MeshTextureSerializationRecord>
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public MeshTexture()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="htmlData">
    ///     A direct reference to the image or video element.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#data">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="imageData">
    ///     A direct reference to the image data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#data">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="wrap">
    ///     Specifies how uv coordinates outside the [0, 1] range are handled.
    ///     default "repeat"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#wrap">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="transparent">
    ///     Indicates whether the image data should be interpreted as being semi-transparent.
    ///     default undefined
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#transparent">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="url">
    ///     The url to the image resource.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public MeshTexture(
        ElementReference? htmlData = null,
        ImageData? imageData = null,
        SeparableWrapModes? wrap = null,
        bool? transparent = null,
        string? url = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        HtmlData = htmlData;
        ImageData = imageData;
        Wrap = wrap;
        Transparent = transparent;
        Url = url;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     A direct reference to the image or video data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#data">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ElementReference? HtmlData { get; set; }
    
    /// <summary>
    ///     A direct reference to the image or video data.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#data">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageData? ImageData { get; set; }
    
    /// <summary>
    ///     Specifies how uv coordinates outside the [0, 1] range are handled.
    ///     default "repeat"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#wrap">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SeparableWrapModes? Wrap { get; set; }
    
    /// <summary>
    ///     Indicates whether the image data should be interpreted as being semi-transparent.
    ///     default undefined
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#transparent">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Transparent { get; set; }
    
    /// <summary>
    ///     The url to the image resource.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-support-MeshTexture.html#url">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the HtmlData property.
    /// </summary>
    public async Task<ElementReference?> GetHtmlData()
    {
        if (CoreJsModule is null)
        {
            return HtmlData;
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
            return HtmlData;
        }

        // get the property value
        JsNullableElementReferenceWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableElementReferenceWrapper?>(
            "getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "htmlData");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             HtmlData = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(HtmlData)] = HtmlData;
        }
         
        return HtmlData;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the ImageData property.
    /// </summary>
    public async Task<ImageData?> GetImageData()
    {
        if (CoreJsModule is null)
        {
            return ImageData;
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
            return ImageData;
        }

        // get the property value
        ImageData? result = await JsComponentReference!.InvokeAsync<ImageData?>("getProperty",
            CancellationTokenSource.Token, "data");
        if (result is not null)
        {
#pragma warning disable BL0005
             ImageData = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(ImageData)] = ImageData;
        }
         
        return ImageData;
    }
    
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the SeparableWrapModesWrap property.
    /// </summary>
    public async Task<SeparableWrapModes?> GetWrap()
    {
        if (CoreJsModule is null)
        {
            return Wrap;
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
            return Wrap;
        }

        // get the property value
        SeparableWrapModes? result = await JsComponentReference!.InvokeAsync<SeparableWrapModes?>("getProperty",
            CancellationTokenSource.Token, "wrap");
        if (result is not null)
        {
#pragma warning disable BL0005
             Wrap = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Wrap)] = Wrap;
        }
         
        return Wrap;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Transparent property.
    /// </summary>
    public async Task<bool?> GetTransparent()
    {
        if (CoreJsModule is null)
        {
            return Transparent;
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
            return Transparent;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "transparent");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Transparent = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Transparent)] = Transparent;
        }
         
        return Transparent;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Url property.
    /// </summary>
    public async Task<string?> GetUrl()
    {
        if (CoreJsModule is null)
        {
            return Url;
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
            return Url;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "url");
        if (result is not null)
        {
#pragma warning disable BL0005
             Url = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Url)] = Url;
        }
         
        return Url;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the HtmlData property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetHtmlData(ElementReference? value)
    {
#pragma warning disable BL0005
        HtmlData = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(HtmlData)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "data", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the ImageData property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetImageData(ImageData? value)
    {
#pragma warning disable BL0005
        ImageData = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(ImageData)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "data", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the SeparableWrapModesWrap property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSeparableWrapModesWrap(SeparableWrapModes? value)
    {
#pragma warning disable BL0005
        Wrap = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Wrap)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "wrap", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Transparent property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetTransparent(bool? value)
    {
#pragma warning disable BL0005
        Transparent = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Transparent)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "transparent", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Url property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetUrl(string? value)
    {
#pragma warning disable BL0005
        Url = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Url)] = value;
        
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
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "url", value);
    }
    
#endregion

    /// <inheritdoc />
    public MeshTextureSerializationRecord ToProtobuf()
    {
        return new MeshTextureSerializationRecord(ImageData?.ToProtobuf(),
            Wrap is null
                ? null
                : [
                    Wrap?.Horizontal?.ToString().ToKebabCase(), 
                    Wrap?.Vertical?.ToString().ToKebabCase()
                ],
            Transparent,
            Url);
    }
}
