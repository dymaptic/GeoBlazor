export async function buildJsRasterIdentifyResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterIdentifyResultGenerated} = await import('./rasterIdentifyResult.gb');
    return await buildJsRasterIdentifyResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterIdentifyResult(jsObject: any): Promise<any> {
    let {buildDotNetRasterIdentifyResultGenerated} = await import('./rasterIdentifyResult.gb');
    return await buildDotNetRasterIdentifyResultGenerated(jsObject);
}
