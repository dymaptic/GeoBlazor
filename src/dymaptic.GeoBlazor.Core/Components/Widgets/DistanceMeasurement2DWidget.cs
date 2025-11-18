namespace dymaptic.GeoBlazor.Core.Components.Widgets;

public partial class DistanceMeasurement2DWidget: IMeasurementWidgetActiveWidget
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///      Parameter changed event callback for the ViewModel property.
   /// </summary>
   [Parameter]
   [JsonIgnore]
   public EventCallback<DistanceMeasurement2DViewModel> ViewModelChanged { get; set; }
}