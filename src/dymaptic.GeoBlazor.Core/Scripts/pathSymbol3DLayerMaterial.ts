export async function buildJsPathSymbol3DLayerMaterial(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPathSymbol3DLayerMaterialGenerated} = await import('./pathSymbol3DLayerMaterial.gb');
    return await buildJsPathSymbol3DLayerMaterialGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPathSymbol3DLayerMaterial(jsObject: any): Promise<any> {
    let {buildDotNetPathSymbol3DLayerMaterialGenerated} = await import('./pathSymbol3DLayerMaterial.gb');
    return await buildDotNetPathSymbol3DLayerMaterialGenerated(jsObject);
}
