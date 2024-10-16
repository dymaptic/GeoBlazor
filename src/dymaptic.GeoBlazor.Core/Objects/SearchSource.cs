using dymaptic.GeoBlazor.Core.Components;
using dymaptic.GeoBlazor.Core.Components.Geometries;
using dymaptic.GeoBlazor.Core.Components.Layers;
using dymaptic.GeoBlazor.Core.Components.Popups;
using dymaptic.GeoBlazor.Core.Components.Symbols;
using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     The following properties define generic sources properties for use in the Search widget. Please see the subclasses that extend this class for more information about working with Search widget sources.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
[JsonConverter(typeof(SearchSourceConverter))]
public class SearchSource : MapComponent
{
    /// <summary>
    ///     The type of source.
    /// </summary>
    public virtual string Type => "";
    
    /// <summary>
    ///     Indicates whether to automatically navigate to the selected result once selected.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoNavigate { get; set; }
    
    /// <summary>
    ///     Indicates the maximum number of search results to return. Default value is 6.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxResults { get; set; }
    
    /// <summary>
    ///     Indicates the minimum number of characters required before querying for a suggestion. Default value is 1.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MinSuggestCharacters { get; set; }
    
    /// <summary>
    ///     The name of the source for display.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    
    /// <summary>
    ///     Specifies the fields returned with the search results.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OutFields { get; set; }
    
    /// <summary>
    ///     Used as a hint for the source input text.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }
    
    /// <summary>
    ///     Indicates whether to display a Popup when a selected result is clicked.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PopupEnabled { get; set; }
    
    /// <summary>
    ///     Specify this to prefix the user's input of the search text.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Prefix { get; set; }
    
    /// <summary>
    ///     Indicates whether to show a graphic on the map for the selected source using the resultSymbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ResultGraphicEnabled { get; set; }
    
    /// <summary>
    ///     A template string used to display multiple fields in a defined order when results are displayed.
    /// </summary>
    /// <remarks>
    ///     Example: "{County}, {State}"
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SearchTemplate { get; set; }
    
    /// <summary>
    ///     Specify this to add a suffix to the user's input for the search value.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Suffix { get; set; }
    
    /// <summary>
    ///     Indicates whether to display suggestions as the user enters input text in the widget. Default value is true.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SuggestionsEnabled { get; set; }
    
    /// <summary>
    ///     Indicates whether to constrain the search results to the view's extent. Default value is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? WithinViewEnabled { get; set; }
    
    /// <summary>
    ///     The set zoom scale for the resulting search result. This scale is automatically honored. Default value is null.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ZoomScale { get; set; }
    
    /// <summary>
    ///     Function used to get search results. See GetResultsHandler for the function definition. When resolved, returns an object containing an array of search results.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<GetResultsParameters, Task<IList<SearchResult>>>? GetResultsHandler { get; set; }
    
    /// <summary>
    ///     Function used to get search suggestions. See GetSuggestionsParameters for the function definition. When resolved, returns an object containing an array of suggest results.
    /// </summary>
    [Parameter]
    [JsonIgnore]
    public Func<GetSuggestionsParameters, Task<IList<SuggestResult>>>? GetSuggestionsHandler { get; set; }
    
    /// <summary>
    ///     The popup template used to display search results. If no popup is needed, set the source's popupTemplate to null.
    /// </summary>
    /// <remarks>
    ///     This property should be set in instances where there is no existing PopupTemplate configured. For example, feature sources will default to any existing popupTemplate configured on the layer.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PopupTemplate? PopupTemplate { get; set; }
    
    /// <summary>
    ///     The symbol used to display the result.
    /// </summary>
    /// <remarks>
    ///     This property only applies when the layer/locator/source is not part of the map.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? ResultSymbol { get; set; }
    
    /// <summary>
    ///     Indicates for the JavaScript engine whether to set up the GetResults handler
    /// </summary>
    public bool HasGetResultsHandler => GetResultsHandler is not null;

    /// <summary>
    ///     Indicates for the JavaScript engine whether to set up the GetSuggestions handler
    /// </summary>
    public bool HasGetSuggestionsHandler => GetSuggestionsHandler is not null;
    
    /// <summary>
    ///     JavaScript-invokable method for internal use.
    /// </summary>
    [JSInvokable]
    public async Task<IList<SearchResult>> OnJavaScriptGetResults(GetResultsParameters resultsParams)
    {
        return await GetResultsHandler!.Invoke(resultsParams);
    }
    
    /// <summary>
    ///     JavaScript-invokable method for internal use.
    /// </summary>
    [JSInvokable]
    public async Task<IList<SuggestResult>> OnJavaScriptGetSuggestions(GetSuggestionsParameters suggestionsParams)
    {
        return await GetSuggestionsHandler!.Invoke(suggestionsParams);
    }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case PopupTemplate popupTemplate:
                if (!popupTemplate.Equals(PopupTemplate))
                {
                    PopupTemplate = popupTemplate;
                }
                break;
            case Symbol symbol:
                if (!symbol.Equals(ResultSymbol))
                {
                    ResultSymbol = symbol;
                }

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
            case PopupTemplate _:
                PopupTemplate = null;

                break;
            case Symbol:
                ResultSymbol = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        PopupTemplate?.ValidateRequiredChildren();
        ResultSymbol?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     The following properties define a Layer-based source whose features may be searched by a Search widget instance.
///     For string field searches, there is no leading wildcard. This effectively makes exactMatch true, which will remove unnecessary search results and suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-LayerSearchSource.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <remarks>
///     Layers created from client-side graphics are not supported.
/// </remarks>
public class LayerSearchSource : SearchSource
{
    /// <inheritdoc />
    public override string Type => "layer";
    
    /// <summary>
    ///     The results are displayed using this field. Defaults to the layer's displayField or the first string field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DisplayField { get; set; }
    
    /// <summary>
    ///     Indicates to only return results that match the search value exactly. This property only applies to string field searches. exactMatch is always true when searching fields of type number. Default Value is false.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ExactMatch { get; set; }

    /// <summary>
    ///     The Id for the layer queried in the search. This is required. The layer can be a map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer or OGCFeatureLayer. See the SceneLayer Guide page on how to publish SceneLayers with associated feature layers.
    /// </summary>
    /// <remarks>
    ///     You may either specify a LayerId for an existing map layer, or nest a new <see cref="FeatureLayer"/> inside this Search Source.
    ///     Feature layers created from client-side graphics are not supported.
    /// </remarks>
    [Parameter]
    [RequiredProperty(nameof(Layer))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? LayerId { get; set; }
    
    /// <summary>
    ///     One or more field names used to order the query results. Specfiy ASC (ascending) or DESC (descending) after the field name to control the order. The default order is ASC.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? OrderByFields { get; set; }
    
    /// <summary>
    ///     An array of string values representing the names of fields in the feature layer to search.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? SearchFields { get; set; }
    
    /// <summary>
    ///     A template string used to display multiple fields in a defined order when suggestions are displayed. This takes precedence over displayField. Field names in the template must have the following format: {FieldName}. An example suggestionTemplate could look something like: Name: {OWNER}, Parcel: {PARCEL_ID}.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SuggestionTemplate { get; set; }
    
    /// <summary>
    ///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LayerSearchSourceFilter? Filter { get; set; }
    
    /// <summary>
    ///     The layer queried in the search. This is required. The layer can be a map/feature service feature layer(s), SceneLayers with an associated feature layer, BuildingComponentSublayer with an associated feature layer, GeoJSONLayer, CSVLayer or OGCFeatureLayer. See the SceneLayer Guide page on how to publish SceneLayers with associated feature layers.
    /// </summary>
    /// <remarks>
    ///     You may either specify a LayerId for an existing map layer, or nest a new <see cref="FeatureLayer"/> inside this Search Source.
    ///     Feature layers created from client-side graphics are not supported.
    /// </remarks>
    [RequiredProperty(nameof(LayerId))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Layer? Layer { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LayerSearchSourceFilter filter:
                if (!filter.Equals(Filter))
                {
                    Filter = filter;
                }
                break;
            case Layer layer:
                if (!layer.Equals(Layer))
                {
                    Layer = layer;
                }

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
            case LayerSearchSourceFilter:
                Filter = null;
                break;
            case Layer _:
                Layer = null;
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        Filter?.ValidateRequiredChildren();
        Layer?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     The following properties define a source pointing to a url that represents a locator service, which may be used to geocode locations with a Search widget instance.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-LocatorSearchSource.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LocatorSearchSource : SearchSource
{
    /// <inheritdoc />
    public override string Type => "locator";
    
    /// <summary>
    ///     An authorization string used to access a resource or service. API keys are generated and managed in the ArcGIS Developer dashboard. An API key is tied explicitly to an ArcGIS account; it is also used to monitor service usage. Setting a fine-grained API key on a specific class overrides the global API key.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ApiKey { get; set; }    
    
    /// <summary>
    ///     A string array which limits the results to one or more categories. For example, Populated Place or airport. Only applicable when using the World Geocode Service.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<string>? Categories { get; set; }
    
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

    /// <summary>
    ///     URL to the ArcGIS Server REST resource that represents a locator service. This is required.
    /// </summary>
    [Parameter]
    [RequiredProperty]
    [EditorRequired]
    public string Url { get; set; } = default!;
    
    /// <summary>
    ///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LocatorSearchSourceFilter? Filter { get; set; }
    
    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LocatorSearchSourceFilter filter:
                if (!filter.Equals(Filter))
                {
                    Filter = filter;
                }
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
            case LocatorSearchSourceFilter:
                Filter = null;
                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    internal override void ValidateRequiredChildren()
    {
        Filter?.ValidateRequiredChildren();
        base.ValidateRequiredChildren();
    }
}

/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LayerSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The where clause specified for filtering suggests or search results.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Where { get; set; }
    
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}

/// <summary>
///     For filtering suggests or search results. Setting a value here takes precedence over withinViewEnabled. Please see the object specification table below for details.
/// </summary>
public class LocatorSearchSourceFilter : MapComponent
{
    /// <summary>
    ///     The filter geometry for suggests or search results. Extent is the only supported geometry when working with locator sources. See <a target="_blank" href="https://developers.arcgis.com/rest/services-reference/enterprise/find-address-candidates.htm">Find Address Candidates</a> for additional information.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Geometry? Geometry { get; set; }
}

/// <summary>
///     Defines the type of location, either street or rooftop, of the point returned from the World Geocoding Service.
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<LocatorSearchLocationType>))]
public enum LocatorSearchLocationType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Rooftop,
    Street
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     An object that is passed as a parameter to get search results.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetResultsHandler">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="ExactMatch">
///     The key field used to find the result.
/// </param>
/// <param name="Location">
///     The location value used by the Search.
/// </param>
/// <param name="MaxResults">
///     Indicates the maximum number of search results to return.
/// </param>
/// <param name="SourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="SpatialReference">
///     Indicates the Spatial Reference defined by the source.
/// </param>
/// <param name="SuggestResult">
///     Indicates the Suggest Result that triggered the search for a result.
/// </param>
/// <param name="ViewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
public record GetResultsParameters(bool? ExactMatch, Point? Location, int? MaxResults, int? SourceIndex, 
    SpatialReference? SpatialReference, SuggestResult SuggestResult, Guid? ViewId);

/// <summary>
///     An object that is passed as a parameter to get search suggestions.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Search-SearchSource.html#GetSuggestionsParameters">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
/// <param name="MaxSuggestions">
///     Indicates the maximum number of suggestions to return for the widget's input.
/// </param>
/// <param name="SourceIndex">
///     Indicates the index of the search source.
/// </param>
/// <param name="SpatialReference">
///     Indicates the Spatial Refeference defined by the source.
/// </param>
/// <param name="SuggestTerm">
///     Indicates search term used to find a suggestion.
/// </param>
/// <param name="ViewId">
///     Indicates the Id for the MapView or SceneView provided to the Search Widget using the source.
/// </param>
public record GetSuggestionsParameters(int? MaxSuggestions, int? SourceIndex, 
    SpatialReference? SpatialReference, string? SuggestTerm, Guid? ViewId);

internal class SearchSourceConverter : JsonConverter<SearchSource>
{
    public override SearchSource? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            return null;
        }
        
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;

        if (rootElement.TryGetProperty("url", out JsonElement _))
        {
            return JsonSerializer.Deserialize<LocatorSearchSource>(rootElement.GetRawText(), options);
        }

        if (rootElement.TryGetProperty("layer", out JsonElement _) ||
            rootElement.TryGetProperty("layerId", out JsonElement _))
        {
            return JsonSerializer.Deserialize<LayerSearchSource>(rootElement.GetRawText(), options);
        }

        return MapFrom<BaseSearchSource, SearchSource>(
            JsonSerializer.Deserialize<BaseSearchSource>(rootElement.GetRawText(), options));
    }

    public override void Write(Utf8JsonWriter writer, SearchSource value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case LocatorSearchSource locatorSearchSource:
                JsonSerializer.Serialize(writer, locatorSearchSource, options);
                break;
            case LayerSearchSource layerSearchSource:
                JsonSerializer.Serialize(writer, layerSearchSource, options);
                break;
            default:
                JsonSerializer.Serialize(writer, 
                    MapFrom<SearchSource, BaseSearchSource>(value)!, options);

                break;
        }
    }
    
    // Copy properties from source object to new instance of target object, for instance using reflection.
    private static TTarget? MapFrom<TSource, TTarget>(TSource? sourceObject) where TTarget : class, new()
    {
        if (sourceObject is null)
            return null;

        IEnumerable<PropertyInfo> sourceProperties = typeof(TSource).GetProperties().Where(prop => prop.CanRead);
        PropertyInfo[] targetProperties = typeof(TTarget).GetProperties().Where(prop => prop.CanWrite).ToArray();

        TTarget target = new TTarget();
        foreach (PropertyInfo sourceProperty in sourceProperties)
        {
            PropertyInfo? targetProperty = targetProperties.FirstOrDefault(prop => prop.Name == sourceProperty.Name);
            targetProperty?.SetValue(target, sourceProperty.GetValue(sourceObject));
        }
        return target;
    }
    
    private class BaseSearchSource : SearchSource
    {
    }
}