
export async function buildJsSlideElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSlideElementsGenerated } = await import('./slideElements.gb');
    return await buildJsSlideElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSlideElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSlideElementsGenerated } = await import('./slideElements.gb');
    return await buildDotNetSlideElementsGenerated(jsObject, layerId, viewId);
}
