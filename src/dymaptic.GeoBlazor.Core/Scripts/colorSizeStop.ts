export async function buildJsColorSizeStop(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorSizeStopGenerated} = await import('./colorSizeStop.gb');
    return await buildJsColorSizeStopGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorSizeStop(jsObject: any): Promise<any> {
    let {buildDotNetColorSizeStopGenerated} = await import('./colorSizeStop.gb');
    return await buildDotNetColorSizeStopGenerated(jsObject);
}
