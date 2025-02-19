
export async function buildJsFillSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFillSymbol3DLayerMaterialGenerated } = await import('./fillSymbol3DLayerMaterial.gb');
    return await buildJsFillSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFillSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let { buildDotNetFillSymbol3DLayerMaterialGenerated } = await import('./fillSymbol3DLayerMaterial.gb');
    return await buildDotNetFillSymbol3DLayerMaterialGenerated(jsObject);
}
