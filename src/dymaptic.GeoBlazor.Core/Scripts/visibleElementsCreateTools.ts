
export async function buildJsVisibleElementsCreateTools(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsVisibleElementsCreateToolsGenerated } = await import('./visibleElementsCreateTools.gb');
    return await buildJsVisibleElementsCreateToolsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetVisibleElementsCreateTools(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetVisibleElementsCreateToolsGenerated } = await import('./visibleElementsCreateTools.gb');
    return await buildDotNetVisibleElementsCreateToolsGenerated(jsObject, layerId, viewId);
}
