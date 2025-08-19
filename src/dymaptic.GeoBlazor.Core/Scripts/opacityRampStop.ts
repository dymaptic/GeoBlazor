
export async function buildJsOpacityRampStop(dotNetObject: any): Promise<any> {
    let { buildJsOpacityRampStopGenerated } = await import('./opacityRampStop.gb');
    return await buildJsOpacityRampStopGenerated(dotNetObject);
}     

export async function buildDotNetOpacityRampStop(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetOpacityRampStopGenerated } = await import('./opacityRampStop.gb');
    return await buildDotNetOpacityRampStopGenerated(jsObject, viewId);
}
