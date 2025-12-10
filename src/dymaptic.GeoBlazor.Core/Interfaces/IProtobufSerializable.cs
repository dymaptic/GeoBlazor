using dymaptic.GeoBlazor.Core.Serialization;

namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface to indicate that a class can be serialized to and from Protobuf format.
/// </summary>
/// <typeparam name="T">The serialization record type.</typeparam>
public interface IProtobufSerializable<out T> where T : MapComponentSerializationRecord, new()
{
    /// <summary>
    ///     Converts the class to its Protobuf serialization record.
    /// </summary>
    /// <returns>
    ///     Returns the serializable instance
    /// </returns>
    T ToProtobuf();
}
