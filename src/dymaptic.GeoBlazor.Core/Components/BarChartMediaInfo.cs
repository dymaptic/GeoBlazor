namespace dymaptic.GeoBlazor.Core.Components;

public partial class BarChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "bar-chart";

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