namespace dymaptic.GeoBlazor.Core.Components;

public partial class CompassViewModel
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     This function provides the ability to override either the <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#goTo">MapView goTo()</a> or <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#goTo">SceneView goTo()</a> methods.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-support-GoTo.html#goToOverride">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [ArcGISProperty]
   [Parameter]
   [JsonIgnore]
   [CodeGenerationIgnore]
   public GoToOverride? GoToOverride { get; set; }
    
   /// <summary>
   ///    JS-invokable method that triggers the <see cref="GoToOverride"/> function.
   ///     Should not be called by consuming code.
   /// </summary>
   [JSInvokable]
   [CodeGenerationIgnore]
   public async Task OnJsGoToOverride(GoToOverrideParameters goToParameters)
   {
      if (GoToOverride is not null)
      {
         await GoToOverride.Invoke(goToParameters);
      }
   }
    
   /// <summary>
   ///     A convenience property that signifies whether a custom <see cref="GoToOverride" /> function was registered.
   /// </summary>
   [CodeGenerationIgnore]
   public bool HasGoToOverride => GoToOverride is not null;
}