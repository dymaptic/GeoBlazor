
export async function buildJsCIMVectorMarkerAnchorPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMVectorMarkerAnchorPointGenerated } = await import('./cIMVectorMarkerAnchorPoint.gb');
    return await buildJsCIMVectorMarkerAnchorPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMVectorMarkerAnchorPoint(jsObject: any): Promise<any> {
    let { buildDotNetCIMVectorMarkerAnchorPointGenerated } = await import('./cIMVectorMarkerAnchorPoint.gb');
    return await buildDotNetCIMVectorMarkerAnchorPointGenerated(jsObject);
}
