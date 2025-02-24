export async function buildJsIGeolocationPositioning(dotNetObject: any): Promise<any> {
    let {buildJsIGeolocationPositioningGenerated} = await import('./iGeolocationPositioning.gb');
    return buildJsIGeolocationPositioningGenerated(dotNetObject);
}

export async function buildDotNetIGeolocationPositioning(jsObject: any): Promise<any> {
    let {buildDotNetIGeolocationPositioningGenerated} = await import('./iGeolocationPositioning.gb');
    return await buildDotNetIGeolocationPositioningGenerated(jsObject);
}
