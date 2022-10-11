using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     The FieldInfoFormat class is used with numerical or date fields to provide more detail about how the value should be displayed in a popup. Use this class in place of the legacy formatting functions: DateString, DateFormat, and/or NumberFormat.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-support-FieldInfoFormat.html">ArcGIS JS API</a>
/// </summary>
public class FieldInfoFormat : MapComponent
{
    /// <summary>
    ///     Used only with Number fields to specify the number of supported decimal places that should appear in popups.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Places { get; set; }
    
    /// <summary>
    ///     Used only with Number fields.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DigitSeparator { get; set; }
    
    /// <summary>
    ///     Used only with Date fields.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DateFormat { get; set; }
}