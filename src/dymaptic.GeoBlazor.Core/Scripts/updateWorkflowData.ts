
export async function buildJsUpdateWorkflowData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsUpdateWorkflowDataGenerated } = await import('./updateWorkflowData.gb');
    return await buildJsUpdateWorkflowDataGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetUpdateWorkflowData(jsObject: any): Promise<any> {
    let { buildDotNetUpdateWorkflowDataGenerated } = await import('./updateWorkflowData.gb');
    return await buildDotNetUpdateWorkflowDataGenerated(jsObject);
}
