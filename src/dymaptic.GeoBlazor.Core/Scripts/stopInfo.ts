
export async function buildJsStopInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsStopInfoGenerated } = await import('./stopInfo.gb');
    return await buildJsStopInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetStopInfo(jsObject: any): Promise<any> {
    let { buildDotNetStopInfoGenerated } = await import('./stopInfo.gb');
    return await buildDotNetStopInfoGenerated(jsObject);
}
