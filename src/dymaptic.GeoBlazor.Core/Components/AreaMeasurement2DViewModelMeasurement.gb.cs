// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AreaMeasurement2DViewModelMeasurement.html">GeoBlazor Docs</a>
///     The area and perimeter of the measurement polygon in square meters and meters respectively.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class AreaMeasurement2DViewModelMeasurement : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public AreaMeasurement2DViewModelMeasurement()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="area">
    ///     The area (m²).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="geometry">
    ///     Measurement area.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="perimeter">
    ///     The perimeter (m).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public AreaMeasurement2DViewModelMeasurement(
        double? area = null,
        Polygon? geometry = null,
        double? perimeter = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Area = area;
        Geometry = geometry;
        Perimeter = perimeter;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AreaMeasurement2DViewModelMeasurement.html#areameasurement2dviewmodelmeasurementarea-property">GeoBlazor Docs</a>
    ///     The area (m²).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Area { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AreaMeasurement2DViewModelMeasurement.html#areameasurement2dviewmodelmeasurementgeometry-property">GeoBlazor Docs</a>
    ///     Measurement area.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Polygon? Geometry { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.AreaMeasurement2DViewModelMeasurement.html#areameasurement2dviewmodelmeasurementperimeter-property">GeoBlazor Docs</a>
    ///     The perimeter (m).
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-AreaMeasurement2D-AreaMeasurement2DViewModel.html#measurement">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Perimeter { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Area property.
    /// </summary>
    public async Task<double?> GetArea()
    {
        if (CoreJsModule is null)
        {
            return Area;
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
            return Area;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "area");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Area = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Area)] = Area;
        }
         
        return Area;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Geometry property.
    /// </summary>
    public async Task<Polygon?> GetGeometry()
    {
        if (CoreJsModule is null)
        {
            return Geometry;
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
            return Geometry;
        }

        Polygon? result = await JsComponentReference.InvokeAsync<Polygon?>(
            "getGeometry", CancellationTokenSource.Token);
        
        if (result is not null)
        {
            if (Geometry is not null)
            {
                result.Id = Geometry.Id;
            }
            
#pragma warning disable BL0005
            Geometry = result;
#pragma warning restore BL0005
            ModifiedParameters[nameof(Geometry)] = Geometry;
        }
        
        return Geometry;
    }
    
    /// <summary>
    ///     Asynchronously retrieve the current value of the Perimeter property.
    /// </summary>
    public async Task<double?> GetPerimeter()
    {
        if (CoreJsModule is null)
        {
            return Perimeter;
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
            return Perimeter;
        }

        // get the property value
        JsNullableDoubleWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableDoubleWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "perimeter");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             Perimeter = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Perimeter)] = Perimeter;
        }
         
        return Perimeter;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Area property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetArea(double? value)
    {
#pragma warning disable BL0005
        Area = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Area)] = value;
        
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
            JsComponentReference, "area", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Geometry property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetGeometry(Polygon? value)
    {
        if (value is not null)
        {
            value.CoreJsModule  = CoreJsModule;
            value.Parent = this;
            value.Layer = Layer;
            value.View = View;
        } 
        
#pragma warning disable BL0005
        Geometry = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Geometry)] = value;
        
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
            JsComponentReference, "geometry", value);
    }
    
    /// <summary>
    ///    Asynchronously set the value of the Perimeter property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetPerimeter(double? value)
    {
#pragma warning disable BL0005
        Perimeter = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Perimeter)] = value;
        
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
            JsComponentReference, "perimeter", value);
    }
    
#endregion


    /// <inheritdoc />
    protected override async ValueTask<bool> RegisterGeneratedChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Polygon geometry:
                if (geometry != Geometry)
                {
                    Geometry = geometry;
                    ModifiedParameters[nameof(Geometry)] = Geometry;
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
            case Polygon _:
                Geometry = null;
                ModifiedParameters[nameof(Geometry)] = Geometry;
                return true;
            default:
                return await base.UnregisterGeneratedChildComponent(child);
        }
    }
    
    /// <inheritdoc />
    public override void ValidateRequiredGeneratedChildren()
    {
    
        Geometry?.ValidateRequiredGeneratedChildren();
        base.ValidateRequiredGeneratedChildren();
    }
      
}
