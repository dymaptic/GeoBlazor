
export async function buildJsIFeatureTemplatesWidgetLayers(dotNetObject: any): Promise<any> {
    let { buildJsIFeatureTemplatesWidgetLayersGenerated } = await import('./iFeatureTemplatesWidgetLayers.gb');
    return await buildJsIFeatureTemplatesWidgetLayersGenerated(dotNetObject);
}     

export async function buildDotNetIFeatureTemplatesWidgetLayers(jsObject: any): Promise<any> {
    let { buildDotNetIFeatureTemplatesWidgetLayersGenerated } = await import('./iFeatureTemplatesWidgetLayers.gb');
    return await buildDotNetIFeatureTemplatesWidgetLayersGenerated(jsObject);
}
