// File auto-generated by dymaptic tooling. Any changes made here will be lost on future generation. To override functionality, use the relevant root .cs file.

namespace dymaptic.GeoBlazor.Core.Enums;

/// <summary>
///     <summary>
///          Authentication modes for the <see cref="RequestOptions" /> class.
///      </summary>
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<AuthMode>))]
public enum AuthMode
{
#pragma warning disable CS1591
    Auto,
    Anonymous,
    Immediate,
    NoPrompt
#pragma warning restore CS1591
}
