
export async function buildJsITimeSliderDocument(dotNetObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildJsITimeSliderDocumentGenerated } = await import('./iTimeSliderDocument.gb');
    return await buildJsITimeSliderDocumentGenerated(dotNetObject, layerId, viewId);
}     

export async function buildDotNetITimeSliderDocument(jsObject: any, layerId: string | null, viewId: string | null): Promise<any> {
    let { buildDotNetITimeSliderDocumentGenerated } = await import('./iTimeSliderDocument.gb');
    return await buildDotNetITimeSliderDocumentGenerated(jsObject, layerId, viewId);
}
