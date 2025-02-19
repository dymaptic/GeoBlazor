
export async function buildJsAgeUtilsGetAgeExpressionsParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsAgeUtilsGetAgeExpressionsParamsGenerated } = await import('./ageUtilsGetAgeExpressionsParams.gb');
    return await buildJsAgeUtilsGetAgeExpressionsParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetAgeUtilsGetAgeExpressionsParams(jsObject: any): Promise<any> {
    let { buildDotNetAgeUtilsGetAgeExpressionsParamsGenerated } = await import('./ageUtilsGetAgeExpressionsParams.gb');
    return await buildDotNetAgeUtilsGetAgeExpressionsParamsGenerated(jsObject);
}
