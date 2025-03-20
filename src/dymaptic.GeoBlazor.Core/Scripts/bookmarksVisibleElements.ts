
export async function buildJsBookmarksVisibleElements(dotNetObject: any): Promise<any> {
    let { buildJsBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildJsBookmarksVisibleElementsGenerated(dotNetObject);
}     

export async function buildDotNetBookmarksVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetBookmarksVisibleElementsGenerated } = await import('./bookmarksVisibleElements.gb');
    return await buildDotNetBookmarksVisibleElementsGenerated(jsObject);
}
