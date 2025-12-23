
export async function buildJsFeatureExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsFeatureExpressionInfoGenerated } = await import('./featureExpressionInfo.gb');
    return await buildJsFeatureExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetFeatureExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetFeatureExpressionInfoGenerated } = await import('./featureExpressionInfo.gb');
    return await buildDotNetFeatureExpressionInfoGenerated(jsObject);
}
