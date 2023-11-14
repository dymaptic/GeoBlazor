using dymaptic.GeoBlazor.Core.Components.Layers;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     SimpleRenderer renders all features in a Layer with one Symbol. This renderer may be used to simply visualize the
///     location of geographic features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-SimpleRenderer.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class SimpleRenderer : Renderer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.Simple;
    
    /// <summary>
    ///     The label for the renderer. This describes what features with the given symbol represent in the real world. This will display next to the layer's symbol inside the Legend widget.
    ///     This text is not displayed in the Legend when visualVariables are used. When the renderer contains visualVariables, you should set the title property in legendOptions on each visual variable to describe the visualization.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    ///     A collection of <see cref="VisualVariable" /> objects.
    /// </summary>
    public HashSet<VisualVariable> VisualVariables { get; set; } = new();

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case VisualVariable visualVariable:
                VisualVariables.Add(visualVariable);

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
                VisualVariables.Remove(visualVariable);

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

        foreach (VisualVariable variable in VisualVariables)
        {
            variable.ValidateRequiredChildren();
        }
    }
}