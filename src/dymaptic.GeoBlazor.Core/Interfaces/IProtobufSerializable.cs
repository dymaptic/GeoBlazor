namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface to indicate that a class can be serialized to and from Protobuf format.
/// </summary>
public interface IProtobufSerializable
{
    public MapComponentSerializationRecord ToProtobuf();
}

/// <summary>
///     Interface to indicate that a class can be serialized to and from an array of Protobuf format records.
/// </summary>
public interface IProtobufArraySerializable
{
    public MapComponentSerializationRecord[] ToProtobufArray();
}