
export async function buildJsCIMMarkerPlacementInsidePolygon(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementInsidePolygonGenerated } = await import('./cIMMarkerPlacementInsidePolygon.gb');
    return await buildJsCIMMarkerPlacementInsidePolygonGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementInsidePolygon(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementInsidePolygonGenerated } = await import('./cIMMarkerPlacementInsidePolygon.gb');
    return await buildDotNetCIMMarkerPlacementInsidePolygonGenerated(jsObject);
}
