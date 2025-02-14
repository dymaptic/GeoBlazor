namespace dymaptic.GeoBlazor.Core.Components;

public partial class PortalBasemapsSource : MapComponent
{
    /// <summary>
    ///     An query string used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString" /> or <see cref="QueryParams" />
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? QueryString { get; set; }

    /// <summary>
    ///     An object with key-value pairs used to create a custom basemap gallery group query.
    /// </summary>
    /// <remarks>
    ///     User either <see cref="QueryString" /> or <see cref="QueryParams" />
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? QueryParams { get; set; }

}