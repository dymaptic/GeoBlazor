
export async function buildJsCIMMarkerPlacementAtMeasuredUnits(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCIMMarkerPlacementAtMeasuredUnitsGenerated } = await import('./cIMMarkerPlacementAtMeasuredUnits.gb');
    return await buildJsCIMMarkerPlacementAtMeasuredUnitsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCIMMarkerPlacementAtMeasuredUnits(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerPlacementAtMeasuredUnitsGenerated } = await import('./cIMMarkerPlacementAtMeasuredUnits.gb');
    return await buildDotNetCIMMarkerPlacementAtMeasuredUnitsGenerated(jsObject);
}
