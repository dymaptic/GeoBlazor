export async function buildJsRouteSolveResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRouteSolveResultGenerated} = await import('./routeSolveResult.gb');
    return await buildJsRouteSolveResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRouteSolveResult(jsObject: any): Promise<any> {
    let {buildDotNetRouteSolveResultGenerated} = await import('./routeSolveResult.gb');
    return await buildDotNetRouteSolveResultGenerated(jsObject);
}
