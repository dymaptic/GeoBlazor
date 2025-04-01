export async function buildJsBookmarksBookmarkSelectEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBookmarksBookmarkSelectEventGenerated} = await import('./bookmarksBookmarkSelectEvent.gb');
    return await buildJsBookmarksBookmarkSelectEventGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBookmarksBookmarkSelectEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildDotNetBookmarksBookmarkSelectEventGenerated} = await import('./bookmarksBookmarkSelectEvent.gb');
    return await buildDotNetBookmarksBookmarkSelectEventGenerated(jsObject, layerId, viewId);
}
