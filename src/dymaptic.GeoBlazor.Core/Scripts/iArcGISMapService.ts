export async function buildJsIArcGISMapService(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return await buildJsIArcGISMapServiceGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetIArcGISMapService(jsObject: any): Promise<any> {
    let {buildDotNetIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return await buildDotNetIArcGISMapServiceGenerated(jsObject);
}
