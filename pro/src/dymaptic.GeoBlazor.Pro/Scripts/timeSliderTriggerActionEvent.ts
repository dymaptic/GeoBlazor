
export async function buildJsTimeSliderTriggerActionEvent(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeSliderTriggerActionEventGenerated } = await import('./timeSliderTriggerActionEvent.gb');
    return await buildJsTimeSliderTriggerActionEventGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeSliderTriggerActionEvent(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetTimeSliderTriggerActionEventGenerated } = await import('./timeSliderTriggerActionEvent.gb');
    return await buildDotNetTimeSliderTriggerActionEventGenerated(jsObject, layerId, viewId);
}
