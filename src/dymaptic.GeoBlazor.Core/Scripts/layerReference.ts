
export async function buildJsLayerReference(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerReferenceGenerated } = await import('./layerReference.gb');
    return await buildJsLayerReferenceGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerReference(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLayerReferenceGenerated } = await import('./layerReference.gb');
    return await buildDotNetLayerReferenceGenerated(jsObject, viewId);
}
