
export async function buildJsDirectionalPadVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDirectionalPadVisibleElementsGenerated } = await import('./directionalPadVisibleElements.gb');
    return await buildJsDirectionalPadVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDirectionalPadVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDirectionalPadVisibleElementsGenerated } = await import('./directionalPadVisibleElements.gb');
    return await buildDotNetDirectionalPadVisibleElementsGenerated(jsObject, layerId, viewId);
}
