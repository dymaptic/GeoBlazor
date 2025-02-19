export async function buildJsMediaLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMediaLayerSaveAsOptionsGenerated } = await import('./mediaLayerSaveAsOptions.gb');
    return await buildJsMediaLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMediaLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetMediaLayerSaveAsOptionsGenerated } = await import('./mediaLayerSaveAsOptions.gb');
    return await buildDotNetMediaLayerSaveAsOptionsGenerated(jsObject);
}
