export async function buildJsSizeUpdateRendererWithReferenceSizeParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeUpdateRendererWithReferenceSizeParamsGenerated} = await import('./sizeUpdateRendererWithReferenceSizeParams.gb');
    return await buildJsSizeUpdateRendererWithReferenceSizeParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeUpdateRendererWithReferenceSizeParams(jsObject: any): Promise<any> {
    let {buildDotNetSizeUpdateRendererWithReferenceSizeParamsGenerated} = await import('./sizeUpdateRendererWithReferenceSizeParams.gb');
    return await buildDotNetSizeUpdateRendererWithReferenceSizeParamsGenerated(jsObject);
}
