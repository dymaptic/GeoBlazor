
export async function buildJsServiceAreaSolveResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceAreaSolveResultGenerated } = await import('./serviceAreaSolveResult.gb');
    return await buildJsServiceAreaSolveResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceAreaSolveResult(jsObject: any): Promise<any> {
    let { buildDotNetServiceAreaSolveResultGenerated } = await import('./serviceAreaSolveResult.gb');
    return await buildDotNetServiceAreaSolveResultGenerated(jsObject);
}
