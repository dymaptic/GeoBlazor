
export async function buildJsCreateFromGLTFParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCreateFromGLTFParametersGenerated } = await import('./createFromGLTFParameters.gb');
    return await buildJsCreateFromGLTFParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCreateFromGLTFParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCreateFromGLTFParametersGenerated } = await import('./createFromGLTFParameters.gb');
    return await buildDotNetCreateFromGLTFParametersGenerated(jsObject, layerId, viewId);
}
