export async function buildJsUnivariateColorSizeCreateContinuousRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUnivariateColorSizeCreateContinuousRendererParamsGenerated} = await import('./univariateColorSizeCreateContinuousRendererParams.gb');
    return await buildJsUnivariateColorSizeCreateContinuousRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUnivariateColorSizeCreateContinuousRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetUnivariateColorSizeCreateContinuousRendererParamsGenerated} = await import('./univariateColorSizeCreateContinuousRendererParams.gb');
    return await buildDotNetUnivariateColorSizeCreateContinuousRendererParamsGenerated(jsObject);
}
