// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///    Interface for types ClassBreaksRenderer, DictionaryRenderer, SimpleRenderer, UniqueValueRenderer
/// </summary>
public partial interface IVisualVariablesMixin 
{
#region Properties

    /// <summary>
    ///     An array of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-VisualVariable.html">VisualVariable</a> objects.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-mixins-VisualVariablesMixin.html#visualVariables">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    IReadOnlyList<VisualVariable>? VisualVariables { get; set; }
    
#endregion

#region Property Setters

    /// <summary>
    ///    Asynchronously set the value of the VisualVariables property after render.
    /// </summary>
    Task SetVisualVariables(IReadOnlyList<VisualVariable> value);
    
#endregion

#region Property Getters

    /// <summary>
    ///     Asynchronously retrieve the current value of the VisualVariables property.
    /// </summary>
    Task<IReadOnlyList<VisualVariable>?> GetVisualVariables();

#endregion

#region Collection Property Adders

    /// <summary>
    ///     Asynchronously add elements to the VisualVariables property.
    /// </summary>
    Task AddToVisualVariables(params VisualVariable[] values);
    
#endregion

#region Collection Property Removers

    /// <summary>
    ///     Asynchronously remove elements from the VisualVariables property.
    /// </summary>
    Task RemoveFromVisualVariables(params VisualVariable[] values);
    
#endregion

}
