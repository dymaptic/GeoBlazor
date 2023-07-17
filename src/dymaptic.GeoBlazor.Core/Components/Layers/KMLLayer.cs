using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class KMLLayer : FeatureLayer
{
    public KMLLayer()
    {
    }

    // Effect property is one items that can be added in the future 
    public KMLLayer (string url, string? title = null) //, string? blendMode, int? maxscale, int? minscale
    {
        Url = url;
        Title = title;
        //BlendMode = blendMode;
        //MaxScale = maxscale;
        //MinScale = minscale;

    }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }

    //[Parameter]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    //public string? BlendMode { get; set; }

    //[Parameter]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    //public int? MaxScale { get; set; }

    //[Parameter]
    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    //public int? MinScale { get; set; }


    [JsonPropertyName("type")]
    public override string LayerType => "kml";
}
