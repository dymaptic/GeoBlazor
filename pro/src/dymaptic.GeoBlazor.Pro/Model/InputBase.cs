namespace dymaptic.GeoBlazor.Pro.Model;

[JsonConverter(typeof(InputBaseConverter))]
public abstract partial record InputBase
{
   // Add custom code to this file to override generated code
   /// <summary>
   ///   Identifies the type of input.
   /// </summary>
   public abstract InputType Type { get; }
}