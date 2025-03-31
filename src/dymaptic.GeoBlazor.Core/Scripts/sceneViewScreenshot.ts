
export async function buildJsSceneViewScreenshot(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewScreenshotGenerated } = await import('./sceneViewScreenshot.gb');
    return await buildJsSceneViewScreenshotGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewScreenshot(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetSceneViewScreenshotGenerated } = await import('./sceneViewScreenshot.gb');
    return await buildDotNetSceneViewScreenshotGenerated(jsObject, layerId, viewId);
}
