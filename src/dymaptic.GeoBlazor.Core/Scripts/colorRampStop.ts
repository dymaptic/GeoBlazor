export async function buildJsColorRampStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorRampStopGenerated} = await import('./colorRampStop.gb');
    return await buildJsColorRampStopGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorRampStop(jsObject: any): Promise<any> {
    let {buildDotNetColorRampStopGenerated} = await import('./colorRampStop.gb');
    return await buildDotNetColorRampStopGenerated(jsObject);
}
