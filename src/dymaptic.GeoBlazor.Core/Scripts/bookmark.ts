
export async function buildJsBookmark(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBookmarkGenerated } = await import('./bookmark.gb');
    return await buildJsBookmarkGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBookmark(jsObject: any): Promise<any> {
    let { buildDotNetBookmarkGenerated } = await import('./bookmark.gb');
    return await buildDotNetBookmarkGenerated(jsObject);
}
