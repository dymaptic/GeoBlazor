namespace dymaptic.GeoBlazor.Pro.Model;

public partial record RelationshipInput : IEditableInput
{
    /// <inheritdoc />
    public override FeatureFormInputType Type => FeatureFormInputType.Relationship;
    
    /// <inheritdoc />
    public EditType? EditType { get; set; }
}

