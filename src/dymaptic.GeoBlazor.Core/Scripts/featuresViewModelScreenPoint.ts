
export async function buildJsFeaturesViewModelScreenPoint(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesViewModelScreenPointGenerated } = await import('./featuresViewModelScreenPoint.gb');
    return await buildJsFeaturesViewModelScreenPointGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesViewModelScreenPoint(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesViewModelScreenPointGenerated } = await import('./featuresViewModelScreenPoint.gb');
    return await buildDotNetFeaturesViewModelScreenPointGenerated(jsObject);
}
