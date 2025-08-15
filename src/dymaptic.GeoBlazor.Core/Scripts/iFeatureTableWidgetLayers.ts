
export async function buildJsIFeatureTableWidgetLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureTableWidgetLayersGenerated } = await import('./iFeatureTableWidgetLayers.gb');
    return await buildJsIFeatureTableWidgetLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureTableWidgetLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureTableWidgetLayersGenerated } = await import('./iFeatureTableWidgetLayers.gb');
    return await buildDotNetIFeatureTableWidgetLayersGenerated(jsObject, viewId);
}
