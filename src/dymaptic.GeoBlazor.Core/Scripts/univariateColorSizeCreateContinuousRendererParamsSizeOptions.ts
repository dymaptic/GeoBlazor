
export async function buildJsUnivariateColorSizeCreateContinuousRendererParamsSizeOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUnivariateColorSizeCreateContinuousRendererParamsSizeOptionsGenerated } = await import('./univariateColorSizeCreateContinuousRendererParamsSizeOptions.gb');
    return await buildJsUnivariateColorSizeCreateContinuousRendererParamsSizeOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUnivariateColorSizeCreateContinuousRendererParamsSizeOptions(jsObject: any): Promise<any> {
    let { buildDotNetUnivariateColorSizeCreateContinuousRendererParamsSizeOptionsGenerated } = await import('./univariateColorSizeCreateContinuousRendererParamsSizeOptions.gb');
    return await buildDotNetUnivariateColorSizeCreateContinuousRendererParamsSizeOptionsGenerated(jsObject);
}
