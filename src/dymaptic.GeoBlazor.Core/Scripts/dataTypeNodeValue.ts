
export async function buildJsDataTypeNodeValue(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDataTypeNodeValueGenerated } = await import('./dataTypeNodeValue.gb');
    return await buildJsDataTypeNodeValueGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDataTypeNodeValue(jsObject: any): Promise<any> {
    let { buildDotNetDataTypeNodeValueGenerated } = await import('./dataTypeNodeValue.gb');
    return await buildDotNetDataTypeNodeValueGenerated(jsObject);
}
