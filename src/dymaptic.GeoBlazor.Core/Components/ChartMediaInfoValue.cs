namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     The ChartMediaInfoValue class contains information for popups regarding how charts should be constructed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValue.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ChartMediaInfoValue : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public ChartMediaInfoValue()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref = "ChartMediaInfoValue"/> in code.
    /// </summary>
    /// <param name = "fields">
    ///     An array of strings, with each string containing the name of a field to display in the chart.
    /// </param>
    /// <param name = "normalizeField">
    ///     A string containing the name of a field. The values of all fields in the chart will be normalized (divided) by the
    /// </param>
    /// <param name = "tooltipField">
    ///     String value indicating the tooltip for a chart specified from another field. It is used for showing tooltips from
    /// </param>
    /// <param name = "series">
    ///     An array of ChartMediaInfoValueSeries objects which provide information of x/y data that is plotted in a chart.
    /// </param>
    public ChartMediaInfoValue(IReadOnlyCollection<string>? fields = null, string? normalizeField = null, string? tooltipField = null, IReadOnlyList<ChartMediaInfoValueSeries>? series = null)
    {
#pragma warning disable BL0005
        if (fields is not null)
        {
            Fields = fields.ToList();
        }

        NormalizeField = normalizeField;
        TooltipField = tooltipField;
        if (series is not null)
        {
            Series = series.ToList();
        }
#pragma warning restore BL0005
    }

    /// <summary>
    ///     An array of strings, with each string containing the name of a field to display in the chart.
    /// </summary>
    /// <remarks>
    ///     In order to work with related fields within a chart, the fields must either be set as a fields element in the
    ///     PopupTemplate's content or as popupTemplate.fieldInfos property outside of the PopupTemplate's content.
    ///     Set the popupTemplate.fieldInfos property for any fields that need to have number formatting for chart/text
    ///     elements.
    /// </remarks>
    [Parameter]
    public IEnumerable<string> Fields { get; set; } = new List<string>();

    /// <summary>
    ///     A string containing the name of a field. The values of all fields in the chart will be normalized (divided) by the
    ///     value of this field.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NormalizeField { get; set; }

    /// <summary>
    ///     String value indicating the tooltip for a chart specified from another field. It is used for showing tooltips from
    ///     another field in the same layer or related layer/table.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TooltipField { get; set; }

    /// <summary>
    ///     An array of ChartMediaInfoValueSeries objects which provide information of x/y data that is plotted in a chart.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<ChartMediaInfoValueSeries>? Series { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValueSeries series:
                Series ??= new List<ChartMediaInfoValueSeries>();
                Series.Add(series);
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValueSeries series:
                Series?.Remove(series);
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        if (Series is not null)
        {
            foreach (ChartMediaInfoValueSeries series in Series)
            {
                series.ValidateRequiredChildren();
            }
        }
    }

    internal ChartMediaInfoValueSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSerializationRecord(Fields, NormalizeField, TooltipField, Series?.Select(s => s.ToSerializationRecord()));
    }
}

[ProtoContract(Name = "ChartMediaInfoValue")]
internal record ChartMediaInfoValueSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSerializationRecord()
    {
    }

    public ChartMediaInfoValueSerializationRecord(IEnumerable<string>? Fields = null, string? NormalizeField = null, string? TooltipField = null, IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series = null, string? LinkURL = null, string? SourceURL = null)
    {
        this.Fields = Fields;
        this.NormalizeField = NormalizeField;
        this.TooltipField = TooltipField;
        this.Series = Series;
        this.LinkURL = LinkURL;
        this.SourceURL = SourceURL;
    }

    public object FromSerializationRecord()
    {
        if (LinkURL is not null || SourceURL is not null)
        {
            return new ImageMediaInfoValue(LinkURL, SourceURL);
        }

        return new ChartMediaInfoValue(Fields?.ToArray(), NormalizeField, TooltipField, Series?.Select(s => s.FromSerializationRecord()).ToArray());
    }

    [ProtoMember(1)]
    public IEnumerable<string>? Fields { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? NormalizeField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public string? TooltipField { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(4)]
    public IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(5)]
    public string? LinkURL { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(6)]
    public string? SourceURL { get; init; }
}