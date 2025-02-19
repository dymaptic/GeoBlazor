
export async function buildJsViewImmediateDoubleClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewImmediateDoubleClickEventGenerated } = await import('./viewImmediateDoubleClickEvent.gb');
    return await buildJsViewImmediateDoubleClickEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewImmediateDoubleClickEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewImmediateDoubleClickEventGenerated } = await import('./viewImmediateDoubleClickEvent.gb');
    return await buildDotNetViewImmediateDoubleClickEventGenerated(jsObject);
}
