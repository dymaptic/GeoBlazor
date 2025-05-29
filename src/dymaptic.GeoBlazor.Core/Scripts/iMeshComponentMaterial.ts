
export async function buildJsIMeshComponentMaterial(dotNetObject: any): Promise<any> {
    let { buildJsIMeshComponentMaterialGenerated } = await import('./iMeshComponentMaterial.gb');
    return await buildJsIMeshComponentMaterialGenerated(dotNetObject);
}     

export async function buildDotNetIMeshComponentMaterial(jsObject: any): Promise<any> {
    let { buildDotNetIMeshComponentMaterialGenerated } = await import('./iMeshComponentMaterial.gb');
    return await buildDotNetIMeshComponentMaterialGenerated(jsObject);
}
