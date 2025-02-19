
export async function buildJsLayerView(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLayerViewGenerated } = await import('./layerView.gb');
    return await buildJsLayerViewGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLayerView(jsObject: any): Promise<any> {
    let { buildDotNetLayerViewGenerated } = await import('./layerView.gb');
    return await buildDotNetLayerViewGenerated(jsObject);
}
