export async function buildJsBookmarksBookmarkEditEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBookmarksBookmarkEditEventGenerated} = await import('./bookmarksBookmarkEditEvent.gb');
    return await buildJsBookmarksBookmarkEditEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBookmarksBookmarkEditEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBookmarksBookmarkEditEventGenerated} = await import('./bookmarksBookmarkEditEvent.gb');
    return await buildDotNetBookmarksBookmarkEditEventGenerated(jsObject, layerId, viewId);
}
