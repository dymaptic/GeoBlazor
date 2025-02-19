
export async function buildJsServiceAreaParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsServiceAreaParametersGenerated } = await import('./serviceAreaParameters.gb');
    return await buildJsServiceAreaParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetServiceAreaParameters(jsObject: any): Promise<any> {
    let { buildDotNetServiceAreaParametersGenerated } = await import('./serviceAreaParameters.gb');
    return await buildDotNetServiceAreaParametersGenerated(jsObject);
}
