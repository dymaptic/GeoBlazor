export async function buildJsIArcGISMapService(dotNetObject: any): Promise<any> {
    let {buildJsIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return buildJsIArcGISMapServiceGenerated(dotNetObject);
}

export async function buildDotNetIArcGISMapService(jsObject: any, viewId: string | null): Promise<any> {
    let {buildDotNetIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return await buildDotNetIArcGISMapServiceGenerated(jsObject, viewId);
}
