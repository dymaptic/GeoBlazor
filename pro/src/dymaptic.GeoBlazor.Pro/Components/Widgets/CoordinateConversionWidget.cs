namespace dymaptic.GeoBlazor.Pro.Components.Widgets;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class CoordinateConversionWidget
{
   // Add custom code to this file to override generated code
   
   /// <summary>
   ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Widgets.CoordinateConversionWidget.html#coordinateconversionwidgetformats-property">GeoBlazor Docs</a>
   ///     A <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-core-Collection.html">Collection</a> containing every <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CoordinateConversion-support-Format.html">Format</a>
   ///     that the widget is capable of displaying.
   ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-widgets-CoordinateConversion.html#formats">ArcGIS Maps SDK for JavaScript</a>
   /// </summary>
   [ArcGISProperty]
   [Parameter]
   [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
   [CodeGenerationIgnore]
   public IReadOnlyList<ConversionFormat>? Formats { get; set; }
   
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
       GoToOverrideParameters? goToParameters = await jsStreamRef.ReadJsStreamReference<GoToOverrideParameters>();
       if (GoToOverride is not null && goToParameters is not null)
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
   ///     Asynchronously retrieve the current value of the Formats property.
   /// </summary>
   [CodeGenerationIgnore]
   public async Task<IReadOnlyList<ConversionFormat>?> GetFormats()
   {
       if (CoreJsModule is null)
       {
           return Formats;
       }
        
       try 
       {
           JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
               "getJsComponent", CancellationTokenSource.Token, Id);
       }
       catch (JSException)
       {
           // this is expected if the component is not yet built
       }
        
       if (JsComponentReference is null)
       {
           return Formats;
       }

       IReadOnlyList<ConversionFormat>? result = await JsComponentReference.InvokeAsync<IReadOnlyList<ConversionFormat>?>(
           "getFormats", CancellationTokenSource.Token);
        
       if (result is not null)
       {
#pragma warning disable BL0005
           Formats = result;
#pragma warning restore BL0005
           ModifiedParameters[nameof(Formats)] = Formats;
       }
         
       return Formats;
   }
   
   /// <summary>
   ///    Asynchronously set the value of the Formats property after render.
   /// </summary>
   /// <param name="value">
   ///     The value to set.
   /// </param>
   [CodeGenerationIgnore]
   public async Task SetFormats(IReadOnlyList<ConversionFormat>? value)
   {
       if (value is not null)
       {
           foreach (ConversionFormat item in value)
           {
               item.UpdateGeoBlazorReferences(CoreJsModule!, ProJsModule, View, this, Layer);
           }
       }
        
#pragma warning disable BL0005
       Formats = value;
#pragma warning restore BL0005
       ModifiedParameters[nameof(Formats)] = value;
        
       if (CoreJsModule is null)
       {
           return;
       }
    
       try 
       {
           JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
               "getJsComponent", CancellationTokenSource.Token, Id);
       }
       catch (JSException)
       {
           // this is expected if the component is not yet built
       }
    
       if (JsComponentReference is null)
       {
           return;
       }
        
       await JsComponentReference.InvokeVoidAsync("setFormats", 
           CancellationTokenSource.Token, value);
   }
   
   /// <summary>
   ///     Asynchronously adds elements to the Formats property.
   /// </summary>
   /// <param name="values">
   ///    The elements to add.
   /// </param>
   [CodeGenerationIgnore]
   public async Task AddToFormats(params ConversionFormat[] values)
   {
       ConversionFormat[] join = Formats is null
           ? values
           : [..Formats, ..values];
       await SetFormats(join);
   }
   
   
   /// <summary>
   ///     Asynchronously remove an element from the Formats property.
   /// </summary>
   /// <param name="values">
   ///    The elements to remove.
   /// </param>
   [CodeGenerationIgnore]
   public async Task RemoveFromFormats(params ConversionFormat[] values)
   {
       if (Formats is null)
       {
           return;
       }
       await SetFormats(Formats.Except(values).ToArray());
   }

   /// <inheritdoc />
   public override async Task RegisterChildComponent(MapComponent child)
   {
       switch (child)
       {
           case ConversionFormat formats:
               Formats ??= [];
               if (!Formats.Contains(formats))
               {
                   Formats = [..Formats, formats];
                   ModifiedParameters[nameof(Formats)] = Formats;
                   if (MapRendered)
                   {
                       await UpdateWidget();
                   }
               }

               break;
           default:
               await base.RegisterChildComponent(child);
               break;
       }
   }

   /// <inheritdoc />
   public override async Task UnregisterChildComponent(MapComponent child)
   {
       switch (child)
       {
           case ConversionFormat formats:
               Formats = Formats?.Where(f => f != formats).ToList();
               ModifiedParameters[nameof(Formats)] = Formats;

               break;
          default:
              await base.UnregisterChildComponent(child);

              break;
       }
   }

   /// <inheritdoc />
   public override void ValidateRequiredChildren()
   {
       if (Formats is not null)
       {
           foreach (ConversionFormat child in Formats)
           {
               child.ValidateRequiredChildren();
           }
       }
       base.ValidateRequiredChildren();
   }
}