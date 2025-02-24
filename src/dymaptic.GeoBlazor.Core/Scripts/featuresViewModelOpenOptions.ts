
export async function buildJsFeaturesViewModelOpenOptions(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesViewModelOpenOptionsGenerated } = await import('./featuresViewModelOpenOptions.gb');
    return await buildJsFeaturesViewModelOpenOptionsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesViewModelOpenOptions(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetFeaturesViewModelOpenOptionsGenerated } = await import('./featuresViewModelOpenOptions.gb');
    return await buildDotNetFeaturesViewModelOpenOptionsGenerated(jsObject, layerId, viewId);
}
