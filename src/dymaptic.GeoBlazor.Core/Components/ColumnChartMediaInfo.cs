namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ColumnChartMediaInfo : MediaInfo
{
    /// <inheritdoc/>
    public override string Type => "column-chart";

    /// <inheritdoc />
    public override MediaInfoSerializationRecord ToProtobuf()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "column-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToProtobuf()
        };
    }
}