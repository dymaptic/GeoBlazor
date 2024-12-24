using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Popups;

/// <summary>
///     Base class for all MediaInfos used in <see cref="MediaPopupContent" />
/// </summary>
[JsonConverter(typeof(MediaInfoConverter))]
public abstract class MediaInfo : MapComponent
{
    /// <summary>
    ///     Indicates the type of media
    /// </summary>
    public abstract string Type { get; }

    internal abstract MediaInfoSerializationRecord ToSerializationRecord();
}

[ProtoContract(Name = "MediaInfo")]
internal record MediaInfoSerializationRecord : MapComponentSerializationRecord
{
    public MediaInfoSerializationRecord()
    {
    }
    
    public MediaInfoSerializationRecord(string Type)
    {
        this.Type = Type;
    }

    [ProtoMember(1)]
    public string Type { get; init; } = string.Empty;
    
    [ProtoMember(2)]
    public string? AltText { get; init; }

    [ProtoMember(3)]
    public string? Caption { get; init; }

    [ProtoMember(4)]
    public string? Title { get; init; }

    [ProtoMember(5)]
    public ChartMediaInfoValueSerializationRecord? Value { get; init; }

    [ProtoMember(6)]
    public double? RefreshInterval { get; init; }

    public MediaInfo FromSerializationRecord()
    {
        return Type switch
        {
            "bar-chart" => new BarChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue),
            "column-chart" => new ColumnChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue),
            "pie-chart" => new PieChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue),
            "line-chart" => new LineChartMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ChartMediaInfoValue),
            "image-media" => new ImageMediaInfo(Title, Caption, AltText,
                Value?.FromSerializationRecord() as ImageMediaInfoValue,
                RefreshInterval),
            _ => throw new NotSupportedException($"MediaInfo type {Type} is not supported.")
        };
    }
}

/// <summary>
///     A BarChartMediaInfo is a type of chart media element that represents a bar chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-BarChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BarChartMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public BarChartMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="BarChartMediaInfo" /> in code.
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
    public BarChartMediaInfo(string? title = null, string? caption = null, string? altText = null,
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
    public override string Type => "bar-chart";

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
        return new MediaInfoSerializationRecord("bar-chart")
        {
            AltText = AltText, Caption = Caption, Title = Title, Value = Value?.ToSerializationRecord()
        };
    }
}

/// <summary>
///     The ChartMediaInfoValue class contains information for popups regarding how charts should be constructed.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValue.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ChartMediaInfoValue : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ChartMediaInfoValue()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ChartMediaInfoValue" /> in code.
    /// </summary>
    /// <param name="fields">
    ///     An array of strings, with each string containing the name of a field to display in the chart.
    /// </param>
    /// <param name="normalizeField">
    ///     A string containing the name of a field. The values of all fields in the chart will be normalized (divided) by the
    /// </param>
    /// <param name="tooltipField">
    ///     String value indicating the tooltip for a chart specified from another field. It is used for showing tooltips from
    /// </param>
    /// <param name="series">
    ///     An array of ChartMediaInfoValueSeries objects which provide information of x/y data that is plotted in a chart.
    /// </param>
    public ChartMediaInfoValue(IReadOnlyCollection<string>? fields = null, string? normalizeField = null,
        string? tooltipField = null, IReadOnlyList<ChartMediaInfoValueSeries>? series = null)
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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

    /// <inheritdoc />
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
        return new ChartMediaInfoValueSerializationRecord(Fields, NormalizeField, TooltipField,
            Series?.Select(s => s.ToSerializationRecord()));
    }
}

[ProtoContract(Name = "ChartMediaInfoValue")]
internal record ChartMediaInfoValueSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSerializationRecord()
    {
    }
    
    public ChartMediaInfoValueSerializationRecord(IEnumerable<string>? Fields = null,
        string? NormalizeField = null,
        string? TooltipField = null,
        IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series = null,
        string? LinkURL = null,
        string? SourceURL = null)
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

        return new ChartMediaInfoValue(Fields?.ToArray(), NormalizeField, TooltipField,
            Series?.Select(s => s.FromSerializationRecord()).ToArray());
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

/// <summary>
///     The ChartMediaInfoValueSeries class is a read-only support class that represents information specific to how data
///     should be plotted in a chart. It helps provide a consistent API for plotting charts used by the Popup widget.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ChartMediaInfoValueSeries.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ChartMediaInfoValueSeries : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ChartMediaInfoValueSeries()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ChartMediaInfoValueSeries" /> in code.
    /// </summary>
    /// <param name="fieldName">
    ///     String value indicating the field's name for a series.
    /// </param>
    /// <param name="tooltip">
    ///     String value indicating the tooltip for a series.
    /// </param>
    /// <param name="value">
    ///     Numerical value for the chart series.
    /// </param>
    public ChartMediaInfoValueSeries(string? fieldName = null, string? tooltip = null,
        double? value = null)
    {
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

    internal ChartMediaInfoValueSeriesSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSeriesSerializationRecord(FieldName, Tooltip, Value);
    }
}

[ProtoContract(Name = "ChartMediaInfoValueSeries")]
internal record ChartMediaInfoValueSeriesSerializationRecord : MapComponentSerializationRecord
{
    public ChartMediaInfoValueSeriesSerializationRecord()
    {
    }
    
    public ChartMediaInfoValueSeriesSerializationRecord(string? FieldName,
        string? Tooltip,
        double? Value)
    {
        this.FieldName = FieldName;
        this.Tooltip = Tooltip;
        this.Value = Value;
    }

    public ChartMediaInfoValueSeries FromSerializationRecord()
    {
        return new ChartMediaInfoValueSeries(FieldName, Tooltip, Value);
    }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(1)]
    public string? FieldName { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(2)]
    public string? Tooltip { get; init; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ProtoMember(3)]
    public double? Value { get; init; }
}

/// <summary>
///     A ColumnChartMediaInfo is a type of chart media element that represents a column chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ColumnChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ColumnChartMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ColumnChartMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ColumnChartMediaInfo" /> in code.
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
    public ColumnChartMediaInfo(string? title = null, string? caption = null, string? altText = null,
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
    public override string Type => "column-chart";

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
        return new MediaInfoSerializationRecord("column-chart")
        {
            AltText = AltText, Caption = Caption, Title = Title, Value = Value?.ToSerializationRecord()
        };
    }
}

/// <summary>
///     An ImageMediaInfo is a type of media element that represents images to display within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ImageMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ImageMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ImageMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ImageMediaInfo" /> in code.
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
    ///     Defines the value format of the image media element and how the images should be retrieved.
    /// </param>
    /// <param name="refreshInterval">
    ///     Refresh interval of the layer in minutes. Non-zero value indicates automatic layer refresh at the specified
    /// </param>
    public ImageMediaInfo(string? title = null, string? caption = null, string? altText = null,
        ImageMediaInfoValue? value = null, double? refreshInterval = null)
    {
#pragma warning disable BL0005
        Title = title;
        Caption = caption;
        AltText = altText;
        Value = value;
        RefreshInterval = refreshInterval;
#pragma warning restore BL0005
    }

    /// <inheritdoc />
    public override string Type => "image-media";

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
    ///     Refresh interval of the layer in minutes. Non-zero value indicates automatic layer refresh at the specified
    ///     interval. Value of 0 indicates auto refresh is not enabled. If the property does not exist, it is equivalent to
    ///     having a value of 0.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <summary>
    ///     Defines the value format of the image media element and how the images should be retrieved.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ImageMediaInfoValue? Value { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ImageMediaInfoValue imageMediaInfoValue:
                Value = imageMediaInfoValue;

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
            case ImageMediaInfoValue:
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
        return new MediaInfoSerializationRecord("image-media")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord(),
            RefreshInterval = RefreshInterval
        };
    }
}

/// <summary>
///     The ImageMediaInfoValue class contains information for popups regarding how images should be retrieved.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-support-ImageMediaInfoValue.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ImageMediaInfoValue : MapComponent
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public ImageMediaInfoValue()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="ImageMediaInfoValue" /> in code.
    /// </summary>
    /// <param name="linkURL">
    ///     A string containing a URL to be launched in a browser when a user clicks the image.
    /// </param>
    /// <param name="sourceURL">
    ///     A string containing the URL to the image.
    /// </param>
    public ImageMediaInfoValue(string? linkURL = null, string? sourceURL = null)
    {
#pragma warning disable BL0005
        LinkURL = linkURL;
        SourceURL = sourceURL;
#pragma warning restore BL0005
    }

    /// <summary>
    ///     A string containing a URL to be launched in a browser when a user clicks the image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LinkURL { get; set; }

    /// <summary>
    ///     A string containing the URL to the image.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SourceURL { get; set; }

    internal ChartMediaInfoValueSerializationRecord ToSerializationRecord()
    {
        return new ChartMediaInfoValueSerializationRecord(LinkURL: LinkURL, SourceURL: SourceURL);
    }
}

/// <summary>
///     A LineChartMediaInfo is a type of chart media element that represents a line chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-LineChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LineChartMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
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

/// <summary>
///     A PieChartMediaInfo is a type of chart media element that represents a pie chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-PieChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class PieChartMediaInfo : MediaInfo
{
    /// <summary>
    ///     Parameterless constructor for use as a razor component.
    /// </summary>
    [ActivatorUtilitiesConstructor]
    public PieChartMediaInfo()
    {
    }

    /// <summary>
    ///     Constructor for building a <see cref="PieChartMediaInfo" /> in code.
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
    public PieChartMediaInfo(string? title = null, string? caption = null, string? altText = null, 
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
    public override string Type => "pie-chart";

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
        return new MediaInfoSerializationRecord("pie-chart")
        {
            AltText = AltText, Caption = Caption, Title = Title, Value = Value?.ToSerializationRecord()
        };
    }
}

internal class MediaInfoConverter : JsonConverter<MediaInfo>
{
    public override MediaInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // check the type property and deserialize to the correct type
        var jsonDoc = JsonDocument.ParseValue(ref reader);
        string? type = jsonDoc.RootElement.GetProperty("type").GetString();

        switch (type)
        {
            case "bar-chart":
                return JsonSerializer.Deserialize<BarChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "column-chart":
                return JsonSerializer.Deserialize<ColumnChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "pie-chart":
                return JsonSerializer.Deserialize<PieChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "line-chart":
                return JsonSerializer.Deserialize<LineChartMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
            case "image-media":
                return JsonSerializer.Deserialize<ImageMediaInfo>(jsonDoc.RootElement.GetRawText(), options);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, MediaInfo value, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        writer.WriteRawValue(JsonSerializer.Serialize(value, typeof(object), newOptions));
    }
}