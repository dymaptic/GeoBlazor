

using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace dymaptic.GeoBlazor.Core.Components.ViewModels;

public class AreaMeasurement2DViewModel
{
    /// <summary>
    ///     A .NET object reference for calling this class from JavaScript.
    /// </summary>
    public DotNetObjectReference<AreaMeasurement2DViewModel> AreaMeasurement2DViewModelObjectReference => DotNetObjectReference.Create(this);

    /// <summary>
    /// The area and perimeter of the measurement polygon in square meters and meters respectively.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Measurement { get; set; }

    /// <summary>
    /// This property returns the locale specific representation of the area and perimeter.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? MeasurementLabel { get; set; }

    /// <summary>
    /// The ViewModel's state.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AreaMeasurement2DViewModelState? State { get; set; }

    /// <summary>
    /// Unit system (imperial, metric) or specific unit used for displaying the area values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SystemOrAreaUnit? Unit { get; set; }

    /// <summary>
    /// List of available units and unit systems (imperial, metric) for displaying the area values.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public SystemOrAreaUnit[]? UnitOptions { get; set; }

    /// <summary>
    /// Possible state values for the AreaMeasurement2DViewModel.  Default is Disabled.
    /// </summary>
    public enum AreaMeasurement2DViewModelState
    {
        Disabled,
        Ready,
        Measuring,
        Measured
    }
}
