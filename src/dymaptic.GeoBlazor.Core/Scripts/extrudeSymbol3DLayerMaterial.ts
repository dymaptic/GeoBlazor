export async function buildJsExtrudeSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsExtrudeSymbol3DLayerMaterialGenerated} = await import('./extrudeSymbol3DLayerMaterial.gb');
    return await buildJsExtrudeSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetExtrudeSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let {buildDotNetExtrudeSymbol3DLayerMaterialGenerated} = await import('./extrudeSymbol3DLayerMaterial.gb');
    return await buildDotNetExtrudeSymbol3DLayerMaterialGenerated(jsObject);
}
