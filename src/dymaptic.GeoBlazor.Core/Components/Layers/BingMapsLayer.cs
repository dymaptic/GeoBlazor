namespace dymaptic.GeoBlazor.Core.Components.Layers;

[Obsolete("Microsoft has retired the Bing Maps API services. This layer will no longer function, and will be replaced when possible with an AzureMapsLayer. Please refer to the documentation for more information: https://learn.microsoft.com/en-us/bingmaps/rest-services/")]
[CodeGenerationIgnore]
public partial class BingMapsLayer : BaseTileLayer
{


    /// <inheritdoc />
    public override LayerType Type => LayerType.BingMaps;


    /// <summary>
    ///     For more information on Bing map styles please visit: <a target="_blank" href="https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata">https://learn.microsoft.com/en-us/bingmaps/rest-services/imagery/get-imagery-metadata</a>.
    ///     Default Value: "Road"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BingImageryStyle? Style { get; set; }

    /// <summary>
    ///     Provides culture specific map labels. For more information visit: https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/culture-parameter.
    ///     For a list of supported culture codes please visit: <a href="https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes">https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/supported-culture-codes</a>.
    ///     Default Value: "en-US"
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(CultureConverter))]
    public CultureInfo? Culture { get; set; }
    
    /// <summary>
    ///     This will alter Geopolitical disputed borders and labels to align with the specified user region.
    ///     For more information on Bing's region setting please visit: https://learn.microsoft.com/en-us/bingmaps/rest-services/common-parameters-and-types/user-context-parameters
    ///     For a list of supported country codes please visit: see https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Region { get; set; }

    /// <summary>
    ///     Exposes Bing logo url.
    /// </summary>
    public async Task<string> GetBingLogo()
    {
        return await JsComponentReference!.InvokeAsync<string>("getBingLogo");
    }

    /// <summary>
    ///     Copyright information.
    /// </summary>
    public async Task<string> GetCopyright()
    {
        return await JsComponentReference!.InvokeAsync<string>("getCopyright");
    }

    /// <summary>
    ///     Indicates if the layer has attribution data.
    /// </summary>
    public async Task<bool> HasAttributionData()
    {
        return await JsComponentReference!.InvokeAsync<bool>("hasAttributionData");
    }
}