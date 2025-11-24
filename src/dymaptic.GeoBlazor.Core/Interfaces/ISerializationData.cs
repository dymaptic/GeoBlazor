namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for source-generated serialization data classes.
/// </summary>
public interface ISerializationData
{
    Dictionary<string, SerializableMethodRecord[]> SerializableMethods { get; }
    
    Dictionary<Type, Type> ProtoContractTypes { get; }
    
    Dictionary<Type, Type> ProtoCollectionTypes { get; }

    Task<T?> ReadJsProtobufStreamReference<T>(IJSStreamReference jsStreamReference,
        Type returnType, long maxAllowedSize = 1_000_000_000);

    Task<T?> ReadJsProtobufCollectionStreamReference<T>(IJSStreamReference jsStreamReference,
        Type returnType, long maxAllowedSize = 1_000_000_000);

    object GenerateProtobufParameter(object value, Type serializableType, bool isServer);

    object GenerateProtobufCollectionParameter(IList items, Type serializableType, bool isServer);
}