namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public partial class UniqueValueRenderer : Renderer, IImageryRenderer
{
    /// <inheritdoc />
    public override RendererType Type => RendererType.UniqueValue;

    /// <inheritdoc />
    [JsonIgnore] // ignore bc we have two "Type" properties that will serialize to the same value
    ImageryRendererType IImageryRenderer.Type => ImageryRendererType.UniqueValue;

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


    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case UniqueValueInfo uniqueValue:
                UniqueValueInfos ??= [];
                UniqueValueInfos = [..UniqueValueInfos, uniqueValue];

                break;
            
            case Symbol defaultSymbol:
                DefaultSymbol = defaultSymbol;

                break;
            
            case DefaultSymbol defaultSymbol:
                DefaultSymbol = defaultSymbol.Symbol;

                break;

            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case UniqueValueInfo uniqueValue:
                UniqueValueInfos = UniqueValueInfos?.Except([uniqueValue]).ToList();

                break;
            case Symbol:
                DefaultSymbol = null;

                break;
            
            case DefaultSymbol _:
                DefaultSymbol = null;

                break;

            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    [CodeGenerationIgnore]
    public override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();

        if (UniqueValueInfos is not null && UniqueValueInfos.Any())
        {
            foreach (UniqueValueInfo uniqueValue in UniqueValueInfos)
            {
                uniqueValue.ValidateRequiredChildren();
            }
        }
        
        DefaultSymbol?.ValidateRequiredChildren();
    }
}

/// <summary>
///     Wrapper to identify the default (fallback) symbol for a <see cref="UniqueValueRenderer" />
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