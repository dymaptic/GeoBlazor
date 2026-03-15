
export function buildJsITimeUtilsDocument(dotNetObject: any, layerId: string | null, viewId: string | null): any {
    let { buildJsITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return buildJsITimeUtilsDocumentGenerated(dotNetObject, layerId, viewId);
}     

export function buildDotNetITimeUtilsDocument(jsObject: any, layerId: string | null, viewId: string | null): any {
    let { buildDotNetITimeUtilsDocumentGenerated } = await import('./iTimeUtilsDocument.gb');
    return buildDotNetITimeUtilsDocumentGenerated(jsObject, layerId, viewId);
}
