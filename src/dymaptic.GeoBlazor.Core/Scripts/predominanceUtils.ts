
export async function buildJsPredominanceUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceUtilsGenerated } = await import('./predominanceUtils.gb');
    return await buildJsPredominanceUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominanceUtils(jsObject: any): Promise<any> {
    let { buildDotNetPredominanceUtilsGenerated } = await import('./predominanceUtils.gb');
    return await buildDotNetPredominanceUtilsGenerated(jsObject);
}
