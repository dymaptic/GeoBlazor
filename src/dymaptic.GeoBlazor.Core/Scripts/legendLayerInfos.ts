export async function buildJsLegendLayerInfos(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsLegendLayerInfosGenerated} = await import('./legendLayerInfos.gb');
    return await buildJsLegendLayerInfosGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetLegendLayerInfos(jsObject: any): Promise<any> {
    let {buildDotNetLegendLayerInfosGenerated} = await import('./legendLayerInfos.gb');
    return await buildDotNetLegendLayerInfosGenerated(jsObject);
}
