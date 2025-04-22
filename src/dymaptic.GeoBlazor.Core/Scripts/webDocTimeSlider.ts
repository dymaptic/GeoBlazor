
export async function buildJsWebDocTimeSlider(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsWebDocTimeSliderGenerated } = await import('./webDocTimeSlider.gb');
    return await buildJsWebDocTimeSliderGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetWebDocTimeSlider(jsObject: any): Promise<any> {
    let { buildDotNetWebDocTimeSliderGenerated } = await import('./webDocTimeSlider.gb');
    return await buildDotNetWebDocTimeSliderGenerated(jsObject);
}
