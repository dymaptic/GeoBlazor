
export async function buildJsLineSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsLineSymbol3DLayerMaterialGenerated } = await import('./lineSymbol3DLayerMaterial.gb');
    return await buildJsLineSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetLineSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let { buildDotNetLineSymbol3DLayerMaterialGenerated } = await import('./lineSymbol3DLayerMaterial.gb');
    return await buildDotNetLineSymbol3DLayerMaterialGenerated(jsObject);
}
