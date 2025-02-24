export async function buildJsIArcGISMapService(dotNetObject: any): Promise<any> {
    let {buildJsIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return buildJsIArcGISMapServiceGenerated(dotNetObject);
}

export async function buildDotNetIArcGISMapService(jsObject: any): Promise<any> {
    let {buildDotNetIArcGISMapServiceGenerated} = await import('./iArcGISMapService.gb');
    return await buildDotNetIArcGISMapServiceGenerated(jsObject);
}
