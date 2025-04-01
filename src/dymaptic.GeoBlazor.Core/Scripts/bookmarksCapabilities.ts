
export async function buildJsBookmarksCapabilities(dotNetObject: any): Promise<any> {
    let { buildJsBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildJsBookmarksCapabilitiesGenerated(dotNetObject);
}     

export async function buildDotNetBookmarksCapabilities(jsObject: any): Promise<any> {
    let { buildDotNetBookmarksCapabilitiesGenerated } = await import('./bookmarksCapabilities.gb');
    return await buildDotNetBookmarksCapabilitiesGenerated(jsObject);
}
