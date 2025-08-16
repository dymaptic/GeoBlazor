
export async function buildJsColorStop(dotNetObject: any): Promise<any> {
    let { buildJsColorStopGenerated } = await import('./colorStop.gb');
    return await buildJsColorStopGenerated(dotNetObject);
}     

export async function buildDotNetColorStop(jsObject: any): Promise<any> {
    let { buildDotNetColorStopGenerated } = await import('./colorStop.gb');
    return await buildDotNetColorStopGenerated(jsObject);
}
