namespace dymaptic.GeoBlazor.Core.Serialization;

/// <summary>
///     Partial class containing serialization data for core GeoBlazor types.
///     Source generator provides implementation.
/// </summary>

// ReSharper disable once PartialTypeWithSinglePart
internal static partial class CoreSerializationData
{
    public static partial Dictionary<string, SerializableMethodRecord[]> SerializableMethods { get; }

    public static partial Dictionary<Type, Type> ProtoContractTypes { get; }

    public static partial Dictionary<Type, Type> ProtoCollectionTypes { get; }

    public static partial object ToProtobufParameter(this object value, Type serializableType, bool isServer);

    public static partial object ToProtobufCollectionParameter(this IList items, Type serializableType, bool isServer);

    public static partial Task<IProtobufSerializable?> ReadJsStreamReferenceAsProtobuf(
        this IJSStreamReference jsStreamReference,
        Type returnType, long? maxAllowedSize = null, CancellationToken cancellationToken = default);

    public static partial Task<IProtobufSerializable[]?> ReadJsStreamReferenceAsProtobufCollection(
        this IJSStreamReference jsStreamReference,
        Type returnType, long? maxAllowedSize = null, CancellationToken cancellationToken = default);
}