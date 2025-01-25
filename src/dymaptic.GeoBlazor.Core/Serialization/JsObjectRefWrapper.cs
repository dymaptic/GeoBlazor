namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Wraps the JsObjectReference because a null return will throw an error
///     https://github.com/dotnet/aspnetcore/issues/52070
/// </summary>
/// <param name="Value"></param>
internal record struct JsObjectRefWrapper(IJSObjectReference? Value);