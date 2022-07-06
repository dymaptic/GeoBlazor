using Microsoft.AspNetCore.Components;

namespace dymaptic.Blazor.GIS.API.Core.Components.Popups;

public class FieldInfoFormat : MapComponent
{
    [Parameter]
    public int Places { get; set; }
    [Parameter]
    public bool DigitSeparator { get; set; }
}