
export async function buildJsProximityResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProximityResultGenerated } = await import('./proximityResult.gb');
    return await buildJsProximityResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProximityResult(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetProximityResultGenerated } = await import('./proximityResult.gb');
    return await buildDotNetProximityResultGenerated(jsObject, viewId);
}
