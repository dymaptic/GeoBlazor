
export async function buildJsTimeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsTimeSliderGenerated } = await import('./timeSlider.gb');
    return await buildJsTimeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetTimeSlider(jsObject: any): Promise<any> {
    let { buildDotNetTimeSliderGenerated } = await import('./timeSlider.gb');
    return await buildDotNetTimeSliderGenerated(jsObject);
}
