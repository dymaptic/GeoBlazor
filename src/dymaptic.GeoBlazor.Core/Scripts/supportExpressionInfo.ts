
export async function buildJsSupportExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsSupportExpressionInfoGenerated } = await import('./supportExpressionInfo.gb');
    return await buildJsSupportExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetSupportExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetSupportExpressionInfoGenerated } = await import('./supportExpressionInfo.gb');
    return await buildDotNetSupportExpressionInfoGenerated(jsObject);
}
