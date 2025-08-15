
export async function buildJsSizeStop(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildJsSizeStopGenerated(dotNetObject, viewId);
}     

export async function buildDotNetSizeStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildDotNetSizeStopGenerated(jsObject, viewId);
}
