export async function buildJsUnivariateColorSizeCreateVisualVariablesParamsSizeOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUnivariateColorSizeCreateVisualVariablesParamsSizeOptionsGenerated} = await import('./univariateColorSizeCreateVisualVariablesParamsSizeOptions.gb');
    return await buildJsUnivariateColorSizeCreateVisualVariablesParamsSizeOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUnivariateColorSizeCreateVisualVariablesParamsSizeOptions(jsObject: any): Promise<any> {
    let {buildDotNetUnivariateColorSizeCreateVisualVariablesParamsSizeOptionsGenerated} = await import('./univariateColorSizeCreateVisualVariablesParamsSizeOptions.gb');
    return await buildDotNetUnivariateColorSizeCreateVisualVariablesParamsSizeOptionsGenerated(jsObject);
}
