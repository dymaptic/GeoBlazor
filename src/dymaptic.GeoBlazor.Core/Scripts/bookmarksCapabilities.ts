
export async function buildJsBookmarksCapabilities(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildJsBookmarksCapabilitiesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBookmarksCapabilities(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildDotNetBookmarksCapabilitiesGenerated(jsObject, layerId, viewId);
}
