export async function buildJsBookmarkOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBookmarkOptionsGenerated} = await import('./bookmarkOptions.gb');
    return await buildJsBookmarkOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBookmarkOptions(jsObject: any): Promise<any> {
    let {buildDotNetBookmarkOptionsGenerated} = await import('./bookmarkOptions.gb');
    return await buildDotNetBookmarkOptionsGenerated(jsObject);
}
