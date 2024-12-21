namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     This parameter can be either standard SQL92 standard or it can use the native SQL of the underlying datastore
///     native. See the ArcGIS REST API documentation for more information.
/// </summary>
/// <remarks>
///     This property does not apply to layer view or CSVLayer queries.
/// </remarks>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<SqlFormat>))]
public enum SqlFormat
{
#pragma warning disable CS1591
    None,
    Standard,
    Native
#pragma warning restore CS1591
}