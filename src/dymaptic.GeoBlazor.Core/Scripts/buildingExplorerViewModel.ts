export async function buildJsBuildingExplorerViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsBuildingExplorerViewModelGenerated} = await import('./buildingExplorerViewModel.gb');
    return await buildJsBuildingExplorerViewModelGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetBuildingExplorerViewModel(jsObject: any): Promise<any> {
    let {buildDotNetBuildingExplorerViewModelGenerated} = await import('./buildingExplorerViewModel.gb');
    return await buildDotNetBuildingExplorerViewModelGenerated(jsObject);
}
