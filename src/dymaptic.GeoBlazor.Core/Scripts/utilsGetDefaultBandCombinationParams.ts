export async function buildJsUtilsGetDefaultBandCombinationParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsUtilsGetDefaultBandCombinationParamsGenerated} = await import('./utilsGetDefaultBandCombinationParams.gb');
    return await buildJsUtilsGetDefaultBandCombinationParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetUtilsGetDefaultBandCombinationParams(jsObject: any): Promise<any> {
    let {buildDotNetUtilsGetDefaultBandCombinationParamsGenerated} = await import('./utilsGetDefaultBandCombinationParams.gb');
    return await buildDotNetUtilsGetDefaultBandCombinationParamsGenerated(jsObject);
}
