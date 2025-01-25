// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    A `ColumnChartMediaInfo` is a type of chart media element that represents a column chart displayed within a popup.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ColumnChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class ColumnChartMediaInfo : IChartMediaInfo
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ColumnChartMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="title">
    ///     The title of the media element.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#title">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="caption">
    ///     Defines a caption for the media.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#caption">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="altText">
    ///     Provides an alternate text for an image if the image cannot be displayed.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-MediaInfo.html#altText">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="value">
    ///     Defines the chart value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-ChartMediaInfo.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public ColumnChartMediaInfo(
        string? title = null,
        string? caption = null,
        string? altText = null,
        ChartMediaInfoValue? value = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Title = title;
        Caption = caption;
        AltText = altText;
        Value = value;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     Defines the chart value.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-mixins-ChartMediaInfo.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartMediaInfoValue? Value { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Value property.
    /// </summary>
    public async Task<ChartMediaInfoValue?> GetValue()
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
#pragma warning disable BL0005
        Value = await CoreJsModule!.InvokeAsync<ChartMediaInfoValue?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "value");
#pragma warning restore BL0005
         ModifiedParameters[nameof(Value)] = Value;
        return Value;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Value property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetValue(ChartMediaInfoValue value)
    {
#pragma warning disable BL0005
        Value = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Value)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "value", value);
    }
    
#endregion





    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValue value:
                if (value != Value)
                {
                    Value = value;
                    
                    ModifiedParameters[nameof(Value)] = Value;
                }
                
                return true;
            default:
                return await base.RegisterGeneratedChildComponent(child);
        }
    }

    protected override async ValueTask<bool> UnregisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValue _:
                Value = null;
                
                ModifiedParameters[nameof(Value)] = Value;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    internal override void ValidateRequiredGeneratedChildren()
    {
    
        Value?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
