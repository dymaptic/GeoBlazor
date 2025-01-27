// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    The `ChartMediaInfoValueSeries` class is a read-only support class that represents information specific to how data should be plotted in a chart.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ChartMediaInfoValueSeries
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ChartMediaInfoValueSeries()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="fieldName">
    ///     String value indicating the field's name for a series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#fieldName">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="tooltip">
    ///     String value indicating the tooltip for a series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#tooltip">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="value">
    ///     Numerical value for the chart series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ChartMediaInfoValueSeries(
        string? fieldName = null,
        string? tooltip = null,
        double? value = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        FieldName = fieldName;
        Tooltip = tooltip;
        Value = value;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     The <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-Color.html">Color</a> representing the field for a series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#color">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MapColor? Color { get; protected set; }
    
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
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Color;
        }

        // get the property value
        MapColor? result = await CoreJsModule!.InvokeAsync<MapColor?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "color");
        if (result is not null)
        {
#pragma warning disable BL0005
             Color = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Color)] = Color;
        }
         
        return Color;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the FieldName property.
    /// </summary>
    public async Task<string?> GetFieldName()
    {
        if (CoreJsModule is null)
        {
            return FieldName;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return FieldName;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "fieldName");
        if (result is not null)
        {
#pragma warning disable BL0005
             FieldName = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(FieldName)] = FieldName;
        }
         
        return FieldName;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Tooltip property.
    /// </summary>
    public async Task<string?> GetTooltip()
    {
        if (CoreJsModule is null)
        {
            return Tooltip;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Tooltip;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "tooltip");
        if (result is not null)
        {
#pragma warning disable BL0005
             Tooltip = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Tooltip)] = Tooltip;
        }
         
        return Tooltip;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Value property.
    /// </summary>
    public async Task<double?> GetValue()
    {
        if (CoreJsModule is null)
        {
            return Value;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Value;
        }

        // get the property value
        double? result = await CoreJsModule!.InvokeAsync<double?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "value");
        if (result is not null)
        {
#pragma warning disable BL0005
             Value = result.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Value)] = Value;
        }
         
        return Value;
    }
    
#endregion




}
