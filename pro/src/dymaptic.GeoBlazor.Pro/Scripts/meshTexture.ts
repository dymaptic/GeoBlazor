
export async function buildJsMeshTexture(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshTextureGenerated } = await import('./meshTexture.gb');
    return await buildJsMeshTextureGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshTexture(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshTextureGenerated } = await import('./meshTexture.gb');
    return await buildDotNetMeshTextureGenerated(jsObject, layerId, viewId);
}
