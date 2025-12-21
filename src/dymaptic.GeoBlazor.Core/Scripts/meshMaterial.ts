
export function buildJsMeshMaterial(dotNetObject: any): any {
    let { buildJsMeshMaterialGenerated } = await import('./meshMaterial.gb');
    return buildJsMeshMaterialGenerated(dotNetObject);
}     

export function buildDotNetMeshMaterial(jsObject: any): any {
    let { buildDotNetMeshMaterialGenerated } = await import('./meshMaterial.gb');
    return buildDotNetMeshMaterialGenerated(jsObject);
}
