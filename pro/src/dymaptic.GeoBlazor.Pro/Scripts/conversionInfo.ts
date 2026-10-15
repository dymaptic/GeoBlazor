
export async function buildJsConversionInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConversionInfoGenerated } = await import('./conversionInfo.gb');
    return await buildJsConversionInfoGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConversionInfo(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetConversionInfoGenerated } = await import('./conversionInfo.gb');
    return await buildDotNetConversionInfoGenerated(jsObject, layerId, viewId);
}
