
export async function buildJsTypeGetSchemesByTagParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeGetSchemesByTagParamsGenerated } = await import('./typeGetSchemesByTagParams.gb');
    return await buildJsTypeGetSchemesByTagParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeGetSchemesByTagParams(jsObject: any): Promise<any> {
    let { buildDotNetTypeGetSchemesByTagParamsGenerated } = await import('./typeGetSchemesByTagParams.gb');
    return await buildDotNetTypeGetSchemesByTagParamsGenerated(jsObject);
}
