using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Enums;


namespace dymaptic.GeoBlazor.Core.Model;

/// <summary>
///     Feature templates define all the information required to create a new feature in
///     a feature layer. These include information such as the default attribute values with
///     which a feature will be created, and the default tool used to create that feature.
/// </summary>
/// <param name="Name">
///     Name of the feature template.
/// </param>
/// <param name="Description">
///     Description of the feature template.
/// </param>
/// <param name="DrawingTool">
///     Name of the default drawing tool defined for the template to create a feature.
/// </param>
/// <param name="Thumbnail">
///     An object used to create a thumbnail image that represents a feature type in the feature template.
/// </param>
/// <param name="Prototype">    
///     An instance of the prototypical feature described by the feature template. It specifies default values for the attribute fields and does not contain geometry.
/// </param>
public record FeatureTemplate(string Name, string Description, DrawingTool DrawingTool, Thumbnail Thumbnail, Graphic Prototype);