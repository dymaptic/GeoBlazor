// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Components;


/// <summary>
///    Domains define constraints on a <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-Layer.html">layer</a> <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Field.html">field</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public abstract partial class Domain
{

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the Name property.
    /// </summary>
    public async Task<string?> GetName()
    {
        if (CoreJsModule is null)
        {
            return Name;
        }
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
            "getJsComponent", CancellationTokenSource.Token, Id);
        if (JsComponentReference is null)
        {
            return Name;
        }

        // get the property value
        string? result = await CoreJsModule!.InvokeAsync<string?>("getProperty",
            CancellationTokenSource.Token, JsComponentReference, "name");
        if (result is not null)
        {
#pragma warning disable BL0005
             Name = result;
#pragma warning restore BL0005
             ModifiedParameters[nameof(Name)] = Name;
        }
         
        return Name;
    }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the Name property after render.
    /// </summary>
    /// <param name="value">
    ///     The value to set.
    /// </param>
    public async Task SetName(string value)
    {
#pragma warning disable BL0005
        Name = value;
#pragma warning restore BL0005
        ModifiedParameters[nameof(Name)] = value;
        
        if (CoreJsModule is null)
        {
            return;
        }
    
        JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>("getJsComponent",
            CancellationTokenSource.Token, Id);
    
        if (JsComponentReference is null)
        {
            return;
        }
        
        await CoreJsModule.InvokeVoidAsync("setProperty", CancellationTokenSource.Token,
            JsComponentReference, "name", value);
    }
    
#endregion




}
