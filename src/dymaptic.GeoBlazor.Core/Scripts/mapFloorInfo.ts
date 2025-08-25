
export async function buildJsMapFloorInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapFloorInfoGenerated } = await import('./mapFloorInfo.gb');
    return await buildJsMapFloorInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapFloorInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMapFloorInfoGenerated } = await import('./mapFloorInfo.gb');
    return await buildDotNetMapFloorInfoGenerated(jsObject, viewId);
}
