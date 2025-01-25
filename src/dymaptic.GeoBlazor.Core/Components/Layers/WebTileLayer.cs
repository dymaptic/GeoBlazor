namespace dymaptic.GeoBlazor.Core.Components.Layers;

public partial class WebTileLayer : Layer
{
    /// <inheritdoc />
    public override LayerType Type => LayerType.WebTile;

    /// <summary>
    ///     Blend modes are used to blend layers together to create an interesting effect in a layer, or even to produce what
    ///     seems like a new layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BlendMode? BlendMode { get; set; }

    /// <summary>
    ///     The attribution information for the layer.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    /// <summary>
    ///     The maximum scale (most zoomed in) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxScale { get; set; }

    /// <summary>
    ///     The minimum scale (most zoomed out) at which the layer is visible in the view.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinScale { get; set; }

    /// <summary>
    ///     Refresh interval of the layer in minutes.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///     A string of subDomain names where tiles are served to speed up tile retrieval. If subDomains are specified, the
    ///     <see cref="UrlTemplate" /> should include a {subDomain} place holder.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<string>? SubDomains { get; set; }

    /// <summary>
    ///     The url template is a string that specifies the URL of the hosted tile images to load. The url template resembles
    ///     an absolute URL but with a number of placeholder strings that the source evaluates to decide which tiles to load.
    /// </summary>
    /// <remarks>
    ///     The url template can follow a pattern of https://some.domain.com/{level}/{col}/{row}/ where level corresponds to a
    ///     zoom level, and column and row represent a tile column and row, respectively. It can also follow a pattern of
    ///     https://some.domain.com/{z}/{x}/{y}/ where z corresponds to a zoom level, and x and y represent a tile location
    ///     along x and y axis. The urlTemplate should contain a {subDomain} place holder if subDomains are specified.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UrlTemplate { get; set; }

}