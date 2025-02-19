
export async function buildJsFeaturesOpenOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesOpenOptionsGenerated } = await import('./featuresOpenOptions.gb');
    return await buildJsFeaturesOpenOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesOpenOptions(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesOpenOptionsGenerated } = await import('./featuresOpenOptions.gb');
    return await buildDotNetFeaturesOpenOptionsGenerated(jsObject);
}
