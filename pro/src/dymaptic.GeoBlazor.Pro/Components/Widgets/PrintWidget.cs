namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

public partial class PrintWidget
{
   // Add custom code to this file to override generated code
   
   /// <inheritdoc />
   public override WidgetType Type => WidgetType.Print;
   
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Widgets.PrintWidget.html#printwidgetallowedformats-property">GeoBlazor Docs</a>
   ///     Specify the print output file format(s) that the user can select based on the options available from the print service.
   ///     default "all"
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Print.html#allowedFormats">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [ArcGISProperty]
   [Parameter]
   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   [JsonConverter(typeof(ImageFormatReadonlyListConverter<PrintFormat>))]
   [CodeGenerationIgnore]
   public IReadOnlyList<PrintFormat>? AllowedFormats { get; set; }
    
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Widgets.PrintWidget.html#printwidgetallowedlayouts-property">GeoBlazor Docs</a>
   ///     Specify the print output layout(s) that the user can select based on the options available from the print service.
   ///     default "all"
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Print.html#allowedLayouts">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [ArcGISProperty]
   [Parameter]
   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   [JsonConverter(typeof(PrintLayoutReadOnlyListConverter))]
   [CodeGenerationIgnore]
   public IReadOnlyList<PrintLayout>? AllowedLayouts { get; set; }
   
   /// <summary>
    ///     Asynchronously retrieve the current value of the AllowedFormats property.
    /// </summary>
    public async Task<IReadOnlyList<PrintFormat>?> GetAllowedFormats()
    {
        if (CoreJsModule is null)
        {
            return AllowedFormats;
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
            return AllowedFormats;
        }

        // get the property value
        IReadOnlyList<PrintFormat>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<PrintFormat>?>("getProperty",
            CancellationTokenSource.Token, "allowedFormats");
        if (result is not null)
        {
#pragma warning disable BL0005
             AllowedFormats = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AllowedFormats)] = AllowedFormats;
        }
         
        return AllowedFormats;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the AllowedLayouts property.
    /// </summary>
    public async Task<IReadOnlyList<PrintLayout>?> GetAllowedLayouts()
    {
        if (CoreJsModule is null)
        {
            return AllowedLayouts;
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
            return AllowedLayouts;
        }

        // get the property value
        IReadOnlyList<PrintLayout>? result = await JsComponentReference!.InvokeAsync<IReadOnlyList<PrintLayout>?>("getProperty",
            CancellationTokenSource.Token, "allowedLayouts");
        if (result is not null)
        {
#pragma warning disable BL0005
             AllowedLayouts = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(AllowedLayouts)] = AllowedLayouts;
        }
         
        return AllowedLayouts;
    }
    
        /// <summary>
    ///    Asynchronously set the value of the AllowedFormats property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAllowedFormats(IReadOnlyList<PrintFormat>? value)
    {
#pragma warning disable BL0005
        AllowedFormats = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AllowedFormats)] = value;
        
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
            JsComponentReference, "allowedFormats", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the AllowedLayouts property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetAllowedLayouts(IReadOnlyList<PrintLayout>? value)
    {
#pragma warning disable BL0005
        AllowedLayouts = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(AllowedLayouts)] = value;
        
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
            JsComponentReference, "allowedLayouts", value);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the AllowedFormats property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToAllowedFormats(params PrintFormat[] values)
    {
        PrintFormat[] join = AllowedFormats is null
            ? values
            : [..AllowedFormats, ..values];
        await SetAllowedFormats(join);
    }
    
    /// <summary>
    ///     Asynchronously adds elements to the AllowedLayouts property.
    /// </summary>
    /// <param name="values">
    ///    The elements to add.
    /// </param>
    public async Task AddToAllowedLayouts(params PrintLayout[] values)
    {
        PrintLayout[] join = AllowedLayouts is null
            ? values
            : [..AllowedLayouts, ..values];
        await SetAllowedLayouts(join);
    }
    
    /// <summary>
    ///     Asynchronously remove an element from the AllowedFormats property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromAllowedFormats(params PrintFormat[] values)
    {
        if (AllowedFormats is null)
        {
            return;
        }
        await SetAllowedFormats(AllowedFormats.Except(values).ToArray());
    }
    
    
    /// <summary>
    ///     Asynchronously remove an element from the AllowedLayouts property.
    /// </summary>
    /// <param name="values">
    ///    The elements to remove.
    /// </param>
    public async Task RemoveFromAllowedLayouts(params PrintLayout[] values)
    {
        if (AllowedLayouts is null)
        {
            return;
        }
        await SetAllowedLayouts(AllowedLayouts.Except(values).ToArray());
    }
}