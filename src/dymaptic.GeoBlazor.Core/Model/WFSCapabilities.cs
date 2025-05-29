namespace dymaptic.GeoBlazor.Core.Model;

public partial record WFSCapabilities
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///   The URL of the WFS service that these capabilities describe.
   /// </summary>
   public string? Url { get; init; }
}