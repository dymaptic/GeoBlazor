
export async function buildJsPopupExpressionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildJsPopupExpressionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetPopupExpressionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetPopupExpressionInfoGenerated } = await import('./popupExpressionInfo.gb');
    return await buildDotNetPopupExpressionInfoGenerated(jsObject, layerId, viewId);
}
