
export async function buildJsCreatePlaneParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCreatePlaneParametersGenerated } = await import('./createPlaneParameters.gb');
    return await buildJsCreatePlaneParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCreatePlaneParameters(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCreatePlaneParametersGenerated } = await import('./createPlaneParameters.gb');
    return await buildDotNetCreatePlaneParametersGenerated(jsObject, layerId, viewId);
}
