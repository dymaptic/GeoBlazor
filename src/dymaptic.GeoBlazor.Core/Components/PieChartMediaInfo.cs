namespace dymaptic.GeoBlazor.Core.Components;

public partial class PieChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "pie-chart";


    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord("pie-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord()
        };
    }
}