// override generated code in this file

export async function buildJsMosaicRule(dotNetObject: any, viewId: string | null): Promise<any> {
    let {buildJsMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildJsMosaicRuleGenerated(dotNetObject, viewId);
}

export async function buildDotNetMosaicRule(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildDotNetMosaicRuleGenerated(jsObject, viewId);
}
