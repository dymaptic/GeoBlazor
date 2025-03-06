
export async function buildJsDeviceLocationFeed(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDeviceLocationFeedGenerated } = await import('./deviceLocationFeed.gb');
    return await buildJsDeviceLocationFeedGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDeviceLocationFeed(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDeviceLocationFeedGenerated } = await import('./deviceLocationFeed.gb');
    return await buildDotNetDeviceLocationFeedGenerated(jsObject, layerId, viewId);
}
