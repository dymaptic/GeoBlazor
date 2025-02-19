export async function buildJsTextSymbol3DLayerBackground(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextSymbol3DLayerBackgroundGenerated } = await import('./textSymbol3DLayerBackground.gb');
    return await buildJsTextSymbol3DLayerBackgroundGenerated(dotNetObject, layerId, viewId);
}
export async function buildDotNetTextSymbol3DLayerBackground(jsObject: any): Promise<any> {
    let { buildDotNetTextSymbol3DLayerBackgroundGenerated } = await import('./textSymbol3DLayerBackground.gb');
    return await buildDotNetTextSymbol3DLayerBackgroundGenerated(jsObject);
}
