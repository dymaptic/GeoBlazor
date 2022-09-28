using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Widgets
{
    public class HomeWidget : Widget
    {
        public override string WidgetType => "home";
        [Parameter]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? IconClass { get; set; }
        [Parameter]
        public string? Label { get; set; } = "Home";
    }
}
