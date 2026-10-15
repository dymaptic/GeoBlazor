
export async function buildJsIdentifyResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIdentifyResultGenerated } = await import('./identifyResult.gb');
    return await buildJsIdentifyResultGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIdentifyResult(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetIdentifyResultGenerated } = await import('./identifyResult.gb');
    return await buildDotNetIdentifyResultGenerated(jsObject, layerId, viewId);
}
