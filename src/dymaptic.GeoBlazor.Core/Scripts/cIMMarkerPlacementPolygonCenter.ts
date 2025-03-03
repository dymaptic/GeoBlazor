
export async function buildJsCIMMarkerPlacementPolygonCenter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementPolygonCenterGenerated } = await import('./cIMMarkerPlacementPolygonCenter.gb');
    return await buildJsCIMMarkerPlacementPolygonCenterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementPolygonCenter(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementPolygonCenterGenerated } = await import('./cIMMarkerPlacementPolygonCenter.gb');
    return await buildDotNetCIMMarkerPlacementPolygonCenterGenerated(jsObject);
}
