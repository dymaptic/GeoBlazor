
export async function buildJsCapabilitiesQueryTopFeatures(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildJsCapabilitiesQueryTopFeaturesGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetCapabilitiesQueryTopFeatures(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildDotNetCapabilitiesQueryTopFeaturesGenerated(jsObject, layerId, viewId);
}
