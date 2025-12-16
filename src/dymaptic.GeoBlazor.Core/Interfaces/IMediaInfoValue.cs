namespace dymaptic.GeoBlazor.Core.Interfaces;

/// <summary>
///     Interface for <see cref="ChartMediaInfoValue"/> and <see cref="ImageMediaInfoValue"/>
/// </summary>
[ProtobufSerializable]
public interface IMediaInfoValue: IProtobufSerializable<MediaInfoValueSerializationRecord>
{
}