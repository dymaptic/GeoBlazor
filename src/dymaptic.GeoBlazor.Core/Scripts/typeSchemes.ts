
export async function buildJsTypeSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTypeSchemesGenerated } = await import('./typeSchemes.gb');
    return await buildJsTypeSchemesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTypeSchemes(jsObject: any): Promise<any> {
    let { buildDotNetTypeSchemesGenerated } = await import('./typeSchemes.gb');
    return await buildDotNetTypeSchemesGenerated(jsObject);
}
