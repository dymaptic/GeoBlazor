
export async function buildJsEditorViewModelFailures(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelFailuresGenerated } = await import('./editorViewModelFailures.gb');
    return await buildJsEditorViewModelFailuresGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetEditorViewModelFailures(jsObject: any): Promise<any> {
    let { buildDotNetEditorViewModelFailuresGenerated } = await import('./editorViewModelFailures.gb');
    return await buildDotNetEditorViewModelFailuresGenerated(jsObject);
}
