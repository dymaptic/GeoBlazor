using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Layers;

public class KMLLayer : Layer
{
    public KMLLayer()
    {
    }

    // Effect property is one items that can be added in the future 
    public KMLLayer (string url, string? copyright = null) //string? title = null, string? blendMode, int? maxscale, int? minscale
    {
#pragma warning disable BL0005
        Url = url;
        //Title = title;
        Copyright = copyright;
        //BlendMode = blendMode;
        //MaxScale = maxscale;
        //MinScale = minscale;
#pragma warning restore BL0005
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
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Copyright { get; set; }

    [JsonPropertyName("type")]
    public override string LayerType => "kml";
}
