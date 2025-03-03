
export async function buildJsSupportJsonUtils(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportJsonUtilsGenerated } = await import('./supportJsonUtils.gb');
    return await buildJsSupportJsonUtilsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportJsonUtils(jsObject: any): Promise<any> {
    let { buildDotNetSupportJsonUtilsGenerated } = await import('./supportJsonUtils.gb');
    return await buildDotNetSupportJsonUtilsGenerated(jsObject);
}
