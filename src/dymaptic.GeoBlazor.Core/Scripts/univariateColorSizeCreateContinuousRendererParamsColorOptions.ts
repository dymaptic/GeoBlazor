export async function buildJsUnivariateColorSizeCreateContinuousRendererParamsColorOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUnivariateColorSizeCreateContinuousRendererParamsColorOptionsGenerated} = await import('./univariateColorSizeCreateContinuousRendererParamsColorOptions.gb');
    return await buildJsUnivariateColorSizeCreateContinuousRendererParamsColorOptionsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUnivariateColorSizeCreateContinuousRendererParamsColorOptions(jsObject: any): Promise<any> {
    let {buildDotNetUnivariateColorSizeCreateContinuousRendererParamsColorOptionsGenerated} = await import('./univariateColorSizeCreateContinuousRendererParamsColorOptions.gb');
    return await buildDotNetUnivariateColorSizeCreateContinuousRendererParamsColorOptionsGenerated(jsObject);
}
