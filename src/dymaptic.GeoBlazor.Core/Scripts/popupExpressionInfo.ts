
export async function buildJsPopupExpressionInfo(dotNetObject: any): Promise<any> {
    let { buildJsPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildJsPopupExpressionInfoGenerated(dotNetObject);
}     

export async function buildDotNetPopupExpressionInfo(jsObject: any): Promise<any> {
    let { buildDotNetPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildDotNetPopupExpressionInfoGenerated(jsObject);
}
