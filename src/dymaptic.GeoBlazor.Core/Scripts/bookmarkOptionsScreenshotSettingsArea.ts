
export async function buildJsBookmarkOptionsScreenshotSettingsArea(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildJsBookmarkOptionsScreenshotSettingsAreaGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBookmarkOptionsScreenshotSettingsArea(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated } = await import('./bookmarkOptionsScreenshotSettingsArea.gb');
    return await buildDotNetBookmarkOptionsScreenshotSettingsAreaGenerated(jsObject, layerId, viewId);
}
