using dymaptic.GeoBlazor.Core.Components.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

/// <summary>
///     The VectorFieldRenderer allows you to display your raster data with vector symbols. This renderer is often used for visualizing flow direction and magnitude information in meteorology and oceanography raster data. It can also be used to symbolize a single raster layer where the symbols are scalar. 
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-VectorFieldRenderer.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class VectorFieldRenderer : LayerObject
{
    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public VectorFieldRenderer() { }

    /// <summary>
    ///     Constructor for use in code
    /// </summary>
    public VectorFieldRenderer(string? attributeField = "Magnitude", string? flowRepresentation = "flow-from",
        string? style = "single-arrow", int? symbolTileSize = null, List<VisualVariable>? visualVariables = null)
    {
#pragma warning disable BL0005
        AttributeField = attributeField;
        FlowRepresentation = flowRepresentation;
        SymbolTileSize = symbolTileSize;
        Style = style;
        VisualVariables = visualVariables;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     The type of renderer.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type => "vector-field";

    /// <summary>
    ///     Attribute field presenting the magnitude.
    /// </summary>
    public string? AttributeField { get; set; }

    /// <summary>
    ///     Defines the flow direction of the data.
    /// </summary>
    public string? FlowRepresentation { get; set; }

    /// <summary>
    ///     Predefined symbol styles used to represent the vector flow.
    /// </summary>
    public string? Style { get; set; }

    /// <summary>
    ///     Determines the density of the symbols.
    /// </summary>
    public string? SymbolTileSize { get; set; }

    /// <summary>
    ///     An array of VisualVariable objects.
    /// </summary>
    public List<VisualVariable>? VisualVariables { get; set; }
}
