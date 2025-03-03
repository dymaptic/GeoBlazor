
export async function buildJsOpacityStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildJsOpacityStopGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOpacityStop(jsObject: any): Promise<any> {
    let { buildDotNetOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildDotNetOpacityStopGenerated(jsObject);
}
