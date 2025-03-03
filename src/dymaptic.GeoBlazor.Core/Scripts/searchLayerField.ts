
export async function buildJsSearchLayerField(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsSearchLayerFieldGenerated } = await import('./searchLayerField.gb');
    return await buildJsSearchLayerFieldGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetSearchLayerField(jsObject: any): Promise<any> {
    let { buildDotNetSearchLayerFieldGenerated } = await import('./searchLayerField.gb');
    return await buildDotNetSearchLayerFieldGenerated(jsObject);
}
