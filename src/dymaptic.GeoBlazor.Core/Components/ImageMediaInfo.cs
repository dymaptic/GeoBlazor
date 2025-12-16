namespace dymaptic.GeoBlazor.Core.Components;

[ProtobufSerializable]
public partial class ImageMediaInfo : MediaInfo
{
    /// <inheritdoc/>
    public override string Type => "image-media";

    /// <summary>
    ///     Refresh interval of the layer in minutes. Non-zero value indicates automatic layer refresh at the specified interval. Value of 0 indicates auto refresh is not enabled. If the property does not exist, it is equivalent to having a value of 0.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? RefreshInterval { get; set; }

    /// <inheritdoc />
    public override MediaInfoSerializationRecord ToProtobuf()
    {
        return new MediaInfoSerializationRecord(Id.ToString(), "image-media")
        {
            AltText = AltText,
            Caption = Caption,
            Title = Title,
            Value = Value?.ToProtobuf(),
            RefreshInterval = RefreshInterval
        };
    }
}