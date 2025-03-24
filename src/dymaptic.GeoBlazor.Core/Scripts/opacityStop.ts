
export async function buildJsOpacityStop(dotNetObject: any): Promise<any> {
    let { buildJsOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildJsOpacityStopGenerated(dotNetObject);
}     

export async function buildDotNetOpacityStop(jsObject: any): Promise<any> {
    let { buildDotNetOpacityStopGenerated } = await import('./opacityStop.gb');
    return await buildDotNetOpacityStopGenerated(jsObject);
}
