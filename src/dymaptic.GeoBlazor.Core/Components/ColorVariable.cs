namespace dymaptic.GeoBlazor.Core.Components;

public partial class ColorVariable : VisualVariable
{

    
    /// <inheritdoc />
    public override VisualVariableType Type => VisualVariableType.Color;

    /// <summary>
    ///     Name of the numeric attribute field by which to normalize the data. If this field is used, then the values in stops should be normalized as percentages or ratios.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizationField { get; set; }


    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ColorStop stop:
                Stops ??= [];
                Stops = [..Stops, stop];

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
            case ColorStop stop:
                Stops = Stops?.Except([stop]).ToList();

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

}