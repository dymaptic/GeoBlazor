
export async function buildJsCIMMarkerFillPlacement(dotNetObject: any): Promise<any> {
    let { buildJsCIMMarkerFillPlacementGenerated } = await import('./cIMMarkerFillPlacement.gb');
    return await buildJsCIMMarkerFillPlacementGenerated(dotNetObject);
}     

export async function buildDotNetCIMMarkerFillPlacement(jsObject: any): Promise<any> {
    let { buildDotNetCIMMarkerFillPlacementGenerated } = await import('./cIMMarkerFillPlacement.gb');
    return await buildDotNetCIMMarkerFillPlacementGenerated(jsObject);
}
