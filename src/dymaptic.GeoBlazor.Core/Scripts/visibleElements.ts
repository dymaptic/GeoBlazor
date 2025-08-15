
export async function buildJsVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildJsVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsGenerated } = await import('./visibleElements.gb');
    return await buildDotNetVisibleElementsGenerated(jsObject, viewId);
}
