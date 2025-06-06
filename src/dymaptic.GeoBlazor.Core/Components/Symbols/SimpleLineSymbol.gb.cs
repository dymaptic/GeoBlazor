// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Symbols;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Symbols.SimpleLineSymbol.html">GeoBlazor Docs</a>
///     SimpleLineSymbol is used for rendering 2D <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-geometry-Polyline.html">polyline geometries</a>
///     in a 2D <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SimpleLineSymbol : ISymbol2D
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleLineSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="color">
    ///     The color of the symbol.
    ///     default "black"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-Symbol.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="width">
    ///     The width of the symbol in points.
    ///     default 0.75
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbol.html#width">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     Specifies the line style.
    ///     default "solid"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="cap">
    ///     Specifies the cap style.
    ///     default "round"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#cap">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="join">
    ///     Specifies the join style.
    ///     default "round"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#join">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="marker">
    ///     Specifies the color, style, and placement of a symbol marker on the line.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#marker">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="miterLimit">
    ///     Maximum allowed ratio of the width of a miter join to the line width.
    ///     default 2
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html#miterLimit">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SimpleLineSymbol(
        MapColor? color = null,
        Dimension? width = null,
        SimpleLineSymbolStyle? style = null,
        Cap? cap = null,
        Join? join = null,
        LineSymbolMarker? marker = null,
        double? miterLimit = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Color = color;
        Width = width;
        Style = style;
        Cap = cap;
        Join = join;
        Marker = marker;
        MiterLimit = miterLimit;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Cap property.
    /// </summary>
    public async Task<Cap?> GetCap()
    {
        if (CoreJsModule is null)
        {
            return Cap;
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
            return Cap;
        }

        // get the property value
        JsNullableEnumWrapper<Cap>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<Cap>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "cap");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Cap = (Cap)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Cap)] = Cap;
        }
         
        return Cap;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Join property.
    /// </summary>
    public async Task<Join?> GetJoin()
    {
        if (CoreJsModule is null)
        {
            return Join;
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
            return Join;
        }

        // get the property value
        JsNullableEnumWrapper<Join>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<Join>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "join");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Join = (Join)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Join)] = Join;
        }
         
        return Join;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Marker property.
    /// </summary>
    public async Task<LineSymbolMarker?> GetMarker()
    {
        if (CoreJsModule is null)
        {
            return Marker;
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
            return Marker;
        }

        LineSymbolMarker? result = await JsComponentReference.InvokeAsync<LineSymbolMarker?>(
            "getMarker", CancellationTokenSource.Token);
        
        if (result is not null)
        {
#pragma warning disable BL0005
            Marker = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Marker)] = Marker;
        }
        
        return Marker;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the MiterLimit property.
    /// </summary>
    public async Task<double?> GetMiterLimit()
    {
        if (CoreJsModule is null)
        {
            return MiterLimit;
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
            return MiterLimit;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "miterLimit");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             MiterLimit = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(MiterLimit)] = MiterLimit;
        }
         
        return MiterLimit;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Style property.
    /// </summary>
    public async Task<SimpleLineSymbolStyle?> GetStyle()
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
        JsNullableEnumWrapper<SimpleLineSymbolStyle>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<SimpleLineSymbolStyle>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "style");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Style = (SimpleLineSymbolStyle)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Style)] = Style;
        }
         
        return Style;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Cap property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetCap(Cap? value)
    {
#pragma warning disable BL0005
        Cap = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Cap)] = value;
        
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
            JsComponentReference, "cap", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Join property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetJoin(Join? value)
    {
#pragma warning disable BL0005
        Join = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Join)] = value;
        
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
            JsComponentReference, "join", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Marker property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMarker(LineSymbolMarker? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Marker = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Marker)] = value;
        
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
            JsComponentReference, "marker", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the MiterLimit property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetMiterLimit(double? value)
    {
#pragma warning disable BL0005
        MiterLimit = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(MiterLimit)] = value;
        
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
            JsComponentReference, "miterLimit", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Style property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStyle(SimpleLineSymbolStyle? value)
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

}
