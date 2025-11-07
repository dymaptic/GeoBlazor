namespace dymaptic.GeoBlazor.Core.Components;

public partial class PieChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "pie-chart";


    public override MediaInfoSerializationRecord ToProtobuf()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "pie-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToProtobuf()
        };
    }
}