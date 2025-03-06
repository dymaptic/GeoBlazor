export async function buildJsImageGPSInfoResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsImageGPSInfoResultGenerated} = await import('./imageGPSInfoResult.gb');
    return await buildJsImageGPSInfoResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetImageGPSInfoResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetImageGPSInfoResultGenerated} = await import('./imageGPSInfoResult.gb');
    return await buildDotNetImageGPSInfoResultGenerated(jsObject, layerId, viewId);
}
