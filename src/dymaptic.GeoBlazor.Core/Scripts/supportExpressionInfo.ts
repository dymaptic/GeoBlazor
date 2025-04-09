
export async function buildJsSupportExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSupportExpressionInfoGenerated } = await import('./supportExpressionInfo.gb');
    return await buildJsSupportExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSupportExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetSupportExpressionInfoGenerated } = await import('./supportExpressionInfo.gb');
    return await buildDotNetSupportExpressionInfoGenerated(jsObject);
}
