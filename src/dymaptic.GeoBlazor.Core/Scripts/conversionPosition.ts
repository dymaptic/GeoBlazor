
export async function buildJsConversionPosition(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsConversionPositionGenerated } = await import('./conversionPosition.gb');
    return await buildJsConversionPositionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetConversionPosition(jsObject: any): Promise<any> {
    let { buildDotNetConversionPositionGenerated } = await import('./conversionPosition.gb');
    return await buildDotNetConversionPositionGenerated(jsObject);
}
