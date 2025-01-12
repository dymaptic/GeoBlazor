namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Feature templates define all the information required to create a new feature in
///     a feature layer. These include information such as the default attribute values with
///     which a feature will be created, and the default tool used to create that feature.
/// </summary>
public class FeatureTemplate: MapComponent
{
    /// <summary>
    ///     Name of the feature template.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    ///     Description of the feature template.
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    ///     Name of the default drawing tool defined for the template to create a feature.
    /// </summary>
    public DrawingTool? DrawingTool { get; set; }
    /// <summary>
    ///     An object used to create a thumbnail image that represents a feature type in the feature template.
    /// </summary>
    public Thumbnail? Thumbnail { get; set; }
    /// <summary>    
    ///     An instance of the prototypical feature described by the feature template. It specifies default values for the attribute fields and does not contain geometry.
    /// </summary>
    public Graphic? Prototype { get; set; }
}