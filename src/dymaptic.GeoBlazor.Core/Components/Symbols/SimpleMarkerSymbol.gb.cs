// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Symbols;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html">GeoBlazor Docs</a>
///     SimpleMarkerSymbol is used for rendering 2D <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Point.html">Point</a> geometries
///     with a simple shape and <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#color">color</a> in either a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a>
///     or a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SimpleMarkerSymbol : ISymbol2D,
    ISymbolsMarkerSymbol
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleMarkerSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="outline">
    ///     The outline of the marker symbol.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#outline">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="color">
    ///     The color of the symbol.
    ///     default [255, 255, 255, 0.25] - white, semitransparent
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="size">
    ///     The size of the marker in points.
    ///     default 12
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#size">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     The marker style.
    ///     default "circle"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="angle">
    ///     The angle of the marker relative to the screen in degrees.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html#angle">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="xoffset">
    ///     The offset on the x-axis in points.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html#xoffset">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="yoffset">
    ///     The offset on the y-axis in points.
    ///     default 0
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-MarkerSymbol.html#yoffset">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="path">
    ///     The SVG path of the icon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#path">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SimpleMarkerSymbol(
        Outline? outline = null,
        MapColor? color = null,
        Dimension? size = null,
        SimpleMarkerSymbolStyle? style = null,
        double? angle = null,
        Dimension? xoffset = null,
        Dimension? yoffset = null,
        string? path = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Outline = outline;
        Color = color;
        Size = size;
        Style = style;
        Angle = angle;
        Xoffset = xoffset;
        Yoffset = yoffset;
        Path = path;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html#simplemarkersymboloutline-property">GeoBlazor Docs</a>
    ///     The outline of the marker symbol.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#outline">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Outline? Outline { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Symbols.SimpleMarkerSymbol.html#simplemarkersymbolpath-property">GeoBlazor Docs</a>
    ///     The SVG path of the icon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleMarkerSymbol.html#path">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Path { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Outline property.
    /// </summary>
    public async Task<Outline?> GetOutline()
    {
        if (CoreJsModule is null)
        {
            return Outline;
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
            return Outline;
        }

        // get the property value
        Outline? result = await JsComponentReference!.InvokeAsync<Outline?>("getProperty",
            CancellationTokenSource.Token, "outline");
        if (result is not null)
        {
#pragma warning disable BL0005
             Outline = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Outline)] = Outline;
        }
         
        return Outline;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Path property.
    /// </summary>
    public async Task<string?> GetPath()
    {
        if (CoreJsModule is null)
        {
            return Path;
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
            return Path;
        }

        // get the property value
        string? result = await JsComponentReference!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, "path");
        if (result is not null)
        {
#pragma warning disable BL0005
             Path = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Path)] = Path;
        }
         
        return Path;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Size property.
    /// </summary>
    public async Task<Dimension?> GetSize()
    {
        if (CoreJsModule is null)
        {
            return Size;
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
            return Size;
        }

        // get the property value
        Dimension? result = await JsComponentReference!.InvokeAsync<Dimension?>("getProperty",
            CancellationTokenSource.Token, "size");
        if (result is not null)
        {
#pragma warning disable BL0005
             Size = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Size)] = Size;
        }
         
        return Size;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Style property.
    /// </summary>
    public async Task<SimpleMarkerSymbolStyle?> GetStyle()
    {
        if (CoreJsModule is null)
        {
            return Style;
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
            return Style;
        }

        // get the property value
        JsNullableEnumWrapper<SimpleMarkerSymbolStyle>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<SimpleMarkerSymbolStyle>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "style");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Style = (SimpleMarkerSymbolStyle)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Style)] = Style;
        }
         
        return Style;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Outline property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetOutline(Outline? value)
    {
#pragma warning disable BL0005
        Outline = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Outline)] = value;
        
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
            JsComponentReference, "outline", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Path property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPath(string? value)
    {
#pragma warning disable BL0005
        Path = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Path)] = value;
        
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
            JsComponentReference, "path", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Size property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSize(Dimension? value)
    {
#pragma warning disable BL0005
        Size = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Size)] = value;
        
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
            JsComponentReference, "size", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Style property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStyle(SimpleMarkerSymbolStyle? value)
    {
#pragma warning disable BL0005
        Style = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Style)] = value;
        
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
            JsComponentReference, "style", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline outline:
                if (outline != Outline)
                {
                    Outline = outline;
                    ModifiedParameters[nameof(Outline)] = Outline;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    /// <inheritdoc />
    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Outline _:
                Outline = null;
                ModifiedParameters[nameof(Outline)] = Outline;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Outline?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
