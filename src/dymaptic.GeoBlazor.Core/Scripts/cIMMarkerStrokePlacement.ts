
export async function buildJsCIMMarkerStrokePlacement(dotNetObject: any): Promise<any> {
    let { buildJsCIMMarkerStrokePlacementGenerated } = await import('./cIMMarkerStrokePlacement.gb');
    return await buildJsCIMMarkerStrokePlacementGenerated(dotNetObject);
}     

export async function buildDotNetCIMMarkerStrokePlacement(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerStrokePlacementGenerated } = await import('./cIMMarkerStrokePlacement.gb');
    return await buildDotNetCIMMarkerStrokePlacementGenerated(jsObject);
}
