export async function buildJsBookmarkOptionsScreenshotSettings(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBookmarkOptionsScreenshotSettingsGenerated} = await import('./bookmarkOptionsScreenshotSettings.gb');
    return await buildJsBookmarkOptionsScreenshotSettingsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBookmarkOptionsScreenshotSettings(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetBookmarkOptionsScreenshotSettingsGenerated} = await import('./bookmarkOptionsScreenshotSettings.gb');
    return await buildDotNetBookmarkOptionsScreenshotSettingsGenerated(jsObject, viewId);
}
