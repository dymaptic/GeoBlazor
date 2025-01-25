namespace dymaptic.GeoBlazor.Core.Components;

public partial class BarChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "bar-chart";


    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord("bar-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord()
        };
    }
}