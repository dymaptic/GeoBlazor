namespace dymaptic.GeoBlazor.Core.Components;

public partial class FeaturesViewModel: IViewModel
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
   ///    JS-invokable method that triggers the <see cref = "GoToOverride"/> function.
   ///     Should not be called by consuming code.
   /// </summary>
   [JSInvokable]
   [CodeGenerationIgnore]
   public async Task OnJsGoToOverride(IJSStreamReference jsStreamRef)
   {
      await using Stream stream = await jsStreamRef.OpenReadStreamAsync(1_000_000_000L);
      await using MemoryStream ms = new();
      await stream.CopyToAsync(ms);
      ms.Seek(0, SeekOrigin.Begin);
      byte[] encodedJson = ms.ToArray();
      string json = Encoding.UTF8.GetString(encodedJson);
      GoToOverrideParameters goToParameters = JsonSerializer.Deserialize<GoToOverrideParameters>(
         json, GeoBlazorSerialization.JsonSerializerOptions)!;
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
   
   /// <summary>
   ///     Use this method to return feature(s) at a given screen location.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#fetchFeatures">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   /// <param name="screenPoint">
   ///     An object representing a point on the screen. This point can be in either the
   ///     <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-MapView.html#ScreenPoint">MapView</a> or
   ///     <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-views-SceneView.html#ScreenPoint">SceneView</a>.
   /// </param>
   /// <param name="options">
   ///     The <a href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features.html#FetchFeaturesOptions">options</a> to pass into the <code>fetchFeatures</code> method.
   /// </param>
   /// <param name="cancellationToken">
   ///     The CancellationToken to cancel an asynchronous operation.
   /// </param>
   [ArcGISMethod]
   [CodeGenerationIgnore]
   public async Task<FetchPopupFeaturesResult?> FetchFeatures(ScreenPoint screenPoint,
      PopupFetchFeaturesOptions options,
      CancellationToken cancellationToken = default)
   {
      if (JsComponentReference is null) return null;
        
      IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
      FetchPopupFeaturesResult? result = await JsComponentReference!.InvokeAsync<FetchPopupFeaturesResult?>(
         "fetchFeatures", 
         CancellationTokenSource.Token,
         screenPoint,
         new { options.Event, signal = abortSignal });
                
      await AbortManager.DisposeAbortController(cancellationToken);
        
      return result;
   }
   
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Core.Components.FeaturesViewModel.html#featuresviewmodelzoomto-method">GeoBlazor Docs</a>
   ///     Sets the view to a given target.
   ///     param params The parameters to pass to the `zoomTo()` method.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-Features-FeaturesViewModel.html#zoomTo">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   /// <param name="target">
   /// </param>
   /// <param name="options">
   /// </param>
   [ArcGISMethod]
   [CodeGenerationIgnore]
   public async Task<string?> ZoomTo(GoToTarget target,
      GoToOptions options)
   {
      if (JsComponentReference is null) return null;
        
      return await JsComponentReference!.InvokeAsync<string?>(
         "zoomTo", 
         CancellationTokenSource.Token,
         new { target, options });
   }
}