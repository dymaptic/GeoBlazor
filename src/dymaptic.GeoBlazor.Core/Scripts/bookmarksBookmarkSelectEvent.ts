export async function buildJsBookmarksBookmarkSelectEvent(dotNetObject: any): Promise<any> {
    let {buildJsBookmarksBookmarkSelectEventGenerated} = await import('./bookmarksBookmarkSelectEvent.gb');
    return await buildJsBookmarksBookmarkSelectEventGenerated(dotNetObject);
}

export async function buildDotNetBookmarksBookmarkSelectEvent(jsObject: any): Promise<any> {
    let {buildDotNetBookmarksBookmarkSelectEventGenerated} = await import('./bookmarksBookmarkSelectEvent.gb');
    return await buildDotNetBookmarksBookmarkSelectEventGenerated(jsObject);
}
