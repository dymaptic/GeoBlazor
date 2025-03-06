
export async function buildJsBookmarksVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildJsBookmarksVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBookmarksVisibleElements(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildDotNetBookmarksVisibleElementsGenerated(jsObject, layerId, viewId);
}
