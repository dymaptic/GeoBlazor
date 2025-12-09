using ProtoBuf;

namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Base class for all Protobuf serialization records for MapComponents.
/// </summary>
[ProtoContract(Name = "MapComponent")]
public record MapComponentSerializationRecord
{
    /// <summary>
    ///     Indicates whether this record represents a null value.
    /// </summary>
    [ProtoMember(1000)]
    public virtual bool IsNull { get; init; }
}

/// <summary>
///     Generic base class for Protobuf serialization records that can convert back to their source type.
/// </summary>
/// <typeparam name="T">The type that this record serializes.</typeparam>
public abstract record MapComponentSerializationRecord<T> : MapComponentSerializationRecord
{
    /// <summary>
    ///     Converts this serialization record back to its source type.
    /// </summary>
    public abstract T? FromSerializationRecord();
}

/// <summary>
///     Base class for Protobuf serialization records representing collections.
/// </summary>
[ProtoContract(Name = "MapComponentCollection")]
public record MapComponentBaseCollectionSerializationRecord
{
    /// <summary>
    ///     Indicates whether this record represents a null collection.
    /// </summary>
    [ProtoMember(1000)]
    public virtual bool IsNull { get; init; }
}

/// <summary>
///     Generic base class for Protobuf serialization records representing collections.
/// </summary>
/// <typeparam name="TItem">The type of items in the collection.</typeparam>
public abstract record MapComponentCollectionSerializationRecord<TItem> : MapComponentBaseCollectionSerializationRecord
    where TItem : MapComponentSerializationRecord
{
    /// <summary>
    ///     The items in the collection.
    /// </summary>
    public abstract TItem[]? Items { get; set; }
}

/// <summary>
///     Record representing serializable method metadata for JS interop.
/// </summary>
public record SerializableMethodRecord(
    string MethodName,
    SerializableParameterRecord[]? Parameters,
    SerializableParameterRecord? ReturnValue);

/// <summary>
///     Record representing a serializable parameter for JS interop.
/// </summary>
public record SerializableParameterRecord(
    string Name,
    Type Type,
    bool IsNullable,
    bool IsCollection,
    Type? CollectionItemType);
