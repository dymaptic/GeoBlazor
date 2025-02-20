export async function buildJsColormapInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColormapInfoGenerated} = await import('./colormapInfo.gb');
    return await buildJsColormapInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColormapInfo(jsObject: any): Promise<any> {
    let {buildDotNetColormapInfoGenerated} = await import('./colormapInfo.gb');
    return await buildDotNetColormapInfoGenerated(jsObject);
}
