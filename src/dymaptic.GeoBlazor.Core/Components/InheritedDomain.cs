namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///    This is a subclass of <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html">Domain</a>.
///    <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-InheritedDomain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[CodeGenerationIgnore]
public class InheritedDomain : Domain
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public InheritedDomain()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="name">
    ///     The domain name.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-Domain.html#name">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    public InheritedDomain(
        string? name = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        Name = name;
#pragma warning restore BL0005    
    }
    
    /// <inheritdoc/>
    public override string Type => "inherited";
}