export async function buildJsClassBreaksClassBreaksParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsClassBreaksClassBreaksParamsGenerated } = await import('./classBreaksClassBreaksParams.gb');
    return await buildJsClassBreaksClassBreaksParamsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetClassBreaksClassBreaksParams(jsObject: any): Promise<any> {
    let { buildDotNetClassBreaksClassBreaksParamsGenerated } = await import('./classBreaksClassBreaksParams.gb');
    return await buildDotNetClassBreaksClassBreaksParamsGenerated(jsObject);
}
