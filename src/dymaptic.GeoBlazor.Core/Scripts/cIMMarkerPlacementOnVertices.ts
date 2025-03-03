
export async function buildJsCIMMarkerPlacementOnVertices(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementOnVerticesGenerated } = await import('./cIMMarkerPlacementOnVertices.gb');
    return await buildJsCIMMarkerPlacementOnVerticesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementOnVertices(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementOnVerticesGenerated } = await import('./cIMMarkerPlacementOnVertices.gb');
    return await buildDotNetCIMMarkerPlacementOnVerticesGenerated(jsObject);
}
