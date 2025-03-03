
export async function buildJsBuildingExplorerVisibleElements(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsBuildingExplorerVisibleElementsGenerated } = await import('./buildingExplorerVisibleElements.gb');
    return await buildJsBuildingExplorerVisibleElementsGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetBuildingExplorerVisibleElements(jsObject: any): Promise<any> {
    let { buildDotNetBuildingExplorerVisibleElementsGenerated } = await import('./buildingExplorerVisibleElements.gb');
    return await buildDotNetBuildingExplorerVisibleElementsGenerated(jsObject);
}
