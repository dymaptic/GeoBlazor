
export async function buildJsMeshTextureTransform(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshTextureTransformGenerated } = await import('./meshTextureTransform.gb');
    return await buildJsMeshTextureTransformGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshTextureTransform(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMeshTextureTransformGenerated } = await import('./meshTextureTransform.gb');
    return await buildDotNetMeshTextureTransformGenerated(jsObject, viewId);
}
