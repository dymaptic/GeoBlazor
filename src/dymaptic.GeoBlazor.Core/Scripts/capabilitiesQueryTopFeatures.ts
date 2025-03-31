
export async function buildJsCapabilitiesQueryTopFeatures(dotNetObject: any): Promise<any> {
    let { buildJsCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildJsCapabilitiesQueryTopFeaturesGenerated(dotNetObject);
}     

export async function buildDotNetCapabilitiesQueryTopFeatures(jsObject: any): Promise<any> {
    let { buildDotNetCapabilitiesQueryTopFeaturesGenerated } = await import('./capabilitiesQueryTopFeatures.gb');
    return await buildDotNetCapabilitiesQueryTopFeaturesGenerated(jsObject);
}
