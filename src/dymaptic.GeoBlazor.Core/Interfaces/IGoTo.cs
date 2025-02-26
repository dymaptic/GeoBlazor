namespace dymaptic.GeoBlazor.Core.Interfaces;

[JsonConverter(typeof(MultiTypeConverter<IGoTo>))]
[CodeGenerationIgnore]
public interface IGoTo
{
   /// <summary>
   ///     This function provides the ability to override either the MapView goTo() or SceneView goTo() methods with your own implementation.
   /// </summary>
   [JsonIgnore]
   [CodeGenerationIgnore]
   GoToOverride? GoToOverride { get; set; }

   /// <summary>
   ///     Identifies whether a custom <see cref="GoToOverride" /> was registered.
   /// </summary>
   [CodeGenerationIgnore]
   bool HasGoToOverride => GoToOverride is not null;
    
   /// <summary>
   ///     JavaScript-invokable method for internal use
   /// </summary>
   [JSInvokable]
   [CodeGenerationIgnore]
   Task OnJavaScriptGoToOverride(GoToOverrideParameters goToOverrideParams)
   {
      return GoToOverride?.Invoke(goToOverrideParams) ?? Task.CompletedTask;
   }
}