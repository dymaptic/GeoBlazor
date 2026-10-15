
export async function buildJsFormTemplateExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFormTemplateExpressionInfoGenerated } = await import('./formTemplateExpressionInfo.gb');
    return await buildJsFormTemplateExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFormTemplateExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetFormTemplateExpressionInfoGenerated } = await import('./formTemplateExpressionInfo.gb');
    return await buildDotNetFormTemplateExpressionInfoGenerated(jsObject, viewId);
}
