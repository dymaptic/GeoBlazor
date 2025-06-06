// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components.Symbols;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.Symbols.SimpleFillSymbol.html">GeoBlazor Docs</a>
///     SimpleFillSymbol is used for rendering 2D polygons in either a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html">MapView</a>
///     or a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html">SceneView</a>.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class SimpleFillSymbol : ISymbol2D,
    ISymbolsFillSymbol
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public SimpleFillSymbol()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="outline">
    ///     The outline of the polygon.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-FillSymbol.html#outline">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="color">
    ///     The color of the symbol.
    ///     default [0, 0, 0, 0.25] - black, semitransparent
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     The fill style.
    ///     default "solid"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleFillSymbol.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public SimpleFillSymbol(
        Outline? outline = null,
        MapColor? color = null,
        SimpleFillSymbolStyle? style = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Outline = outline;
        Color = color;
        Style = style;
#pragma warning restore BL0005    
    }
    
    
#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Style property.
    /// </summary>
    public async Task<SimpleFillSymbolStyle?> GetStyle()
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
        JsNullableEnumWrapper<SimpleFillSymbolStyle>? result = await CoreJsModule!.InvokeAsync<JsNullableEnumWrapper<SimpleFillSymbolStyle>?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "style");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Style = (SimpleFillSymbolStyle)result.Value.Value!;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Style)] = Style;
        }
         
        return Style;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Style property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStyle(SimpleFillSymbolStyle? value)
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
