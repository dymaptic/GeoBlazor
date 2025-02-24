export async function buildJsIArcGISCachedService(dotNetObject: any): Promise<any> {
    let {buildJsIArcGISCachedServiceGenerated} = await import('./iArcGISCachedService.gb');
    return buildJsIArcGISCachedServiceGenerated(dotNetObject);
}

export async function buildDotNetIArcGISCachedService(jsObject: any): Promise<any> {
    let {buildDotNetIArcGISCachedServiceGenerated} = await import('./iArcGISCachedService.gb');
    return await buildDotNetIArcGISCachedServiceGenerated(jsObject);
}
