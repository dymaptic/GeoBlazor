
export async function buildJsFeaturesViewModelTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsFeaturesViewModelTriggerActionEventGenerated } = await import('./featuresViewModelTriggerActionEvent.gb');
    return await buildJsFeaturesViewModelTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetFeaturesViewModelTriggerActionEvent(jsObject: any): Promise<any> {
    let { buildDotNetFeaturesViewModelTriggerActionEventGenerated } = await import('./featuresViewModelTriggerActionEvent.gb');
    return await buildDotNetFeaturesViewModelTriggerActionEventGenerated(jsObject);
}
