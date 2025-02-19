
export async function buildJsFeatureFenceParameters(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeatureFenceParametersGenerated } = await import('./featureFenceParameters.gb');
    return await buildJsFeatureFenceParametersGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeatureFenceParameters(jsObject: any): Promise<any> {
    let { buildDotNetFeatureFenceParametersGenerated } = await import('./featureFenceParameters.gb');
    return await buildDotNetFeatureFenceParametersGenerated(jsObject);
}
