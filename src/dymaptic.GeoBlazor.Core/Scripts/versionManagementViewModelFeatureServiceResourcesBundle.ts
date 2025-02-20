export async function buildJsVersionManagementViewModelFeatureServiceResourcesBundle(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsVersionManagementViewModelFeatureServiceResourcesBundleGenerated} = await import('./versionManagementViewModelFeatureServiceResourcesBundle.gb');
    return await buildJsVersionManagementViewModelFeatureServiceResourcesBundleGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetVersionManagementViewModelFeatureServiceResourcesBundle(jsObject: any): Promise<any> {
    let {buildDotNetVersionManagementViewModelFeatureServiceResourcesBundleGenerated} = await import('./versionManagementViewModelFeatureServiceResourcesBundle.gb');
    return await buildDotNetVersionManagementViewModelFeatureServiceResourcesBundleGenerated(jsObject);
}
