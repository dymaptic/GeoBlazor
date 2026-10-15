namespace dymaptic.GeoBlazor.Pro.Components.Layers;

[Experimental("GeoBlazor_Untested", UrlFormat = "https://docs.geoblazor.com/pages/untested.html")]
public partial class CatalogLayer
{
   // Add custom code to this file to override generated code
       /// <summary>
    ///     Applies edits to features in a layer. New features can be created and existing features can be updated or deleted. Feature geometries and/or attributes may be modified. Only applicable to layers in a feature service and client-side features set through the FeatureLayer's source property. Attachments can also be added, updated or deleted.
    ///     If client-side features are added, removed or updated at runtime using applyEdits() then use FeatureLayer's queryFeatures() method to return updated features.
    /// </summary>
        [CodeGenerationIgnore]
        public async Task<FeatureEditsResult> ApplyEdits(FeatureEdits edits, FeatureEditOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Verify that the layer is loaded. Layers with no graphics are not rendered and therefore not loaded
        // as far as GeoBlazor is concerned
        if (CoreJsModule is not null && JsComponentReference is null)
        {
            await Load(cancellationToken);
        }
        
        FeatureEditsResult emptyResult = new FeatureEditsResult([], 
            [],
            [],
            [],
            [],
            [],
            [],
            null);

        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            return emptyResult;
        }

        Graphic[] addedFeatures = edits.AddFeatures?.ToArray() ?? [];
        Graphic[] updatedFeatures = edits.UpdateFeatures?.ToArray() ?? [];
        Graphic[] deletedFeatures = edits.DeleteFeatures?.ToArray() ?? [];
        long? editMoment = null;
        int chunkSize = View!.GraphicSerializationChunkSize ?? (View.IsMaui ? 100 : 200);
        AbortManager ??= new AbortManager(CoreJsModule!);
        
        // return await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyEdits", edits, options,
        //     View!.Id);
        FeatureEditsResult? addFeatureResults = null;
        FeatureEditsResult? updateFeatureResults = null;
        FeatureEditsResult? deleteFeatureResults = null;
        List<EditedFeatureResult> editedFeatureResults = [];
        IJSObjectReference abortSignal = await AbortManager!.CreateAbortSignal(cancellationToken);
        for (var index = 0; index < addedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            addFeatureResults = 
                await SendEdits(addedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "add", 
                    options, addFeatureResults, abortSignal, cancellationToken);
            editMoment ??= addFeatureResults?.EditMoment;
        }
        for (var index = 0; index < updatedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            updateFeatureResults = 
                await SendEdits(updatedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "update", 
                    options, updateFeatureResults, abortSignal, cancellationToken);
            editMoment ??= updateFeatureResults?.EditMoment;
        }
        for (var index = 0; index < deletedFeatures.Length; index += chunkSize)
        {
            int skip = index;

            deleteFeatureResults = 
                await SendEdits(deletedFeatures.Skip(skip).Take(chunkSize)
                        .Select(g => g.ToSerializationRecord(true)).ToArray(), "delete", 
                    options, deleteFeatureResults, abortSignal, cancellationToken);
            editMoment ??= deleteFeatureResults?.EditMoment;
        }
        
        if (addFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(addFeatureResults.EditedFeatureResults);
        }
        if (updateFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(updateFeatureResults.EditedFeatureResults);
        }
        if (deleteFeatureResults?.EditedFeatureResults is not null)
        {
            editedFeatureResults.AddRange(deleteFeatureResults.EditedFeatureResults);
        }

        FeatureEditsResult? attachmentResults = null;
        if (edits.AddAttachments?.Any() == true ||
            edits.UpdateAttachments?.Any() == true ||
            edits.DeleteAttachments?.Any() == true)
        {
            FeatureEdits attachmentEdits = new()
            {
                AddAttachments = edits.AddAttachments,
                UpdateAttachments = edits.UpdateAttachments,
                DeleteAttachments = edits.DeleteAttachments
            };
            attachmentResults = await JsComponentReference!.InvokeAsync<FeatureEditsResult>(
                "applyAttachmentEdits", cancellationToken, attachmentEdits, options, View!.Id,
                abortSignal);
            editMoment ??= attachmentResults.EditMoment;
            if (attachmentResults.EditedFeatureResults is not null)
            {
                editedFeatureResults.AddRange(attachmentResults.EditedFeatureResults);
            }
        }

        return new FeatureEditsResult
        (
            addFeatureResults?.AddFeatureResults ?? [], 
            updateFeatureResults?.UpdateFeatureResults ?? [], 
            deleteFeatureResults?.DeleteFeatureResults ?? [], 
            attachmentResults?.AddAttachmentResults ?? [],
            attachmentResults?.UpdateAttachmentResults ?? [],
            attachmentResults?.DeleteAttachmentResults ?? [],
            editedFeatureResults.ToArray(),
            editMoment
        );
    }
       
    /// <summary>
    /// Returns the Domain associated with the given field name. The domain can be either a CodedValueDomain or RangeDomain.
    /// </summary>
    [CodeGenerationIgnore]
    public async Task<Domain?> GetFieldDomain(string fieldName, Graphic? feature = null)
    {
        return await JsComponentReference!.InvokeAsync<Domain?>("getFieldDomain", fieldName, feature);
    }

    private async Task<FeatureEditsResult?> SendEdits(GraphicSerializationRecord[] graphics, 
        string editType, FeatureEditOptions? options, FeatureEditsResult? currentResults, 
        IJSObjectReference abortSignal, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            return null;
        }
        
        ProtoGraphicCollection collection = new(graphics);
        MemoryStream ms = new();
        Serializer.Serialize(ms, collection);

        if (cancellationToken.IsCancellationRequested ||
            CancellationTokenSource.Token.IsCancellationRequested)
        {
            await ms.DisposeAsync();
            return null;
        }
        
        ms.Seek(0, SeekOrigin.Begin);

        FeatureEditsResult result;

        try
        {
            if (View!.IsWebAssembly)
            {
                result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyGraphicEditsSynchronously",
                    cancellationToken, ms.ToArray(), editType, options,
                    View!.Id, abortSignal);
                await ms.DisposeAsync();
                await Task.Delay(1, cancellationToken);
            }
            else
            {
                using DotNetStreamReference streamRef = new(ms);

                result = await JsComponentReference!.InvokeAsync<FeatureEditsResult>("applyGraphicEditsFromStream",
                    cancellationToken, streamRef, editType, options,
                    View!.Id, abortSignal);
            }
            
            return result.Concat(currentResults);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return null;
    }
}