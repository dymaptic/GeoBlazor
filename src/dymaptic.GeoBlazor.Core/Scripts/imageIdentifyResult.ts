export async function buildJsImageIdentifyResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsImageIdentifyResultGenerated } = await import('./imageIdentifyResult.gb');
    return await buildJsImageIdentifyResultGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetImageIdentifyResult(jsObject: any): Promise<any> {
    let { buildDotNetImageIdentifyResultGenerated } = await import('./imageIdentifyResult.gb');
    return await buildDotNetImageIdentifyResultGenerated(jsObject);
}
