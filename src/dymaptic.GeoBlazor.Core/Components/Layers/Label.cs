using dymaptic.GeoBlazor.Core.Components.Symbols;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     Defines label expressions, symbols, scale ranges, label priorities, and label placement options for labels on a
///     layer. See the Labeling guide for more information about labeling.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class Label : LayerObject
{
    /// <summary>
    ///     Parameterless constructor for use as a Blazor component.
    /// </summary>
    public Label()
    {
    }
    
    /// <summary>
    ///    Constructor for generating in code.
    /// </summary>
    /// <param name="labelPlacement">
    ///     The position of the label.
    /// </param>
    /// <param name="labelExpression">
    ///     Defines the labels for a MapImageLayer.
    /// </param>
    /// <param name="labelExpressionInfo">
    ///     Defines the labels for a <see cref="FeatureLayer" />.
    /// </param>
    public Label(string? labelPlacement = null, string? labelExpression = null, 
        LabelExpressionInfo? labelExpressionInfo = null)
    {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
        LabelPlacement = labelPlacement;
        LabelExpression = labelExpression;
        LabelExpressionInfo = labelExpressionInfo;
#pragma warning restore BL0005
    }
    
    /// <summary>
    ///     Defines how labels should be placed relative to one another. By default, labels have a static deconfliction strategy, meaning labels that overlap are dropped to make them easier to read.
    ///     In some cases where few labels overlap, it may be preferable to turn off label deconfliction with the none option. It is also advisable to turn off deconfliction when labeling clusters with a count of features in the center of the cluster.
    /// </summary>
    /// <remarks>
    ///     Currently, this property only applies to FeatureLayer, CSVLayer, and StreamLayer in 2D MapViews.
    /// </remarks>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DeconflictionStrategy? DeconflictionStrategy { get; set; }
    
    /// <summary>
    ///     The position of the label.
    /// </summary>
    [Parameter]
    public string? LabelPlacement { get; set; }

    /// <summary>
    ///     Defines the labels for a MapImageLayer.
    /// </summary>
    /// <remarks>
    ///     MapImageLayer not yet implemented in GeoBlazor
    /// </remarks>
    [Parameter]
    public string? LabelExpression { get; set; }

    /// <summary>
    ///     Defines the labels for a <see cref="FeatureLayer" />.
    /// </summary>
    public LabelExpressionInfo? LabelExpressionInfo { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case LabelExpressionInfo labelExpressionInfo:
                // ReSharper disable once RedundantCast
                if (!((object)labelExpressionInfo).Equals(LabelExpressionInfo))
                {
                    LabelExpressionInfo = labelExpressionInfo;
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
            case LabelExpressionInfo _:
                LabelExpressionInfo = null;

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
        LabelExpressionInfo?.ValidateRequiredChildren();
    }
}

/// <summary>
///     Defines how labels should be placed relative to one another. By default, labels have a static deconfliction strategy, meaning labels that overlap are dropped to make them easier to read.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-support-LabelClass.html#deconflictionStrategy">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public enum DeconflictionStrategy
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    None,
    Static
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}