namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ChartMediaInfoValueSeries : MapComponent, 
    IProtobufSerializable<ChartMediaInfoValueSeriesSerializationRecord>
{
    /// <summary>
    ///     Parameterless constructor for use as a Razor Component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    [CodeGenerationIgnore]
    public ChartMediaInfoValueSeries()
    {
    }

    /// <summary>
    ///     Constructor for use in C# code. Use named parameters (e.g., item1: value1, item2: value2) to set properties in any order.
    /// </summary>
    /// <param name="fieldName">
    ///     String value indicating the field's name for a series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#fieldName">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="tooltip">
    ///     String value indicating the tooltip for a series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#tooltip">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    /// <param name="value">
    ///     Numerical value for the chart series.
    ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html#value">ArcGIS Maps SDK for JavaScript</a>
    /// </param>
    [CodeGenerationIgnore]
    public ChartMediaInfoValueSeries(
        string? fieldName = null,
        string? tooltip = null,
        double? value = null)
    {
        AllowRender = false;
#pragma warning disable BL0005
        FieldName = fieldName;
        Tooltip = tooltip;
        Value = value;
#pragma warning restore BL0005    
    }
    
    /// <summary>
    ///     String value indicating the field's name for a series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FieldName { get; set; }

    /// <summary>
    ///     String value indicating the tooltip for a series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Tooltip { get; set; }

    /// <summary>
    ///     Numerical value for the chart series.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Value { get; set; }
    
    /// <inheritdoc />
    public ChartMediaInfoValueSeriesSerializationRecord ToProtobuf()
    {
        return new ChartMediaInfoValueSeriesSerializationRecord(Id.ToString(), FieldName, Tooltip, Value);
    }
}