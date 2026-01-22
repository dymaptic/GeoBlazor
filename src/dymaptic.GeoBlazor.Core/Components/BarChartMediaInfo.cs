namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class BarChartMediaInfo : MediaInfo
{
    /// <inheritdoc/>
    public override string Type => "bar-chart";

    /// <inheritdoc />
    public override MediaInfoSerializationRecord ToProtobuf()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "bar-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToProtobuf()
        };
    }
}