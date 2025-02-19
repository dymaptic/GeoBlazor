export async function buildJsMapViewTakeScreenshotOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMapViewTakeScreenshotOptionsGenerated } = await import('./mapViewTakeScreenshotOptions.gb');
    return await buildJsMapViewTakeScreenshotOptionsGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetMapViewTakeScreenshotOptions(jsObject: any): Promise<any> {
    let { buildDotNetMapViewTakeScreenshotOptionsGenerated } = await import('./mapViewTakeScreenshotOptions.gb');
    return await buildDotNetMapViewTakeScreenshotOptionsGenerated(jsObject);
}
