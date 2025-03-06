export async function buildJsNearestPointResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsNearestPointResultGenerated} = await import('./nearestPointResult.gb');
    return await buildJsNearestPointResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetNearestPointResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetNearestPointResultGenerated} = await import('./nearestPointResult.gb');
    return await buildDotNetNearestPointResultGenerated(jsObject, layerId, viewId);
}
