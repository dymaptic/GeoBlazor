
export async function buildJsGroupLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsGroupLayerSaveAsOptionsGenerated } = await import('./groupLayerSaveAsOptions.gb');
    return await buildJsGroupLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetGroupLayerSaveAsOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetGroupLayerSaveAsOptionsGenerated } = await import('./groupLayerSaveAsOptions.gb');
    return await buildDotNetGroupLayerSaveAsOptionsGenerated(jsObject, layerId, viewId);
}
