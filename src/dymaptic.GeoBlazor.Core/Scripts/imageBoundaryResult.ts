export async function buildJsImageBoundaryResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageBoundaryResultGenerated} = await import('./imageBoundaryResult.gb');
    return await buildJsImageBoundaryResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageBoundaryResult(jsObject: any): Promise<any> {
    let {buildDotNetImageBoundaryResultGenerated} = await import('./imageBoundaryResult.gb');
    return await buildDotNetImageBoundaryResultGenerated(jsObject);
}
