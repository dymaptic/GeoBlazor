export async function buildJsWFSLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsWFSLayerInfoGenerated} = await import('./wFSLayerInfo.gb');
    return await buildJsWFSLayerInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetWFSLayerInfo(jsObject: any): Promise<any> {
    let {buildDotNetWFSLayerInfoGenerated} = await import('./wFSLayerInfo.gb');
    return await buildDotNetWFSLayerInfoGenerated(jsObject);
}
