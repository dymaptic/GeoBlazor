using Microsoft.AspNetCore.Components;
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
internal record MediaInfoSerializationRecord([property: ProtoMember(1)] string Type)
    : MapComponentSerializationRecord
{
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
}

/// <summary>
///     A BarChartMediaInfo is a type of chart media element that represents a bar chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-BarChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class BarChartMediaInfo : MediaInfo
{
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
    public HashSet<ChartMediaInfoValueSeries>? Series { get; set; }

    /// <inheritdoc />
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case ChartMediaInfoValueSeries series:
                Series ??= new HashSet<ChartMediaInfoValueSeries>();
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
internal record ChartMediaInfoValueSerializationRecord([property: ProtoMember(1)] IEnumerable<string>? Fields = null,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(2)]
        string? NormalizeField = null,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(3)]
        string? TooltipField = null,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(4)]
        IEnumerable<ChartMediaInfoValueSeriesSerializationRecord>? Series = null,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(5)]
        string? LinkURL = null,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(6)]
        string? SourceURL = null)
    : MapComponentSerializationRecord;

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
internal record ChartMediaInfoValueSeriesSerializationRecord(
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(1)]
        string? FieldName,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(2)]
        string? Tooltip,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [property: ProtoMember(3)]
        double? Value)
    : MapComponentSerializationRecord;

/// <summary>
///     A ColumnChartMediaInfo is a type of chart media element that represents a column chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-ColumnChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class ColumnChartMediaInfo : MediaInfo
{
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

internal record ImageMediaInfoValueSerializationRecord(
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? LinkURL,
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? SourceURL)
    : MapComponentSerializationRecord;

/// <summary>
///     A LineChartMediaInfo is a type of chart media element that represents a line chart displayed within a popup.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-popup-content-LineChartMediaInfo.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class LineChartMediaInfo : MediaInfo
{
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