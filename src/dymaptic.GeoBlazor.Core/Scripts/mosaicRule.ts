// override generated code in this file

export async function buildJsMosaicRule(dotNetObject: any): Promise<any> {
    let {buildJsMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildJsMosaicRuleGenerated(dotNetObject);
}

export async function buildDotNetMosaicRule(jsObject: any): Promise<any> {
    let {buildDotNetMosaicRuleGenerated} = await import('./mosaicRule.gb');
    return await buildDotNetMosaicRuleGenerated(jsObject);
}
