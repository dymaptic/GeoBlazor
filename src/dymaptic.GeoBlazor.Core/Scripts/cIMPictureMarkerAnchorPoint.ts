
export async function buildJsCIMPictureMarkerAnchorPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMPictureMarkerAnchorPointGenerated } = await import('./cIMPictureMarkerAnchorPoint.gb');
    return await buildJsCIMPictureMarkerAnchorPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMPictureMarkerAnchorPoint(jsObject: any): Promise<any> {
    let { buildDotNetCIMPictureMarkerAnchorPointGenerated } = await import('./cIMPictureMarkerAnchorPoint.gb');
    return await buildDotNetCIMPictureMarkerAnchorPointGenerated(jsObject);
}
