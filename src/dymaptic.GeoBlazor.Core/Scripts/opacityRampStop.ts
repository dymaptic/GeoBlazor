export async function buildJsOpacityRampStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsOpacityRampStopGenerated} = await import('./opacityRampStop.gb');
    return await buildJsOpacityRampStopGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetOpacityRampStop(jsObject: any): Promise<any> {
    let {buildDotNetOpacityRampStopGenerated} = await import('./opacityRampStop.gb');
    return await buildDotNetOpacityRampStopGenerated(jsObject);
}
