export async function buildJsCreateFeaturesWorkflowData(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let {buildJsCreateFeaturesWorkflowDataGenerated} = await import('./createFeaturesWorkflowData.gb');
    return await buildJsCreateFeaturesWorkflowDataGenerated(dotNetObject, layerId, viewId);
}

export async function buildDotNetCreateFeaturesWorkflowData(jsObject: any): Promise<any> {
    let {buildDotNetCreateFeaturesWorkflowDataGenerated} = await import('./createFeaturesWorkflowData.gb');
    return await buildDotNetCreateFeaturesWorkflowDataGenerated(jsObject);
}
