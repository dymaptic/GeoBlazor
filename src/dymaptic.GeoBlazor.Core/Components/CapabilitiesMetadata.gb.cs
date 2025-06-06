// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesMetadata.html">GeoBlazor Docs</a>
///     Describes the metadata contained on features in the layer.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public partial class CapabilitiesMetadata : MapComponent
{

    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public CapabilitiesMetadata()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="supportsAdvancedFieldProperties">
    ///     Indicates whether to provide a user-defined field description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public CapabilitiesMetadata(
        bool? supportsAdvancedFieldProperties = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        SupportsAdvancedFieldProperties = supportsAdvancedFieldProperties;
#pragma warning restore BL0005    
    }
    
    
#region Public Properties / Blazor Parameters

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.CapabilitiesMetadata.html#capabilitiesmetadatasupportsadvancedfieldproperties-property">GeoBlazor Docs</a>
    ///     Indicates whether to provide a user-defined field description.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#Capabilities">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SupportsAdvancedFieldProperties { get; set; }
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the SupportsAdvancedFieldProperties property.
    /// </summary>
    public async Task<bool?> GetSupportsAdvancedFieldProperties()
    {
        if (CoreJsModule is null)
        {
            return SupportsAdvancedFieldProperties;
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
            return SupportsAdvancedFieldProperties;
        }

        // get the property value
        JsNullableBoolWrapper? result = await CoreJsModule!.InvokeAsync<JsNullableBoolWrapper?>("getNullableValueTypedProperty",
            CancellationTokenSource.Token, JsComponentReference, "supportsAdvancedFieldProperties");
        if (result is { Value: not null })
        {
#pragma warning disable BL0005
             SupportsAdvancedFieldProperties = result.Value.Value;
#pragma warning restore BL0005
             ModifiedParameters[nameof(SupportsAdvancedFieldProperties)] = SupportsAdvancedFieldProperties;
        }
         
        return SupportsAdvancedFieldProperties;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the SupportsAdvancedFieldProperties property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetSupportsAdvancedFieldProperties(bool? value)
    {
#pragma warning disable BL0005
        SupportsAdvancedFieldProperties = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(SupportsAdvancedFieldProperties)] = value;
        
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
            JsComponentReference, "supportsAdvancedFieldProperties", value);
    }
    
#endregion

}
