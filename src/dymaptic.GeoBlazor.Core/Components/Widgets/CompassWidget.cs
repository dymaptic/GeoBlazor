using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class CompassWidget : Widget
{
    public override string WidgetType => "compass";
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    public string? IconClass { get; set; }
    [Parameter]
    public string? Label { get; set; }
}

