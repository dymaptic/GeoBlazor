namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Information about the coded values belonging to the domain. Coded value domains specify a valid set of values for a field. Each valid value is assigned a unique name. For example, in a layer for water mains, water main features may be buried under different types of surfaces as signified by a GroundSurfaceType field: pavement, gravel, sand, or none (for exposed water mains). The coded value domain includes both the actual value that is stored in the database (for example, 1 for pavement) and a more user-friendly description of what that value actually means.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-CodedValueDomain.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class CodedValueDomain<T> : Domain
{
    /// <inheritdoc />
    public override string Type => "coded-value";

    /// <summary>
    ///     An array of the coded values in the domain.
    /// </summary>
    public HashSet<CodedValue<T>>? CodedValues { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CodedValue<T> codedValue:
                CodedValues ??= new HashSet<CodedValue<T>>();

                CodedValues.Add(codedValue);

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case CodedValue<T> codedValue:
                CodedValues?.Remove(codedValue);

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}