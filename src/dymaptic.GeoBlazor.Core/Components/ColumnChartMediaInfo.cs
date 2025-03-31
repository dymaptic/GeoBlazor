namespace dymaptic.GeoBlazor.Core.Components;

public partial class ColumnChartMediaInfo : MediaInfo
{


    /// <inheritdoc/>
    public override string Type => "column-chart";


    internal override MediaInfoSerializationRecord ToSerializationRecord()
    {
        return new MediaInfoSerializationRecord("column-chart")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToSerializationRecord()
        };
    }
}