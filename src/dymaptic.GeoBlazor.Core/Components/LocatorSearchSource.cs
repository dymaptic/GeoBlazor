namespace dymaptic.GeoBlazor.Core.Components;

public partial class LocatorSearchSource : SearchSource
{
    /// <inheritdoc/>
    public override string Type => "locator";

    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer dashboard. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }


    /// <summary>
    ///     Constricts search results to a specified country code. For example, US for United States or SE for Sweden. Only applies to the World Geocode Service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CountryCode { get; set; }

    /// <summary>
    ///     Sets the scale of the MapView or SceneView for the resulting search result, if the locator service doesn’t return an extent with a scale. An example of this is using the Use current location option in the Search bar.
    ///     If you want to override the scale returned by the locator service, use zoomScale instead.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? DefaultZoomScale { get; set; }

    /// <summary>
    ///     This property controls prioritization of Search widget result candidates depending on the view scale.
    ///     When this property is false (the default value), the location parameter is included in the request when the scale of the MapView or SceneView is less than or equal to 300,000. This prioritizes result candidates based on their distance from a specified point (the center of the view).
    ///     When this property is true, the location parameter is never included in the request, no matter the scale of the MapView or SceneView.
    ///     Default value is False.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LocalSearchDisabled { get; set; }

    /// <summary>
    ///     Defines the type of location, either street or rooftop, of the point returned from the World Geocoding Service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LocatorSearchLocationType? LocationType { get; set; }

    /// <summary>
    ///     The field name of the Single Line Address Field in the REST services directory for the locator service. Common values are SingleLine and SingleLineFieldName.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SingleLineFieldName { get; set; }

}



