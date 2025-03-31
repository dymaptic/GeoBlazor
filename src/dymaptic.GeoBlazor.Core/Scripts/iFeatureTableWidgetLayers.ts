
export async function buildJsIFeatureTableWidgetLayers(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureTableWidgetLayersGenerated } = await import('./iFeatureTableWidgetLayers.gb');
    return await buildJsIFeatureTableWidgetLayersGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureTableWidgetLayers(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureTableWidgetLayersGenerated } = await import('./iFeatureTableWidgetLayers.gb');
    return await buildDotNetIFeatureTableWidgetLayersGenerated(jsObject);
}
