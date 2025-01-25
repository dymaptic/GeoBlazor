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
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case UniqueValueInfo uniqueValue:
                UniqueValueInfos ??= [];
                UniqueValueInfos = [..UniqueValueInfos, uniqueValue];

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
                UniqueValueInfos = UniqueValueInfos?.Except([uniqueValue]).ToList();

                break;

            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }
}