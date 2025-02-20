export async function buildJsCIMVectorMarker(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCIMVectorMarkerGenerated} = await import('./cIMVectorMarker.gb');
    return await buildJsCIMVectorMarkerGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCIMVectorMarker(jsObject: any): Promise<any> {
    let {buildDotNetCIMVectorMarkerGenerated} = await import('./cIMVectorMarker.gb');
    return await buildDotNetCIMVectorMarkerGenerated(jsObject);
}
