
export async function buildJsCSVLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCSVLayerInfoGenerated } = await import('./cSVLayerInfo.gb');
    return await buildJsCSVLayerInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCSVLayerInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetCSVLayerInfoGenerated } = await import('./cSVLayerInfo.gb');
    return await buildDotNetCSVLayerInfoGenerated(jsObject, viewId);
}
