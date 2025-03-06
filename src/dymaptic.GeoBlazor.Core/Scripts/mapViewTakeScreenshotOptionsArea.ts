
export async function buildJsMapViewTakeScreenshotOptionsArea(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewTakeScreenshotOptionsAreaGenerated } = await import('./mapViewTakeScreenshotOptionsArea.gb');
    return await buildJsMapViewTakeScreenshotOptionsAreaGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMapViewTakeScreenshotOptionsArea(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMapViewTakeScreenshotOptionsAreaGenerated } = await import('./mapViewTakeScreenshotOptionsArea.gb');
    return await buildDotNetMapViewTakeScreenshotOptionsAreaGenerated(jsObject, layerId, viewId);
}
