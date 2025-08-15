
export async function buildJsPopupExpressionInfo(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildJsPopupExpressionInfoGenerated(dotNetObject, viewId);
}     

export async function buildDotNetPopupExpressionInfo(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildDotNetPopupExpressionInfoGenerated(jsObject, viewId);
}
