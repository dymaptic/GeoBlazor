using dymaptic.GeoBlazor.Core.Components.Layers;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     SimpleRenderer renders all features in a Layer with one Symbol. This renderer may be used to simply visualize the
///     location of geographic features.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-SimpleRenderer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class SimpleRenderer : Renderer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.Simple;

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
                if (!VisualVariables.Contains(visualVariable))
                {
                    VisualVariables.Add(visualVariable);
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
            case VisualVariable visualVariable:
                VisualVariables.Remove(visualVariable);

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

        foreach (VisualVariable variable in VisualVariables)
        {
            variable.ValidateRequiredChildren();
        }
    }
}