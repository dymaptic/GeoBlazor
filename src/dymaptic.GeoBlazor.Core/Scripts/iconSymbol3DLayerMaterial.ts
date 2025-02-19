
export async function buildJsIconSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIconSymbol3DLayerMaterialGenerated } = await import('./iconSymbol3DLayerMaterial.gb');
    return await buildJsIconSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIconSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let { buildDotNetIconSymbol3DLayerMaterialGenerated } = await import('./iconSymbol3DLayerMaterial.gb');
    return await buildDotNetIconSymbol3DLayerMaterialGenerated(jsObject);
}
