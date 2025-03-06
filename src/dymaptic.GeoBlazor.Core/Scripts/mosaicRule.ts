// override generated code in this file

export async function buildJsMosaicRule(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildJsMosaicRuleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetMosaicRule(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildDotNetMosaicRuleGenerated(jsObject, layerId, viewId);
}
