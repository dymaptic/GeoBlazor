namespace dymaptic.GeoBlazor.Core.Components;

public partial class LineChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "line-chart";


    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "line-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord()
        };
    }
}