
export async function buildJsUnivariateColorSizeCreateVisualVariablesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnivariateColorSizeCreateVisualVariablesParamsGenerated } = await import('./univariateColorSizeCreateVisualVariablesParams.gb');
    return await buildJsUnivariateColorSizeCreateVisualVariablesParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnivariateColorSizeCreateVisualVariablesParams(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetUnivariateColorSizeCreateVisualVariablesParamsGenerated } = await import('./univariateColorSizeCreateVisualVariablesParams.gb');
    return await buildDotNetUnivariateColorSizeCreateVisualVariablesParamsGenerated(jsObject, layerId, viewId);
}
