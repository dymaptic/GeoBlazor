using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public class AreaMeasurement2DWidget : Widget
{
    [JsonPropertyName("type")]
    public override string WidgetType => "areaMeasurement2D";

    public DotNetObjectReference<AreaMeasurement2DWidget> AreaMeasurement2DWidgetObjectReference => DotNetObjectReference.Create(this);

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ActiveTool? ActiveTool { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit? SystemOrAreaUnit { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Label { get; set; }

    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaUnit[]? AreaUnitOptions { get; set; }


}
