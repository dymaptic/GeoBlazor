namespace dymaptic.GeoBlazor.Pro.Components;

public partial class FeatureServiceLayerInfo : MapComponent
{
    /// <summary>
    ///     The ArcGIS FeatureService numeric id of a layer.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-rest-featureService-FeatureService.html#LayerInfo">ArcGIS Maps SDK for JavaScript</a>
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? ArcGISLayerId { get; set; }
}

