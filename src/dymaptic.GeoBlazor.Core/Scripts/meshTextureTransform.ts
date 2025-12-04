
export async function buildJsMeshTextureTransform(dotNetObject: any): Promise<any> {
    let { buildJsMeshTextureTransformGenerated } = await import('./meshTextureTransform.gb');
    return await buildJsMeshTextureTransformGenerated(dotNetObject);
}     

export async function buildDotNetMeshTextureTransform(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetMeshTextureTransformGenerated } = await import('./meshTextureTransform.gb');
    return await buildDotNetMeshTextureTransformGenerated(jsObject, viewId);
}
