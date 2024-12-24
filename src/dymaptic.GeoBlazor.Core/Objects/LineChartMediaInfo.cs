namespace dymaptic.GeoBlazor.Core.Objects;

/// <summary>
///     A LineChartMediaInfo is a type of chart media element that represents a line chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-LineChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LineChartMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    public LineChartMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="LineChartMediaInfo" /> in code.
    /// </summary>
    /// <param name="title">
    ///     The title of the media element.
    /// </param>
    /// <param name="caption">
    ///     Defines a caption for the media.
    /// </param>
    /// <param name="altText">
    ///     Provides an alternate text for an image if the image cannot be displayed.
    /// </param>
    /// <param name="value">
    ///     Defines the chart value.
    /// </param>
    public LineChartMediaInfo(string? title = null, string? caption = null, string? altText = null,
        ChartMediaInfoValue? value = null)
    {
#pragma warning disable BL0005
        Title = title;
        Caption = caption;
        AltText = altText;
        Value = value;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "line-chart";

    /// <summary>
    ///     Provides an alternate text for an image if the image cannot be displayed.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AltText { get; set; }

    /// <summary>
    ///     Defines a caption for the media.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Caption { get; set; }

    /// <summary>
    ///     The title of the media element.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     Defines the chart value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChartMediaInfoValue? Value { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValue chartMediaInfoValue:
                Value = chartMediaInfoValue;

                break;
            default:
                await base.RegisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValue:
                Value = null;

                break;
            default:
                await base.UnregisterChildComponent(child);

                break;
        }
    }

    /// <inheritdoc />
    internal override void ValidateRequiredChildren()
    {
        base.ValidateRequiredChildren();
        Value?.ValidateRequiredChildren();
    }

    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord("line-chart")
        {
            AltText = AltText, Caption = Caption, Title = Title, Value = Value?.ToSerializationRecord()
        };
    }
}