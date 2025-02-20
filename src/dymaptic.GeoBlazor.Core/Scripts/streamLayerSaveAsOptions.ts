export async function buildJsStreamLayerSaveAsOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsStreamLayerSaveAsOptionsGenerated} = await import('./streamLayerSaveAsOptions.gb');
    return await buildJsStreamLayerSaveAsOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetStreamLayerSaveAsOptions(jsObject: any): Promise<any> {
    let {buildDotNetStreamLayerSaveAsOptionsGenerated} = await import('./streamLayerSaveAsOptions.gb');
    return await buildDotNetStreamLayerSaveAsOptionsGenerated(jsObject);
}
