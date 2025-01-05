namespace dymaptic.GeoBlazor.Core.Objects;


/// <summary>
///     A collection of parameters to pass to locator.addressToLocations
/// </summary>
public record AddressQuery
{
    /// <summary>
    ///     URL to the ArcGIS Server REST resource that represents a locator service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LocatorUrl { get; set; }

    /// <summary>
    ///     Limit result to one or more categories. For example, "Populated Place" or "Scandinavian Food". Only applies to the
    ///     World Geocode Service. See Category filtering (World Geocoding Service) for more information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<string>? Categories { get; set; }

    /// <summary>
    ///     The address argument is data object that contains properties representing the various address fields accepted by
    ///     the corresponding geocode service. These fields are listed in the addressFields property of the associated geocode
    ///     service resource.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Address? Address { get; set; }

    /// <summary>
    ///     Maximum results to return from the query.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxLocations { get; set; }

    /// <summary>
    ///     The list of fields included in the returned result set. This list is a comma delimited list of field names. If you
    ///     specify the shape field in the list of return fields, it is ignored. For non-intersection addresses you can specify
    ///     the candidate fields as defined in the geocode service. For intersection addresses you can specify the intersection
    ///     candidate fields.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public HashSet<string>? OutFields { get; set; }
}

/// <summary>
///     A complete street address for use in an <see cref="AddressQuery" />
/// </summary>
public record Address(string Street, string City, string State, string Zone);


/// <summary>
///     The parameters for percentile statistics. This property must be set when the statisticType is set to either
///     percentile-continuous or percentile-discrete.
/// </summary>
/// <param name="Value">
///     Percentile value. This should be a decimal value between 0 and 1.
/// </param>
public record StatisticParameters(double Value)
{
    /// <summary>
    ///     Specify ASC (ascending) or DESC (descending) to control the order of the data. For example, in a data set of 10
    ///     values from 1 to 10, the percentile value for 0.9 with orderBy set to ascending (ASC) is 9, but when orderBy is set
    ///     to descending (DESC) the result is 2. The default is ASC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OrderBy? OrderBy { get; init; }
}

/// <summary>
///     Filters features from the layer based on pre-authored parameterized filters. When value is not specified for any
///     parameter in a request, the default value, that is assigned during authoring time, gets used. Requires an ArcGIS
///     Enterprise service 10.5 or greater. This parameter is only supported with MapImageLayer pointing to a map service.
/// </summary>
/// <param name="Name">
///     The parameter name.
/// </param>
/// <param name="Value">
///     Single value or array of values.
/// </param>
public record ParameterValue(string Name, object Value);

/// <summary>
///     Filters features from the layer that are within the specified range values. Requires ArcGIS Enterprise services
///     10.5 or greater.This parameter is only supported with MapImageLayer pointing to a map service.
/// </summary>
/// <param name="Name">
///     The range id.
/// </param>
/// <param name="Value">
///     Single value or value range.
/// </param>
public record RangeValue(string Name, object Value);

/// <summary>
///     Used to project the geometry onto a virtual grid, likely representing pixels on the screen. Geometry coordinates
///     are converted to integers by building a grid with a resolution matching the quantizationParameters.tolerance. Each
///     coordinate is then snapped to one pixel on the grid.
/// </summary>
public record QuantizationParameters
{
    /// <summary>
    ///     An extent defining the quantization grid bounds. Its SpatialReference matches the input geometry spatial reference
    ///     if one is specified for the query. Otherwise, the extent will be in the layer's spatial reference.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Extent? Extent { get; init; }

    /// <summary>
    ///     Geometry coordinates are optimized for viewing and displaying of data.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QuantizationMode? Mode { get; init; }

    /// <summary>
    ///     The integer's coordinates will be returned relative to the origin position defined by this property value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public OriginPosition? OriginPosition { get; init; }

    /// <summary>
    ///     The size of one pixel in the units of the outSpatialReference. This number is used to convert coordinates to
    ///     integers by building a grid with a resolution matching the tolerance. Each coordinate is then snapped to one pixel
    ///     on the grid. Consecutive coordinates snapped to the same pixel are removed for reducing the overall response size.
    ///     The units of tolerance will match the units of outSpatialReference. If outSpatialReference is not specified, then
    ///     tolerance is assumed to be in the units of the spatial reference of the layer. If tolerance is not specified, the
    ///     maxAllowableOffset is used. If tolerance and maxAllowableOffset are not specified, a grid of 10,000 * 10,000 grid
    ///     is used by default.
    ///     Default Value: 1
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Tolerance { get; init; }
}

/// <summary>
///     A time extent for a temporal query against time-aware layers. For example, it can be used to discover all crimes
///     that occurred during the night shift from 10 PM to 6 AM on a particular date.
/// </summary>
[JsonConverter(typeof(TimeExtentConverter))]
public record TimeExtent(DateTime Start, DateTime End);

internal class TimeExtentConverter: JsonConverter<TimeExtent>
{
    public override TimeExtent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        DateTime start = DateTime.MinValue;
        DateTime end = DateTime.MinValue;
        while (reader.TokenType != JsonTokenType.EndObject)
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string? propertyName = reader.GetString();
                reader.Read();
                if (reader.TokenType == JsonTokenType.String)
                {
                    switch (propertyName)
                    {
                        case "start":
                            start = DateTime.Parse(reader.GetString()!);
                            break;
                        case "end":
                            end = DateTime.Parse(reader.GetString()!);
                            break;
                    }
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    switch (propertyName)
                    {
                        case "start":
                            start = DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime;
                            break;
                        case "end":
                            end = DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).DateTime;
                            break;
                    }
                }
            }
            reader.Read();
        }
        return new TimeExtent(start, end);
    }

    public override void Write(Utf8JsonWriter writer, TimeExtent value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.Serialize(new
        {
            start = value.Start,
            end = value.End
        }));
    }
}