export async function buildJsEditorLayerInfo(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsEditorLayerInfoGenerated} = await import('./editorLayerInfo.gb');
    return await buildJsEditorLayerInfoGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetEditorLayerInfo(jsObject: any): Promise<any> {
    let {buildDotNetEditorLayerInfoGenerated} = await import('./editorLayerInfo.gb');
    return await buildDotNetEditorLayerInfoGenerated(jsObject);
}
