
export async function buildJsCoordinateSegment(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCoordinateSegmentGenerated } = await import('./coordinateSegment.gb');
    return await buildJsCoordinateSegmentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCoordinateSegment(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCoordinateSegmentGenerated } = await import('./coordinateSegment.gb');
    return await buildDotNetCoordinateSegmentGenerated(jsObject, layerId, viewId);
}
