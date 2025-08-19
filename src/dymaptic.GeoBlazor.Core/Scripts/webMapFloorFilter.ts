
export async function buildJsWebMapFloorFilter(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapFloorFilterGenerated } = await import('./webMapFloorFilter.gb');
    return await buildJsWebMapFloorFilterGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebMapFloorFilter(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebMapFloorFilterGenerated } = await import('./webMapFloorFilter.gb');
    return await buildDotNetWebMapFloorFilterGenerated(jsObject, viewId);
}
