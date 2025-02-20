export async function buildJsColorGetSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorGetSchemesParamsGenerated} = await import('./colorGetSchemesParams.gb');
    return await buildJsColorGetSchemesParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorGetSchemesParams(jsObject: any): Promise<any> {
    let {buildDotNetColorGetSchemesParamsGenerated} = await import('./colorGetSchemesParams.gb');
    return await buildDotNetColorGetSchemesParamsGenerated(jsObject);
}
