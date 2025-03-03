
export async function buildJsIMarkerPlacement(dotNetObject: any): Promise<any> {
    let { buildJsIMarkerPlacementGenerated } = await import('./iMarkerPlacement.gb');
    return await buildJsIMarkerPlacementGenerated(dotNetObject);
}     

export async function buildDotNetIMarkerPlacement(jsObject: any): Promise<any> {
    let { buildDotNetIMarkerPlacementGenerated } = await import('./iMarkerPlacement.gb');
    return await buildDotNetIMarkerPlacementGenerated(jsObject);
}
