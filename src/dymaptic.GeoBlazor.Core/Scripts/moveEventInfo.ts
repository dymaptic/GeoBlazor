
export async function buildJsMoveEventInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMoveEventInfoGenerated } = await import('./moveEventInfo.gb');
    return await buildJsMoveEventInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMoveEventInfo(jsObject: any): Promise<any> {
    let { buildDotNetMoveEventInfoGenerated } = await import('./moveEventInfo.gb');
    return await buildDotNetMoveEventInfoGenerated(jsObject);
}
