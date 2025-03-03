
export async function buildJsFeaturesViewModelFetchFeaturesScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesViewModelFetchFeaturesScreenPointGenerated } = await import('./featuresViewModelFetchFeaturesScreenPoint.gb');
    return await buildJsFeaturesViewModelFetchFeaturesScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesViewModelFetchFeaturesScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesViewModelFetchFeaturesScreenPointGenerated } = await import('./featuresViewModelFetchFeaturesScreenPoint.gb');
    return await buildDotNetFeaturesViewModelFetchFeaturesScreenPointGenerated(jsObject);
}
