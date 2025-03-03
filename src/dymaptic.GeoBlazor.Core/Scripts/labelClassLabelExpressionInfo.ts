
export async function buildJsLabelClassLabelExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLabelClassLabelExpressionInfoGenerated } = await import('./labelClassLabelExpressionInfo.gb');
    return await buildJsLabelClassLabelExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLabelClassLabelExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetLabelClassLabelExpressionInfoGenerated } = await import('./labelClassLabelExpressionInfo.gb');
    return await buildDotNetLabelClassLabelExpressionInfoGenerated(jsObject);
}
