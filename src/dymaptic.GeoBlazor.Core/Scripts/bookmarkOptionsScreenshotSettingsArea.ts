
export async function buildJsBookmarkOptionsScreenshotSettingsArea(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildJsBookmarkOptionsScreenshotSettingsAreaGenerated(dotNetObject, viewId);
}     

export async function buildDotNetBookmarkOptionsScreenshotSettingsArea(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated(jsObject, viewId);
}
