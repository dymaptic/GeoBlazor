export async function buildJsTextSymbol3DLayerHalo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTextSymbol3DLayerHaloGenerated} = await import('./textSymbol3DLayerHalo.gb');
    return await buildJsTextSymbol3DLayerHaloGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTextSymbol3DLayerHalo(jsObject: any): Promise<any> {
    let {buildDotNetTextSymbol3DLayerHaloGenerated} = await import('./textSymbol3DLayerHalo.gb');
    return await buildDotNetTextSymbol3DLayerHaloGenerated(jsObject);
}
