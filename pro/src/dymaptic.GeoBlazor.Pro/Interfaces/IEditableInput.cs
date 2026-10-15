namespace dymaptic.GeoBlazor.Pro.Interfaces;

public partial interface IEditableInput
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Interfaces.IEditableInput.html#ieditableinputedittype-property">GeoBlazor Docs</a>
   ///     The type of editable input
   /// </summary>
   [CodeGenerationIgnore]
   EditType? EditType { get; set; }
}