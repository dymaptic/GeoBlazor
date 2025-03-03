
export async function buildJsITimeSliderViewModelDocument(dotNetObject: any): Promise<any> {
    let { buildJsITimeSliderViewModelDocumentGenerated } = await import('./iTimeSliderViewModelDocument.gb');
    return await buildJsITimeSliderViewModelDocumentGenerated(dotNetObject);
}     

export async function buildDotNetITimeSliderViewModelDocument(jsObject: any): Promise<any> {
    let { buildDotNetITimeSliderViewModelDocumentGenerated } = await import('./iTimeSliderViewModelDocument.gb');
    return await buildDotNetITimeSliderViewModelDocumentGenerated(jsObject);
}
