export async function buildJsSizeRampStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeRampStopGenerated } = await import('./sizeRampStop.gb');
    return await buildJsSizeRampStopGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetSizeRampStop(jsObject: any): Promise<any> {
    let { buildDotNetSizeRampStopGenerated } = await import('./sizeRampStop.gb');
    return await buildDotNetSizeRampStopGenerated(jsObject);
}
