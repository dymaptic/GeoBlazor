
export async function buildJsSceneViewTakeScreenshotOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewTakeScreenshotOptionsGenerated } = await import('./sceneViewTakeScreenshotOptions.gb');
    return await buildJsSceneViewTakeScreenshotOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewTakeScreenshotOptions(jsObject: any): Promise<any> {
    let { buildDotNetSceneViewTakeScreenshotOptionsGenerated } = await import('./sceneViewTakeScreenshotOptions.gb');
    return await buildDotNetSceneViewTakeScreenshotOptionsGenerated(jsObject);
}
