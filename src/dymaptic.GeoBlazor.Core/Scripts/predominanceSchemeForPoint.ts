
export async function buildJsPredominanceSchemeForPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPredominanceSchemeForPointGenerated } = await import('./predominanceSchemeForPoint.gb');
    return await buildJsPredominanceSchemeForPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPredominanceSchemeForPoint(jsObject: any): Promise<any> {
    let { buildDotNetPredominanceSchemeForPointGenerated } = await import('./predominanceSchemeForPoint.gb');
    return await buildDotNetPredominanceSchemeForPointGenerated(jsObject);
}
