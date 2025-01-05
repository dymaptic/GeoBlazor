namespace dymaptic.GeoBlazor.Core.Components.Symbols;
/// <summary>
///    LineSymbolMarker is used for rendering a simple marker graphic on a [SimpleLineSymbol](https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-SimpleLineSymbol.html).
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class LineSymbolMarker : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public LineSymbolMarker()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code.
    /// </summary>
    /// <param name="color">
    ///     The color of the marker.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="placement">
    ///     The placement of the marker(s) on the line.
    ///     default "begin-end"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#placement">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="style">
    ///     The marker style.
    ///     default "arrow"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public LineSymbolMarker(MapColor? color = null, LinePlacement? placement = null, LineSymbolMarkerStyle? style = null)
    {
#pragma warning disable BL0005
        Color = color;
        Placement = placement;
        Style = style;
#pragma warning restore BL0005
    }

#region Public Properties / Blazor Parameters
    /// <summary>
    ///     The color of the marker.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; set; }

    /// <summary>
    ///     The placement of the marker(s) on the line.
    ///     default "begin-end"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#placement">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LinePlacement? Placement { get; set; }

    /// <summary>
    ///     The marker style.
    ///     default "arrow"
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-LineSymbolMarker.html#style">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LineSymbolMarkerStyle? Style { get; set; }

#endregion
#region Property Getters
    /// <summary>
    ///     Asynchronously retrieve the current value of the Color property.
    /// </summary>
    public async Task<MapColor?> GetColor()
    {
        if (CoreJsModule is null)
        {
            return Color;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Color;
        }

        // get the property value
#pragma warning disable BL0005
        Color = await CoreJsModule!.InvokeAsync<MapColor?>("getProperty", CancellationTokenSource.Token, JsComponentReference, "color");
#pragma warning restore BL0005
        return Color;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the Placement property.
    /// </summary>
    public async Task<LinePlacement?> GetPlacement()
    {
        if (CoreJsModule is null)
        {
            return Placement;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Placement;
        }

        // get the property value
#pragma warning disable BL0005
        Placement = await CoreJsModule!.InvokeAsync<LinePlacement?>("getProperty", CancellationTokenSource.Token, JsComponentReference, "placement");
#pragma warning restore BL0005
        return Placement;
    }

    /// <summary>
    ///     Asynchronously retrieve the current value of the Style property.
    /// </summary>
    public async Task<LineSymbolMarkerStyle?> GetStyle()
    {
        if (CoreJsModule is null)
        {
            return Style;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Style;
        }

        // get the property value
#pragma warning disable BL0005
        Style = await CoreJsModule!.InvokeAsync<LineSymbolMarkerStyle?>("getProperty", CancellationTokenSource.Token, JsComponentReference, "style");
#pragma warning restore BL0005
        return Style;
    }

#endregion
#region Property Setters
    /// <summary>
    ///    Asynchronously set the value of the Color property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetColor(MapColor value)
    {
#pragma warning disable BL0005
        Color = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Color)] = value;
        if (CoreJsModule is null)
        {
            return;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return;
        }

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference, "color", value);
    }

    /// <summary>
    ///    Asynchronously set the value of the Placement property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPlacement(LinePlacement value)
    {
#pragma warning disable BL0005
        Placement = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Placement)] = value;
        if (CoreJsModule is null)
        {
            return;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return;
        }

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference, "placement", value);
    }

    /// <summary>
    ///    Asynchronously set the value of the Style property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetStyle(LineSymbolMarkerStyle value)
    {
#pragma warning disable BL0005
        Style = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Style)] = value;
        if (CoreJsModule is null)
        {
            return;
        }

        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return;
        }

        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token, JsComponentReference, "style", value);
    }
#endregion
}