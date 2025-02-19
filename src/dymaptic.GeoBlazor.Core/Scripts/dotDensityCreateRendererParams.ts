
export async function buildJsDotDensityCreateRendererParams(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDotDensityCreateRendererParamsGenerated } = await import('./dotDensityCreateRendererParams.gb');
    return await buildJsDotDensityCreateRendererParamsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDotDensityCreateRendererParams(jsObject: any): Promise<any> {
    let { buildDotNetDotDensityCreateRendererParamsGenerated } = await import('./dotDensityCreateRendererParams.gb');
    return await buildDotNetDotDensityCreateRendererParamsGenerated(jsObject);
}
