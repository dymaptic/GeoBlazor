
export async function buildJsSearchTableField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchTableFieldGenerated } = await import('./searchTableField.gb');
    return await buildJsSearchTableFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchTableField(jsObject: any): Promise<any> {
    let { buildDotNetSearchTableFieldGenerated } = await import('./searchTableField.gb');
    return await buildDotNetSearchTableFieldGenerated(jsObject);
}
