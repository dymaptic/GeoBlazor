
export async function buildJsElevationSamplerDemResolution(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsElevationSamplerDemResolutionGenerated } = await import('./elevationSamplerDemResolution.gb');
    return await buildJsElevationSamplerDemResolutionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetElevationSamplerDemResolution(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetElevationSamplerDemResolutionGenerated } = await import('./elevationSamplerDemResolution.gb');
    return await buildDotNetElevationSamplerDemResolutionGenerated(jsObject, viewId);
}
