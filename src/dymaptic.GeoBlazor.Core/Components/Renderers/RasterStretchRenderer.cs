using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Renderers;

public class RasterStretchRenderer : Renderer
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override RendererType RendererType => RendererType.RasterStretch;


    public bool ComputeGamma { get; set; }

    public bool DynamicRangeAdjustment { get; set; } = false;
    public int[]? Gamma { get; set; }
    public int? OutputMax { get; set; }
    public int? OutputMin { get; set; }
    public string? StretchType { get; set; }



}
