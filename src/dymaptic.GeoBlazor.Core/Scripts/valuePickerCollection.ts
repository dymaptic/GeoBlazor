
export async function buildJsValuePickerCollection(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsValuePickerCollectionGenerated } = await import('./valuePickerCollection.gb');
    return await buildJsValuePickerCollectionGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetValuePickerCollection(jsObject: any): Promise<any> {
    let { buildDotNetValuePickerCollectionGenerated } = await import('./valuePickerCollection.gb');
    return await buildDotNetValuePickerCollectionGenerated(jsObject);
}
