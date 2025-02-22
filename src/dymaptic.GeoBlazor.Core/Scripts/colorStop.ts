
export async function buildJsColorStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorStopGenerated } = await import('./colorStop.gb');
    return await buildJsColorStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorStop(jsObject: any): Promise<any> {
    let { buildDotNetColorStopGenerated } = await import('./colorStop.gb');
    return await buildDotNetColorStopGenerated(jsObject);
}
