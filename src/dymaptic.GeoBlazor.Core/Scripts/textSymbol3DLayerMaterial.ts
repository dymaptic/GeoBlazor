
export async function buildJsTextSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTextSymbol3DLayerMaterialGenerated } = await import('./textSymbol3DLayerMaterial.gb');
    return await buildJsTextSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTextSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let { buildDotNetTextSymbol3DLayerMaterialGenerated } = await import('./textSymbol3DLayerMaterial.gb');
    return await buildDotNetTextSymbol3DLayerMaterialGenerated(jsObject);
}
