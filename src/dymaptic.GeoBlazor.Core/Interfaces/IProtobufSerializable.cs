namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface to indicate that a class can be serialized to and from Protobuf format.
/// </summary>
public interface IProtobufSerializable
{
    /// <summary>
    ///     Converts the class to its Protobuf serialization record.
    /// </summary>
    /// <returns></returns>
    MapComponentSerializationRecord ToProtobuf();
}