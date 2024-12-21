namespace dymaptic.GeoBlazor.Core.Options;

/// <summary>
///     Default update options set for the Sketch widget. Update options set on this property will be overwritten if the update options are changed when update() method is called.
/// </summary>
/// <param name="Tool">
///     Name of the update tool. The default tool is transform for graphics with polygon and polyline geometries and move for graphics with point and multipoint geometries. However, if a graphic with point geometry uses a 3D object symbol layer, the default tool is transform.
///     Possible Values:"move"|"transform"|"reshape"
/// </param>
/// <param name="EnableRotation">
///     Indicates if the rotation operation will be enabled when updating graphics. Only applies if tool is transform. Default Value: true.
/// </param>
/// <param name="EnableScaling">
///     Indicates if the scale operation will be enabled when updating graphics. Only applies if tool is transform. Default Value: true.
/// </param>
/// <param name="EnableZ">
///     Indicates if z-values can be modified when updating the graphic. When enabled, the height handle manipulator is displayed. Default Value: true.
/// </param>
/// <param name="MultipleSelectionEnabled">
///     Indicates whether more than one selection can be made at once. This applies to the shift+click interaction with the transform tool. Default Value: true.
/// </param>
/// <param name="PreserveAspectRatio">
///     Indicates if the uniform scale operation will be enabled when updating graphics. enableScaling must be set true when setting this property to true. Only applies if tool is transform and is always true when transforming points that use a 3D object symbol layer. Default Value: false.
/// </param>
/// <param name="ToggleToolOnClick">
///     Indicates if the graphic being updated can be toggled between transform and reshape update options. Default Value: true.
/// </param>
/// <param name="ReshapeOptions">
///     Changes the behavior for the reshape tool. Defines the operations for edge and/or the constraints for moving a shape and/or a vertex. Only supported in 3D.
/// </param>
/// <param name="HighlightOptions">
///     Options that control when to display or hide highlights for update operations.
/// </param>
public record SketchToolUpdateOptions(SketchTool Tool, bool EnableRotation, bool EnableScaling, bool EnableZ, 
    bool MultipleSelectionEnabled, bool PreserveAspectRatio, bool ToggleToolOnClick, ReshapeOptions ReshapeOptions,
    DefaultUpdateHighlightOptions HighlightOptions);