
export async function buildJsBookmarksVisibleElements(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildJsBookmarksVisibleElementsGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBookmarksVisibleElements(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildDotNetBookmarksVisibleElementsGenerated(jsObject, viewId);
}
