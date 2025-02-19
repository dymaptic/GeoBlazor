
export async function buildJsFlowScheme(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFlowSchemeGenerated } = await import('./flowScheme.gb');
    return await buildJsFlowSchemeGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFlowScheme(jsObject: any): Promise<any> {
    let { buildDotNetFlowSchemeGenerated } = await import('./flowScheme.gb');
    return await buildDotNetFlowSchemeGenerated(jsObject);
}
