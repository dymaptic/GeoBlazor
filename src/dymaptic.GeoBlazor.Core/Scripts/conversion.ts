export async function buildJsConversion(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsConversionGenerated} = await import('./conversion.gb');
    return await buildJsConversionGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetConversion(jsObject: any): Promise<any> {
    let {buildDotNetConversionGenerated} = await import('./conversion.gb');
    return await buildDotNetConversionGenerated(jsObject);
}
