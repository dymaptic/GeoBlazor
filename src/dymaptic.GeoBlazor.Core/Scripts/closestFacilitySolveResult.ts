
export async function buildJsClosestFacilitySolveResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClosestFacilitySolveResultGenerated } = await import('./closestFacilitySolveResult.gb');
    return await buildJsClosestFacilitySolveResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetClosestFacilitySolveResult(jsObject: any): Promise<any> {
    let { buildDotNetClosestFacilitySolveResultGenerated } = await import('./closestFacilitySolveResult.gb');
    return await buildDotNetClosestFacilitySolveResultGenerated(jsObject);
}
