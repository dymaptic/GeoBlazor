
export function buildJsITimeSliderDocument(dotNetObject: any): any {
    let { buildJsITimeSliderDocumentGenerated } = await import('./iTimeSliderDocument.gb');
    return buildJsITimeSliderDocumentGenerated(dotNetObject);
}     

export function buildDotNetITimeSliderDocument(jsObject: any): any {
    let { buildDotNetITimeSliderDocumentGenerated } = await import('./iTimeSliderDocument.gb');
    return buildDotNetITimeSliderDocumentGenerated(jsObject);
}
