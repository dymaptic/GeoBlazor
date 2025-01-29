namespace dymaptic.GeoBlazor.Core.Components;
/// <summary>
///     A GroupElement form element defines a container that holds a set of form elements that can be expanded, collapsed, or displayed together. This is the preferred way to set grouped field configurations within a FeatureForm or Featurelayer formTemplate.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-form-elements-GroupElement.html">ArcGIS Maps SDK for JavaScript</a>
/// </summary>
public class GroupElement : FormElement
{
    /// <inheritdoc/>
    public override string Type => "group";
    /// <summary>
    ///     An array of field elements to display as grouped. These objects represent an ordered list of form elements.
    /// </summary>
    /// <remarks>
    ///     Nested group elements are not supported.
    /// </remarks>
    public List<FieldElement>? Elements { get; set; }

    /// <inheritdoc/>
    public override async Task RegisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements ??= new List<FieldElement>();
                Elements.Add(fieldElement);
                break;
            default:
                await base.RegisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    public override async Task UnregisterChildComponent(MapComponent child)
    {
        switch (child)
        {
            case FieldElement fieldElement:
                Elements?.Remove(fieldElement);
                break;
            default:
                await base.UnregisterChildComponent(child);
                break;
        }
    }

    /// <inheritdoc/>
    internal override void ValidateRequiredChildren()
    {
        if (Elements is not null)
        {
            foreach (FieldElement element in Elements)
            {
                element.ValidateRequiredChildren();
            }
        }

        base.ValidateRequiredChildren();
    }
}
