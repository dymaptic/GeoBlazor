
export async function buildJsWebMapWidgets(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebMapWidgetsGenerated } = await import('./webMapWidgets.gb');
    return await buildJsWebMapWidgetsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebMapWidgets(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetWebMapWidgetsGenerated } = await import('./webMapWidgets.gb');
    return await buildDotNetWebMapWidgetsGenerated(jsObject, viewId);
}
