namespace dymaptic.GeoBlazor.Core.Components.Renderers;

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
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Symbol?.ValidateRequiredChildren();
    }
}