
export async function buildJsWCSLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWCSLayerSaveAsOptionsGenerated } = await import('./wCSLayerSaveAsOptions.gb');
    return await buildJsWCSLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWCSLayerSaveAsOptions(jsObject: any): Promise<any> {
    let { buildDotNetWCSLayerSaveAsOptionsGenerated } = await import('./wCSLayerSaveAsOptions.gb');
    return await buildDotNetWCSLayerSaveAsOptionsGenerated(jsObject);
}
