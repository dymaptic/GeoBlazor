
export async function buildJsLevelLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLevelLayerInfoGenerated } = await import('./levelLayerInfo.gb');
    return await buildJsLevelLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLevelLayerInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetLevelLayerInfoGenerated } = await import('./levelLayerInfo.gb');
    return await buildDotNetLevelLayerInfoGenerated(jsObject, viewId);
}
