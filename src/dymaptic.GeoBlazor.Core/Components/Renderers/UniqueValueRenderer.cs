using dymaptic.GeoBlazor.Core.Components.Symbols;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     UniqueValueRenderer allows you to symbolize features in a Layer based on one or more matching string attributes. This is typically done by using unique colors, fill styles, or images to represent features with equal values in a string field.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-UniqueValueRenderer.html">ArcGIS JS API</a>
/// </summary>
public class UniqueValueRenderer : Renderer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.UniqueValue;

    /// <summary>
    ///     The name of the attribute field the renderer uses to match unique values or types.
    /// </summary>
    [Parameter]
    public string? Field { get; set; }
    
    /// <summary>
    ///     Label used in the Legend to describe features assigned the default symbol.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DefaultLabel { get; set; }

    /// <summary>
    ///     Each element in the array is an object that provides information about a unique value associated with the renderer.
    /// </summary>
    public HashSet<UniqueValueInfo> UniqueValueInfos { get; set; } = new();

    /// <summary>
    ///     The default symbol used to draw a feature whose value is not matched or specified by the renderer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Symbol? DefaultSymbol => Symbol;
    
    /// <summary>
    ///     An object providing options for displaying the renderer in the Legend.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public UniqueValueRendererLegendOptions? LegendOptions { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case UniqueValueInfo uniqueValue:
                if (!UniqueValueInfos.Contains(uniqueValue))
                {
                    UniqueValueInfos.Add(uniqueValue);
                    await UpdateComponent();
                }

                break;
            case UniqueValueRendererLegendOptions legendOptions:
                if (!legendOptions.Equals(LegendOptions))
                {
                    LegendOptions = legendOptions;
                    await UpdateComponent();
                }

                break;
            case DefaultSymbol defaultSymbol:
                if (defaultSymbol.Symbol is not null && !defaultSymbol.Symbol!.Equals(Symbol))
                {
                    Symbol = defaultSymbol.Symbol;
                    await UpdateComponent();
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
            case UniqueValueInfo uniqueValue:
                UniqueValueInfos.Remove(uniqueValue);

                break;
            case UniqueValueRendererLegendOptions _:
                LegendOptions = null;
                break;
            case DefaultSymbol _:
                Symbol = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}


/// <summary>
///     An object providing options for displaying the renderer in the Legend.
/// </summary>
public class UniqueValueRendererLegendOptions: MapComponent
{
    /// <summary>
    ///     The title to display in the legend for the renderer
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
}


/// <summary>
///     Wrapper to identify the default (fallback) symbol for a <see cref="UniqueValueRenderer"/>
/// </summary>
public class DefaultSymbol : MapComponent
{
    /// <summary>
    ///     The symbol to set as default
    /// </summary>
    [RequiredProperty]
    public Symbol? Symbol { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case Symbol symbol:
                if (!symbol.Equals(Symbol))
                {
                    Symbol = symbol;
                    await UpdateComponent();
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
            case Symbol _:
                Symbol = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
    }
}