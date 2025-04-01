
export async function buildJsBookmarkOptionsScreenshotSettingsArea(dotNetObject: any): Promise<any> {
    let { buildJsBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildJsBookmarkOptionsScreenshotSettingsAreaGenerated(dotNetObject);
}     

export async function buildDotNetBookmarkOptionsScreenshotSettingsArea(jsObject: any): Promise<any> {
    let { buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated(jsObject);
}
