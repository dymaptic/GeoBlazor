export async function buildJsIGeolocationPositioning(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIGeolocationPositioningGenerated } = await import('./iGeolocationPositioning.gb');
    return await buildJsIGeolocationPositioningGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetIGeolocationPositioning(jsObject: any): Promise<any> {
    let { buildDotNetIGeolocationPositioningGenerated } = await import('./iGeolocationPositioning.gb');
    return await buildDotNetIGeolocationPositioningGenerated(jsObject);
}
