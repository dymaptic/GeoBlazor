export async function buildJsObjectSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsObjectSymbol3DLayerMaterialGenerated} = await import('./objectSymbol3DLayerMaterial.gb');
    return await buildJsObjectSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetObjectSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let {buildDotNetObjectSymbol3DLayerMaterialGenerated} = await import('./objectSymbol3DLayerMaterial.gb');
    return await buildDotNetObjectSymbol3DLayerMaterialGenerated(jsObject);
}
