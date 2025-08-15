
export async function buildJsColorStop(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsColorStopGenerated } = await import('./colorStop.gb');
    return await buildJsColorStopGenerated(dotNetObject, viewId);
}     

export async function buildDotNetColorStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetColorStopGenerated } = await import('./colorStop.gb');
    return await buildDotNetColorStopGenerated(jsObject, viewId);
}
