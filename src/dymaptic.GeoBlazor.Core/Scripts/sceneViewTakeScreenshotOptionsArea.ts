
export async function buildJsSceneViewTakeScreenshotOptionsArea(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSceneViewTakeScreenshotOptionsAreaGenerated } = await import('./sceneViewTakeScreenshotOptionsArea.gb');
    return await buildJsSceneViewTakeScreenshotOptionsAreaGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSceneViewTakeScreenshotOptionsArea(jsObject: any): Promise<any> {
    let { buildDotNetSceneViewTakeScreenshotOptionsAreaGenerated } = await import('./sceneViewTakeScreenshotOptionsArea.gb');
    return await buildDotNetSceneViewTakeScreenshotOptionsAreaGenerated(jsObject);
}
