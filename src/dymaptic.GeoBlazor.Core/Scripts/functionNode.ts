
export async function buildJsFunctionNode(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFunctionNodeGenerated } = await import('./functionNode.gb');
    return await buildJsFunctionNodeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFunctionNode(jsObject: any): Promise<any> {
    let { buildDotNetFunctionNodeGenerated } = await import('./functionNode.gb');
    return await buildDotNetFunctionNodeGenerated(jsObject);
}
