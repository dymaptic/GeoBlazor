
export async function buildJsAlterVersionParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAlterVersionParametersGenerated } = await import('./alterVersionParameters.gb');
    return await buildJsAlterVersionParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAlterVersionParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetAlterVersionParametersGenerated } = await import('./alterVersionParameters.gb');
    return await buildDotNetAlterVersionParametersGenerated(jsObject, layerId, viewId);
}
