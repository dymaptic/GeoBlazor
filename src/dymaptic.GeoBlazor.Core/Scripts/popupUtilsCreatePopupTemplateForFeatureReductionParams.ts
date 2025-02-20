export async function buildJsPopupUtilsCreatePopupTemplateForFeatureReductionParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsPopupUtilsCreatePopupTemplateForFeatureReductionParamsGenerated} = await import('./popupUtilsCreatePopupTemplateForFeatureReductionParams.gb');
    return await buildJsPopupUtilsCreatePopupTemplateForFeatureReductionParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetPopupUtilsCreatePopupTemplateForFeatureReductionParams(jsObject: any): Promise<any> {
    let {buildDotNetPopupUtilsCreatePopupTemplateForFeatureReductionParamsGenerated} = await import('./popupUtilsCreatePopupTemplateForFeatureReductionParams.gb');
    return await buildDotNetPopupUtilsCreatePopupTemplateForFeatureReductionParamsGenerated(jsObject);
}
