export async function buildJsTypeGetSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsTypeGetSchemesParamsGenerated} = await import('./typeGetSchemesParams.gb');
    return await buildJsTypeGetSchemesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetTypeGetSchemesParams(jsObject: any): Promise<any> {
    let {buildDotNetTypeGetSchemesParamsGenerated} = await import('./typeGetSchemesParams.gb');
    return await buildDotNetTypeGetSchemesParamsGenerated(jsObject);
}
