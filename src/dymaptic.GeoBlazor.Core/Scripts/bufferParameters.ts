
export async function buildJsBufferParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBufferParametersGenerated } = await import('./bufferParameters.gb');
    return await buildJsBufferParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBufferParameters(jsObject: any): Promise<any> {
    let { buildDotNetBufferParametersGenerated } = await import('./bufferParameters.gb');
    return await buildDotNetBufferParametersGenerated(jsObject);
}
