namespace dymaptic.GeoBlazor.Pro.Components.Symbols;

public partial class WebStyleSymbol
{
   // Add custom code to this file to override generated code
   
#region Public Methods

   // /// <summary>
   // ///     <a target="_blank" href="https://docs.geoblazor.com/pages/classes/dymaptic.GeoBlazor.Pro.Components.Symbols.WebStyleSymbol.html#webstylesymbolfetchsymbol-method">GeoBlazor Docs</a>
   // ///     Resolves and returns the symbol instance the WebStyleSymbol refers to.
   // ///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-symbols-WebStyleSymbol.html#fetchSymbol">ArcGIS Maps SDK for JavaScript</a>
   // /// </summary>
   // /// <param name="options">
   // ///     An object with the following properties.
   // /// </param>
   // /// <param name="cancellationToken">
   // ///     The CancellationToken to cancel an asynchronous operation.
   // /// </param>
   // TODO: When we have CIMSymbol implemented, uncomment this method
   // [ArcGISMethod]
   // [CodeGenerationIgnore]
   // public async Task<Symbol?> FetchSymbol(WebStyleSymbolFetchSymbolOptions? options = null,
   //     CancellationToken cancellationToken = default)
   // {
   //     if (ProJsModule is null || CoreJsModule is null)
   //     {
   //         return null;
   //     }
   //      
   //     try 
   //     {
   //         JsComponentReference ??= await CoreJsModule.InvokeAsync<IJSObjectReference?>(
   //             "getJsComponent", CancellationTokenSource.Token, Id);
   //     }
   //     catch (JSException)
   //     {
   //         // this is expected if the component is not yet built
   //     }
   //      
   //     if (JsComponentReference is null)
   //     {
   //         return null;
   //     }
   //      
   //     IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
   //     Symbol? result = await ProJsModule.InvokeAsync<Symbol?>(
   //         "fetchSymbolFromWebStyleSymbol", 
   //         CancellationTokenSource.Token, Id, ViewId,
   //         new { acceptedFormats = options?.AcceptedFormats, signal = abortSignal });
   //              
   //     await AbortManager.DisposeAbortController(cancellationToken);
   //      
   //     return result;
   // }
    
#endregion

   internal override SymbolSerializationRecord ToSerializationRecord()
   {
        return new SymbolSerializationRecord(Id.ToString(), Type.ToString().ToKebabCase(), Color)
        {
            Name = Name,
            PortalUrl = Portal?.Url,
            StyleName = StyleName,
            StyleUrl = StyleUrl
        };
   }
}
