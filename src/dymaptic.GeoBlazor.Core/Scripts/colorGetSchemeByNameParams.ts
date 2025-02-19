
export async function buildJsColorGetSchemeByNameParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsColorGetSchemeByNameParamsGenerated } = await import('./colorGetSchemeByNameParams.gb');
    return await buildJsColorGetSchemeByNameParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetColorGetSchemeByNameParams(jsObject: any): Promise<any> {
    let { buildDotNetColorGetSchemeByNameParamsGenerated } = await import('./colorGetSchemeByNameParams.gb');
    return await buildDotNetColorGetSchemeByNameParamsGenerated(jsObject);
}
