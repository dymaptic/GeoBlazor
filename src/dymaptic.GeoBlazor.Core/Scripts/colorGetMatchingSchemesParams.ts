
export async function buildJsColorGetMatchingSchemesParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorGetMatchingSchemesParamsGenerated } = await import('./colorGetMatchingSchemesParams.gb');
    return await buildJsColorGetMatchingSchemesParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorGetMatchingSchemesParams(jsObject: any): Promise<any> {
    let { buildDotNetColorGetMatchingSchemesParamsGenerated } = await import('./colorGetMatchingSchemesParams.gb');
    return await buildDotNetColorGetMatchingSchemesParamsGenerated(jsObject);
}
