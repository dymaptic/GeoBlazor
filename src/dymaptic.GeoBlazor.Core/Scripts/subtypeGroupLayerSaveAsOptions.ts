
export async function buildJsSubtypeGroupLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSubtypeGroupLayerSaveAsOptionsGenerated } = await import('./subtypeGroupLayerSaveAsOptions.gb');
    return await buildJsSubtypeGroupLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSubtypeGroupLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetSubtypeGroupLayerSaveAsOptionsGenerated } = await import('./subtypeGroupLayerSaveAsOptions.gb');
    return await buildDotNetSubtypeGroupLayerSaveAsOptionsGenerated(jsObject);
}
