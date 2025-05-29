
export async function buildJsLabelExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLabelExpressionInfoGenerated } = await import('./labelExpressionInfo.gb');
    return await buildJsLabelExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLabelExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetLabelExpressionInfoGenerated } = await import('./labelExpressionInfo.gb');
    return await buildDotNetLabelExpressionInfoGenerated(jsObject);
}
