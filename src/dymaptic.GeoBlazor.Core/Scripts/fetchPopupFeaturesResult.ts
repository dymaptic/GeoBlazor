export async function buildJsFetchPopupFeaturesResult(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsFetchPopupFeaturesResultGenerated} = await import('./fetchPopupFeaturesResult.gb');
    return await buildJsFetchPopupFeaturesResultGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetFetchPopupFeaturesResult(jsObject: any): Promise<any> {
    let {buildDotNetFetchPopupFeaturesResultGenerated} = await import('./fetchPopupFeaturesResult.gb');
    return await buildDotNetFetchPopupFeaturesResultGenerated(jsObject);
}
