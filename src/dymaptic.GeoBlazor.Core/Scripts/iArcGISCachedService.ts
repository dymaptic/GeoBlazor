export async function buildJsIArcGISCachedService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIArcGISCachedServiceGenerated} = await import('./iArcGISCachedService.gb');
    return await buildJsIArcGISCachedServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIArcGISCachedService(jsObject: any): Promise<any> {
    let {buildDotNetIArcGISCachedServiceGenerated} = await import('./iArcGISCachedService.gb');
    return await buildDotNetIArcGISCachedServiceGenerated(jsObject);
}
