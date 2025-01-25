namespace dymaptic.GeoBlazor.Core.Model;

public partial record RelationshipQuery
{

    /// <summary>
    ///     An array of objectIds for the features in the layer/table being queried.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-support-RelationshipQuery.html#objectIds">ArcGIS Maps SDK for JavaScript</a>
    ///     Union type for ObjectIds: number[] | string[]
    /// </summary>
    public IReadOnlyCollection<string>? ObjectIds { get; set; }

}