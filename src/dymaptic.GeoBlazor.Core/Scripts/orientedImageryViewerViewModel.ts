
export async function buildJsOrientedImageryViewerViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsOrientedImageryViewerViewModelGenerated } = await import('./orientedImageryViewerViewModel.gb');
    return await buildJsOrientedImageryViewerViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetOrientedImageryViewerViewModel(jsObject: any): Promise<any> {
    let { buildDotNetOrientedImageryViewerViewModelGenerated } = await import('./orientedImageryViewerViewModel.gb');
    return await buildDotNetOrientedImageryViewerViewModelGenerated(jsObject);
}
