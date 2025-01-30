namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Wraps the JsObjectReference because a null return will throw an error
///     https://github.com/dotnet/aspnetcore/issues/52070
/// </summary>
internal record struct JsObjectRefWrapper(IJSObjectReference? Value);

internal record struct JsNullableDoubleWrapper(double? Value);

internal record struct JsNullableFloatWrapper(float? Value);

internal record struct JsNullableIntWrapper(int? Value);    

internal record struct JsNullableBoolWrapper(bool? Value);

internal record struct JsNullableDateTimeWrapper(DateTime? Value);