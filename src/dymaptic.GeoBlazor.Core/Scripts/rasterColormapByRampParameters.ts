export async function buildJsRasterColormapByRampParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsRasterColormapByRampParametersGenerated} = await import('./rasterColormapByRampParameters.gb');
    return await buildJsRasterColormapByRampParametersGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetRasterColormapByRampParameters(jsObject: any): Promise<any> {
    let {buildDotNetRasterColormapByRampParametersGenerated} = await import('./rasterColormapByRampParameters.gb');
    return await buildDotNetRasterColormapByRampParametersGenerated(jsObject);
}
