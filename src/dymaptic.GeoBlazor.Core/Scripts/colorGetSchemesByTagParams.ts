export async function buildJsColorGetSchemesByTagParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsColorGetSchemesByTagParamsGenerated} = await import('./colorGetSchemesByTagParams.gb');
    return await buildJsColorGetSchemesByTagParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetColorGetSchemesByTagParams(jsObject: any): Promise<any> {
    let {buildDotNetColorGetSchemesByTagParamsGenerated} = await import('./colorGetSchemesByTagParams.gb');
    return await buildDotNetColorGetSchemesByTagParamsGenerated(jsObject);
}
