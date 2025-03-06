
export async function buildJsDotDensityCreateRendererParamsAttributes(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityCreateRendererParamsAttributesGenerated } = await import('./dotDensityCreateRendererParamsAttributes.gb');
    return await buildJsDotDensityCreateRendererParamsAttributesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityCreateRendererParamsAttributes(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetDotDensityCreateRendererParamsAttributesGenerated } = await import('./dotDensityCreateRendererParamsAttributes.gb');
    return await buildDotNetDotDensityCreateRendererParamsAttributesGenerated(jsObject, layerId, viewId);
}
