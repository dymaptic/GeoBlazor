
export async function buildJsProximityOperatorProximityResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsProximityOperatorProximityResultGenerated } = await import('./proximityOperatorProximityResult.gb');
    return await buildJsProximityOperatorProximityResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetProximityOperatorProximityResult(jsObject: any): Promise<any> {
    let { buildDotNetProximityOperatorProximityResultGenerated } = await import('./proximityOperatorProximityResult.gb');
    return await buildDotNetProximityOperatorProximityResultGenerated(jsObject);
}
