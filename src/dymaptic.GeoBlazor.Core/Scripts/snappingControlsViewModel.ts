
export async function buildJsSnappingControlsViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSnappingControlsViewModelGenerated } = await import('./snappingControlsViewModel.gb');
    return await buildJsSnappingControlsViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSnappingControlsViewModel(jsObject: any): Promise<any> {
    let { buildDotNetSnappingControlsViewModelGenerated } = await import('./snappingControlsViewModel.gb');
    return await buildDotNetSnappingControlsViewModelGenerated(jsObject);
}
