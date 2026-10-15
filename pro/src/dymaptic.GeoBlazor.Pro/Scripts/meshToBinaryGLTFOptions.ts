
export async function buildJsMeshToBinaryGLTFOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsMeshToBinaryGLTFOptionsGenerated } = await import('./meshToBinaryGLTFOptions.gb');
    return await buildJsMeshToBinaryGLTFOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetMeshToBinaryGLTFOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetMeshToBinaryGLTFOptionsGenerated } = await import('./meshToBinaryGLTFOptions.gb');
    return await buildDotNetMeshToBinaryGLTFOptionsGenerated(jsObject, layerId, viewId);
}
