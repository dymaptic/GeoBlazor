
export async function buildJsOpacityStop(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildJsOpacityStopGenerated(dotNetObject, viewId);
}     

export async function buildDotNetOpacityStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildDotNetOpacityStopGenerated(jsObject, viewId);
}
