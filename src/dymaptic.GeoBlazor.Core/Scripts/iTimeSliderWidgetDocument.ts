
export async function buildJsITimeSliderWidgetDocument(dotNetObject: any): Promise<any> {
    let { buildJsITimeSliderWidgetDocumentGenerated } = await import('./iTimeSliderWidgetDocument.gb');
    return await buildJsITimeSliderWidgetDocumentGenerated(dotNetObject);
}     

export async function buildDotNetITimeSliderWidgetDocument(jsObject: any): Promise<any> {
    let { buildDotNetITimeSliderWidgetDocumentGenerated } = await import('./iTimeSliderWidgetDocument.gb');
    return await buildDotNetITimeSliderWidgetDocumentGenerated(jsObject);
}
