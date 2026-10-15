
export async function buildJsTimeSliderViewModelTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeSliderViewModelTriggerActionEventGenerated } = await import('./timeSliderViewModelTriggerActionEvent.gb');
    return await buildJsTimeSliderViewModelTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeSliderViewModelTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTimeSliderViewModelTriggerActionEventGenerated } = await import('./timeSliderViewModelTriggerActionEvent.gb');
    return await buildDotNetTimeSliderViewModelTriggerActionEventGenerated(jsObject, layerId, viewId);
}
