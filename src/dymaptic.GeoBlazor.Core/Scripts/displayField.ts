
export async function buildJsDisplayField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDisplayFieldGenerated } = await import('./displayField.gb');
    return await buildJsDisplayFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDisplayField(jsObject: any): Promise<any> {
    let { buildDotNetDisplayFieldGenerated } = await import('./displayField.gb');
    return await buildDotNetDisplayFieldGenerated(jsObject);
}
