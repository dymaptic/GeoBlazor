namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public partial class SimpleRenderer : Renderer
{

    
    /// <inheritdoc />
    public override RendererType Type => RendererType.Simple;
    
    /// <summary>
    ///     The label for the renderer. This describes what features with the given symbol represent in the real world. This will display next to the layer's symbol inside the Legend widget.
    ///     This text is not displayed in the Legend when visualVariables are used. When the renderer contains visualVariables, you should set the title property in legendOptions on each visual variable to describe the visualization.
    /// </summary>
    [ArcGISProperty]
    [Parameter]
    public string? Label { get; set; }


    /// <summary>
    ///     Gets the current <see cref="Symbol" /> for the object.
    /// </summary>
    public virtual async Task<Symbol?> GetSymbol()
    {
        return await Task.Run(() => Symbol);
    }

    /// <summary>
    ///     Sets the <see cref="Symbol" /> for the object.
    /// </summary>
    /// <param name="symbol">
    ///     The <see cref="Symbol" /> for the object.
    /// </param>
    public virtual async Task SetSymbol(Symbol symbol)
    {
        Symbol = symbol;

        if (CoreJsModule is not null)
        {
            await CoreJsModule.InvokeVoidAsync("setGraphicSymbol",
                Id, Symbol.ToSerializationRecord());
        }
    }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {

            case VisualVariable visualVariable:
                VisualVariables ??= [];
                VisualVariables = [..VisualVariables, visualVariable];

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

            case VisualVariable visualVariable:
                VisualVariables = VisualVariables?.Except([visualVariable]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}