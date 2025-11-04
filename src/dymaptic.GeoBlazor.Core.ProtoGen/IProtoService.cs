using dymaptic.GeoBlazor.Core.Serialization;
using ProtoBuf;
using ProtoBuf.Grpc.Configuration;


namespace dymaptic.GeoBlazor.Core.ProtoGen;

[Service]
public interface IProtoService
{
    [Operation]
    MapComponentSerializationRecord GenerateProtobufClasses()
    {
        return new GeometrySerializationRecord();
    }

    [Operation]
    MapComponentBaseCollectionSerializationRecord GenerateMapComponentCollection()
    {
        Type itemType = protoCollectionTypes.First();
        var instance = (MapComponentBaseCollectionSerializationRecord)Activator.CreateInstance(itemType)!;
        return instance;
    }
    
    private static readonly Type[] protoCollectionTypes = typeof(MapComponentCollectionSerializationRecord<>)
        .GetCustomAttributes(typeof(ProtoIncludeAttribute), false)
        .Cast<ProtoIncludeAttribute>()
        .Select(pa => pa.KnownType)
        .ToArray();
}

public class ProtoService : IProtoService
{
}