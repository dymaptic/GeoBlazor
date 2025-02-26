
export async function buildJsFeatureSet(dotNetObject: any): Promise<any> {
    let { buildJsFeatureSetGenerated } = await import('./featureSet.gb');
    return await buildJsFeatureSetGenerated(dotNetObject);
}     

export async function buildDotNetFeatureSet(jsObject: any): Promise<any> {
    let { buildDotNetFeatureSetGenerated } = await import('./featureSet.gb');
    return await buildDotNetFeatureSetGenerated(jsObject);
}
