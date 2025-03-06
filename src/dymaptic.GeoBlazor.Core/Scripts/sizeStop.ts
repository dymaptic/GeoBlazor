
export async function buildJsSizeStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildJsSizeStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeStop(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSizeStopGenerated } = await import('./sizeStop.gb');
    return await buildDotNetSizeStopGenerated(jsObject, layerId, viewId);
}
