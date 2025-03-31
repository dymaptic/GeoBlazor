using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;


namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Wraps the JsObjectReference because a null return will throw an error
///     https://github.com/dotnet/aspnetcore/issues/52070
/// </summary>
internal record struct JsObjectRefWrapper(IJSObjectReference? Value);

/// <summary>
///     Wraps a nullable double value for serialization
/// </summary>
internal record struct JsNullableDoubleWrapper(double? Value);

/// <summary>
///     Wraps a nullable int value for serialization
/// </summary>
internal record struct JsNullableIntWrapper(int? Value);

/// <summary>
///     Wraps a nullable long value for serialization
/// </summary>
internal record struct JsNullableLongWrapper(long? Value);

/// <summary>
///     Wraps a nullable bool value for serialization
/// </summary>
internal record struct JsNullableBoolWrapper(bool? Value);

/// <summary>
///     Wraps a nullable DateTime value for serialization
/// </summary>
internal record struct JsNullableDateTimeWrapper(DateTime? Value);

/// <summary>
///     Wraps a nullable ElementReference value for serialization
/// </summary>
internal record struct JsNullableElementReferenceWrapper(ElementReference? Value);

/// <summary>
///     Wraps a nullable Enum value for serialization
/// </summary>
internal record struct JsNullableEnumWrapper<T>(T? Value) where T : struct, Enum;