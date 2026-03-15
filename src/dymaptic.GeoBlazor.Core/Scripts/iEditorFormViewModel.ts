
export async function buildJsIEditorFormViewModel(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsIEditorFormViewModelGenerated } = await import('./iEditorFormViewModel.gb');
    return await buildJsIEditorFormViewModelGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetIEditorFormViewModel(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetIEditorFormViewModelGenerated } = await import('./iEditorFormViewModel.gb');
    return await buildDotNetIEditorFormViewModelGenerated(jsObject, viewId);
}
