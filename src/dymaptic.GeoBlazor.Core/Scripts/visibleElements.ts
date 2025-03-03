
export async function buildJsVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildJsVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildDotNetVisibleElementsGenerated(jsObject);
}
