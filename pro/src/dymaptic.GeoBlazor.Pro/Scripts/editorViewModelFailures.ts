
export async function buildJsEditorViewModelFailures(dotNetObject: any, viewId: string | null): Promise<any> {
    let { buildJsEditorViewModelFailuresGenerated } = await import('./editorViewModelFailures.gb');
    return await buildJsEditorViewModelFailuresGenerated(dotNetObject, viewId);
}     

export async function buildDotNetEditorViewModelFailures(jsObject: any, viewId: string | null): Promise<any> {
    let { buildDotNetEditorViewModelFailuresGenerated } = await import('./editorViewModelFailures.gb');
    return await buildDotNetEditorViewModelFailuresGenerated(jsObject, viewId);
}
