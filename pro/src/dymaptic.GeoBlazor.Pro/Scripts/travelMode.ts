
export async function buildJsTravelMode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTravelModeGenerated } = await import('./travelMode.gb');
    return await buildJsTravelModeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTravelMode(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTravelModeGenerated } = await import('./travelMode.gb');
    return await buildDotNetTravelModeGenerated(jsObject, layerId, viewId);
}
