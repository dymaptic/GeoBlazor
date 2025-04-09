
export async function buildJsDataTypeNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsDataTypeNodeGenerated } = await import('./dataTypeNode.gb');
    return await buildJsDataTypeNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetDataTypeNode(jsObject: any): Promise<any> {
    let { buildDotNetDataTypeNodeGenerated } = await import('./dataTypeNode.gb');
    return await buildDotNetDataTypeNodeGenerated(jsObject);
}
