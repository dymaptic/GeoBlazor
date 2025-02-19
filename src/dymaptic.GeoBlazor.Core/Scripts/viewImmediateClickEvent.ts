
export async function buildJsViewImmediateClickEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsViewImmediateClickEventGenerated } = await import('./viewImmediateClickEvent.gb');
    return await buildJsViewImmediateClickEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetViewImmediateClickEvent(jsObject: any): Promise<any> {
    let { buildDotNetViewImmediateClickEventGenerated } = await import('./viewImmediateClickEvent.gb');
    return await buildDotNetViewImmediateClickEventGenerated(jsObject);
}
