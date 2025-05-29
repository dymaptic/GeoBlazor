
export async function buildJsUpdateElevationPropsWithSampler(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUpdateElevationPropsWithSamplerGenerated } = await import('./updateElevationPropsWithSampler.gb');
    return await buildJsUpdateElevationPropsWithSamplerGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUpdateElevationPropsWithSampler(jsObject: any): Promise<any> {
    let { buildDotNetUpdateElevationPropsWithSamplerGenerated } = await import('./updateElevationPropsWithSampler.gb');
    return await buildDotNetUpdateElevationPropsWithSamplerGenerated(jsObject);
}
