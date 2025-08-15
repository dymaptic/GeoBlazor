
export async function buildJsIBlendLayer(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildJsIBlendLayerGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIBlendLayer(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIBlendLayerGenerated } = await import('./iBlendLayer.gb');
    return await buildDotNetIBlendLayerGenerated(jsObject, viewId);
}
