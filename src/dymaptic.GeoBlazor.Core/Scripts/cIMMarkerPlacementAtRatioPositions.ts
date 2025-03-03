
export async function buildJsCIMMarkerPlacementAtRatioPositions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAtRatioPositionsGenerated } = await import('./cIMMarkerPlacementAtRatioPositions.gb');
    return await buildJsCIMMarkerPlacementAtRatioPositionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAtRatioPositions(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAtRatioPositionsGenerated } = await import('./cIMMarkerPlacementAtRatioPositions.gb');
    return await buildDotNetCIMMarkerPlacementAtRatioPositionsGenerated(jsObject);
}
