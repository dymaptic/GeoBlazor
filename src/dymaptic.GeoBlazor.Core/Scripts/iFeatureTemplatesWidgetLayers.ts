
export async function buildJsIFeatureTemplatesWidgetLayers(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsIFeatureTemplatesWidgetLayersGenerated } = await import('./iFeatureTemplatesWidgetLayers.gb');
    return await buildJsIFeatureTemplatesWidgetLayersGenerated(dotNetObject, viewId);
}     

export async function buildDotNetIFeatureTemplatesWidgetLayers(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIFeatureTemplatesWidgetLayersGenerated } = await import('./iFeatureTemplatesWidgetLayers.gb');
    return await buildDotNetIFeatureTemplatesWidgetLayersGenerated(jsObject, viewId);
}
