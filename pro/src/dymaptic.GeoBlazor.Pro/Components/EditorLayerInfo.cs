namespace dymaptic.GeoBlazor.Pro.Components;

public partial class EditorLayerInfo : MapComponent
{
    /// <summary>
    ///     Indicates whether to enable editing on the layer. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable the ability to create new features. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? AddEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable the ability to update existing features. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? UpdateEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable the ability to delete features. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? DeleteEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable or disable attribute updates from the feature's form. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? AttributeUpdatesEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable or disable attachments while creating features. Support for this is dependent upon the Editor's allowedWorkflows and whether this operation is supported on the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#capabilities">FeatureLayer.capabilities.operations</a>.
    /// </summary>
    [Parameter]
    public bool? AttachmentsOnCreateEnabled { get; set; }

    /// <summary>
    ///     Indicates whether to enable or disable attachments while updating existing features. Support for this is dependent upon the Editor's allowedWorkflows and whether update or delete operations are supported on the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-layers-FeatureLayer.html#capabilities">FeatureLayer.capabilities.operations</a>.
    /// </summary>
    /// <remarks>
    ///     The Editor will not display attachment file names if it is displaying image types. These images must have resize support within its corresponding FeatureLayer, ie. FeatureLayer.capabilities.attachment.supportsResize is true. Attachment types, other than images, will display an icon and its corresponding file name.
    /// </remarks>
    [Parameter]
    public bool? AttachmentsOnUpdateEnabled { get; set; }

    /// <summary>
    ///     The Editor will not display attachment file names if it is displaying image types. These images must have resize support within its corresponding FeatureLayer, ie. FeatureLayer.capabilities.attachment.supportsResize is true. Attachment types, other than images, will display an icon and its corresponding file name. Default Value: true.
    /// </summary>
    [Parameter]
    public bool? GeometryUpdatesEnabled { get; set; }

}


