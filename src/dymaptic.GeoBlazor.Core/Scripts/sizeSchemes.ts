
export async function buildJsSizeSchemes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSizeSchemesGenerated } = await import('./sizeSchemes.gb');
    return await buildJsSizeSchemesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSizeSchemes(jsObject: any): Promise<any> {
    let { buildDotNetSizeSchemesGenerated } = await import('./sizeSchemes.gb');
    return await buildDotNetSizeSchemesGenerated(jsObject);
}
