
export async function buildJsFeaturesTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesTriggerActionEventGenerated } = await import('./featuresTriggerActionEvent.gb');
    return await buildJsFeaturesTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesTriggerActionEventGenerated } = await import('./featuresTriggerActionEvent.gb');
    return await buildDotNetFeaturesTriggerActionEventGenerated(jsObject);
}
