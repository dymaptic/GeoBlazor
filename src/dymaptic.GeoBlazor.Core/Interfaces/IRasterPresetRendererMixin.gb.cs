// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IRasterPresetRendererMixin.html">GeoBlazor Docs</a>
///     Interface for types ImageryLayer, ImageryTileLayer
/// </summary>
[JsonConverter(typeof(MultiTypeConverter<IRasterPresetRendererMixin>))]
public partial interface IRasterPresetRendererMixin : IMapComponent
{
#region Properties

    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IRasterPresetRendererMixin.html#irasterpresetrenderermixinactivepresetrenderername-property">GeoBlazor Docs</a>
    ///     
    /// </summary>
    string? ActivePresetRendererName { get; set; }
    
    /// <summary>
    ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Interfaces.IRasterPresetRendererMixin.html#irasterpresetrenderermixinpresetrenderers-property">GeoBlazor Docs</a>
    ///     
    /// </summary>
    IReadOnlyList<RasterPresetRenderer>? PresetRenderers { get; set; }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the ActivePresetRendererName property after render.
    /// </summary>
    Task SetActivePresetRendererName(string? value);
    
    /// <summary>
    ///    Asynchronously set the value of the PresetRenderers property after render.
    /// </summary>
    Task SetPresetRenderers(IReadOnlyList<RasterPresetRenderer>? value);
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the ActivePresetRendererName property.
    /// </summary>
    Task<string?> GetActivePresetRendererName();

    /// <summary>
    ///     Asynchronously retrieve the current value of the PresetRenderers property.
    /// </summary>
    Task<IReadOnlyList<RasterPresetRenderer>?> GetPresetRenderers();

#endregion

#region Collection Property Adders

    /// <summary>
    ///     Asynchronously add elements to the PresetRenderers property.
    /// </summary>
    Task AddToPresetRenderers(params RasterPresetRenderer[] values);
    
#endregion

#region Collection Property Removers

    /// <summary>
    ///     Asynchronously remove elements from the PresetRenderers property.
    /// </summary>
    Task RemoveFromPresetRenderers(params RasterPresetRenderer[] values);
    
#endregion

}
