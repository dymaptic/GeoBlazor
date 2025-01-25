// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///    
/// </summary>
/// <param name="ValidationOptions">
///     Options for validating the save operation.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
/// </param>
public partial record ImageryLayerSaveOptions(
    ImageryLayerSaveOptionsValidationOptions? ValidationOptions = null)
{
    /// <summary>
    ///     Options for validating the save operation.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-ImageryLayer.html#save">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    public ImageryLayerSaveOptionsValidationOptions? ValidationOptions { get; set; } = ValidationOptions;
    
}

