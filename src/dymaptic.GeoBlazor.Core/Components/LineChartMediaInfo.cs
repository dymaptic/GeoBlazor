namespace dymaptic.GeoBlazor.Core.Components;

public partial class LineChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "line-chart";

    /// <inheritdoc />
    public override MediaInfoSerializationRecord ToProtobuf()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "line-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToProtobuf()
        };
    }
}