
export async function buildJsCIMMarkerPlacementOnLine(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementOnLineGenerated } = await import('./cIMMarkerPlacementOnLine.gb');
    return await buildJsCIMMarkerPlacementOnLineGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementOnLine(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementOnLineGenerated } = await import('./cIMMarkerPlacementOnLine.gb');
    return await buildDotNetCIMMarkerPlacementOnLineGenerated(jsObject);
}
