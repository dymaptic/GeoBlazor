
export async function buildJsBookmarksCapabilities(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildJsBookmarksCapabilitiesGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBookmarksCapabilities(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildDotNetBookmarksCapabilitiesGenerated(jsObject, viewId);
}
