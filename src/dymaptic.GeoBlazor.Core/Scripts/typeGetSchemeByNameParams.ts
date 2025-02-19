
export async function buildJsTypeGetSchemeByNameParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeGetSchemeByNameParamsGenerated } = await import('./typeGetSchemeByNameParams.gb');
    return await buildJsTypeGetSchemeByNameParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeGetSchemeByNameParams(jsObject: any): Promise<any> {
    let { buildDotNetTypeGetSchemeByNameParamsGenerated } = await import('./typeGetSchemeByNameParams.gb');
    return await buildDotNetTypeGetSchemeByNameParamsGenerated(jsObject);
}
