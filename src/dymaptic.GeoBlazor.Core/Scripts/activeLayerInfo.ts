export async function buildJsActiveLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsActiveLayerInfoGenerated} = await import('./activeLayerInfo.gb');
    return await buildJsActiveLayerInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetActiveLayerInfo(jsObject: any): Promise<any> {
    let {buildDotNetActiveLayerInfoGenerated} = await import('./activeLayerInfo.gb');
    return await buildDotNetActiveLayerInfoGenerated(jsObject);
}
