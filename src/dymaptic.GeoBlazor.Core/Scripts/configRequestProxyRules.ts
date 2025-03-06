
export async function buildJsConfigRequestProxyRules(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConfigRequestProxyRulesGenerated } = await import('./configRequestProxyRules.gb');
    return await buildJsConfigRequestProxyRulesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConfigRequestProxyRules(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConfigRequestProxyRulesGenerated } = await import('./configRequestProxyRules.gb');
    return await buildDotNetConfigRequestProxyRulesGenerated(jsObject, layerId, viewId);
}
