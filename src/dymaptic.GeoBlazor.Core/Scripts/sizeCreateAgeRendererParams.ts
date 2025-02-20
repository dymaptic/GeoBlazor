export async function buildJsSizeCreateAgeRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsSizeCreateAgeRendererParamsGenerated} = await import('./sizeCreateAgeRendererParams.gb');
    return await buildJsSizeCreateAgeRendererParamsGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetSizeCreateAgeRendererParams(jsObject: any): Promise<any> {
    let {buildDotNetSizeCreateAgeRendererParamsGenerated} = await import('./sizeCreateAgeRendererParams.gb');
    return await buildDotNetSizeCreateAgeRendererParamsGenerated(jsObject);
}
